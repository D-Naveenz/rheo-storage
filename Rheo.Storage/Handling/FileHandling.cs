using System.Diagnostics;
using Rheo.Storage.Information;

namespace Rheo.Storage.Handling
{
    internal static partial class FileHandling
    {
        /// <summary>
        /// Copies the contents of the specified source file to a new file at the given destination path, optionally
        /// overwriting an existing file and reporting progress.
        /// </summary>
        /// <remarks>The copy operation is performed using buffered streams for efficient file transfer.
        /// Progress is reported after each write if a progress reporter is provided. The method acquires a lock on the
        /// source file to ensure thread safety during the operation.</remarks>
        /// <param name="source">The source <see cref="FileObject"/> representing the file to copy. Must not be null.</param>
        /// <param name="destination">The full path to the destination file. If the file exists and <paramref name="overwrite"/> is <see
        /// langword="false"/>, an exception is thrown.</param>
        /// <param name="overwrite">A value indicating whether to overwrite the destination file if it already exists. If <see
        /// langword="true"/>, the existing file will be replaced.</param>
        /// <param name="progress">An optional progress reporter that receives updates on the number of bytes transferred and transfer rate
        /// during the copy operation. May be null.</param>
        /// <returns>A <see cref="FileInformation"/> object containing metadata about the newly created file at the destination path.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the copy operation fails due to I/O errors or insufficient permissions.</exception>
        public static FileInformation Copy(
            FileObject source,
            string destination,
            bool overwrite,
            IProgress<StorageProgress>? progress = null)
        {
            // INITIALIZATION
            ProcessDestinationPath(ref destination, source.Name, overwrite);
            var bufferSize = source.GetBufferSize();

            // OPERATION
            lock(source.StateLock)
            {
                try
                {
                    using var sourceStream = new FileStream(
                        source.FullPath,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.Read,
                        bufferSize,
                        FileOptions.SequentialScan);

                    CopyStreamToFile(
                        sourceStream,
                        destination,
                        overwrite,
                        bufferSize,
                        progress);
                }
                catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
                {
                    throw new InvalidOperationException($"Failed to copy file to: {destination}", ex);
                }
            }

            // FINALIZATION - Return file information
            return new FileInformation(destination);
        }

        /// <summary>
        /// Deletes the specified file from the file system and disposes the associated FileObject.
        /// </summary>
        /// <remarks>After successful deletion, the FileObject is disposed and should not be used. This
        /// method acquires a lock on the FileObject to ensure thread safety during the delete operation.</remarks>
        /// <param name="source">The FileObject representing the file to delete. Cannot be null. The file must exist and be accessible for
        /// deletion.</param>
        /// <exception cref="InvalidOperationException">Thrown if the file cannot be deleted due to an I/O error or insufficient permissions.</exception>
        public static void Delete(FileObject source)
        {
            lock(source.StateLock)
            {
                try
                {
                    var path = source.FullPath; // Store path before raising event

                    File.Delete(path);
                    
                    // Raise the Changed event to notify deletion
                    source.RaiseChanged(StorageChangeType.Deleted, null);
                }
                catch (FileNotFoundException)
                {
                    // File already deleted - still raise the event
                    source.RaiseChanged(StorageChangeType.Deleted, null);
                }
                catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
                {
                    throw new InvalidOperationException($"Failed to delete file: {source.FullPath}", ex);
                }
            }
        }

        /// <summary>
        /// Moves the specified file to a new destination path, optionally overwriting an existing file and reporting
        /// progress.
        /// </summary>
        /// <remarks>If the source and destination are on the same storage volume, the move is performed
        /// as a fast directory entry update. For cross-volume moves, the file is copied to the destination and the
        /// source is deleted. The source object's state is updated via the Changed event. Progress is reported only for the
        /// final state of the operation.</remarks>
        /// <param name="source">The file to move. Must not be null and must reference an existing file.</param>
        /// <param name="destination">The destination path to move the file to. Cannot be null or empty. If the path refers to an existing file
        /// and <paramref name="overwrite"/> is <see langword="false"/>, the operation will fail.</param>
        /// <param name="overwrite">Specifies whether to overwrite the destination file if it already exists. Set to <see langword="true"/> to
        /// overwrite; otherwise, <see langword="false"/>.</param>
        /// <param name="progress">An optional progress reporter that receives updates about the move operation. May be null if progress
        /// reporting is not required.</param>
        /// <returns>A <see cref="FileInformation"/> object containing metadata about the file at the new location.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the move operation fails due to I/O errors or insufficient permissions.</exception>
        public static FileInformation Move(
            FileObject source,
            string destination,
            bool overwrite,
            IProgress<StorageProgress>? progress = null)
        {
            // INITIALIZATION
            ProcessDestinationPath(ref destination, source.Name, overwrite);

            // OPERATION
            lock(source.StateLock)
            {
                try
                {
                    if (source.IsInTheSameRoot(destination))
                    {
                        // Same volume move - fast operation (just directory entry update)
                        File.Move(source.FullPath, destination, overwrite);

                        // Send final progress update
                        progress?.Report(new StorageProgress
                        {
                            TotalBytes = 1,
                            BytesTransferred = 1,
                            BytesPerSecond = 0
                        });

                        // FINALIZATION - Create and return new information
                        var newInfo = new FileInformation(destination);
                        source.RaiseChanged(StorageChangeType.Relocated, newInfo);
                        return newInfo;
                    }
                }
                catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
                {
                    throw new InvalidOperationException($"Failed to move file to: {destination}", ex);
                }
            }

            // Cross-volume move - release lock before calling nested operations
            FileInformation? copiedInfo = null;
            try
            {
                copiedInfo = Copy(source, destination, overwrite, progress);
                Delete(source);

                // Raise relocation event for the source object
                source.RaiseChanged(StorageChangeType.Relocated, copiedInfo);

                // FINALIZATION
                return copiedInfo;
            }
            catch
            {
                // Rollback: Delete the copied file if delete of source failed
                if (copiedInfo != null)
                {
                    try 
                    { 
                        var tempObj = new FileObject(copiedInfo.AbsolutePath);
                        Delete(tempObj); 
                    } 
                    catch { /* Log but don't throw */ }
                }
                throw;
            }
        }

        /// <summary>
        /// Renames the specified file to the given new name and updates the source object's state.
        /// </summary>
        /// <remarks>The source FileObject is updated via the Changed event to reflect the new name.
        /// The operation is thread-safe and will wait for any ongoing operations on the
        /// source file to complete before renaming.</remarks>
        /// <param name="source">The FileObject representing the file to be renamed. Must not be null.</param>
        /// <param name="newName">The new name for the file. Must be a valid file name and cannot be null or empty.</param>
        /// <returns>A <see cref="FileInformation"/> object containing metadata about the renamed file.</returns>
        /// <exception cref="ArgumentException">Thrown if the new name is null, empty, or contains invalid characters.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the file cannot be renamed due to an I/O error or insufficient permissions.</exception>
        public static FileInformation Rename(FileObject source, string newName)
        {
            // INITIALIZATION
            ThrowIfInvalidFileName(newName);
            var destination = source.ParentDirectory;
            ProcessDestinationPath(ref destination, newName, false);

            // OPERATION
            lock(source.StateLock)
            {
                try
                {
                    File.Move(source.FullPath, destination, false);
                    
                    // FINALIZATION - Create new information and raise event
                    var newInfo = new FileInformation(destination);
                    source.RaiseChanged(StorageChangeType.Relocated, newInfo);
                    return newInfo;
                }
                catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
                {
                    throw new InvalidOperationException($"Failed to rename file to: {newName}", ex);
                }
            }
        }

        /// <summary>
        /// Writes the contents of a stream to the specified file, optionally overwriting existing content and
        /// reporting progress.
        /// </summary>
        /// <remarks>This method acquires an exclusive lock on the file for the duration of the write operation
        /// to ensure thread safety. The source stream is read from its current position (after seeking to the
        /// beginning). The source FileObject's state is updated via the Changed event after writing.</remarks>
        /// <param name="source">The FileObject representing the destination file. Must not be null.</param>
        /// <param name="sourceStream">The stream containing data to write. Must support reading and have a known length. The stream is not
        /// disposed by this method.</param>
        /// <param name="overwrite">A value indicating whether to overwrite the file if it already exists. If <see langword="false"/> and
        /// the file exists, an exception is thrown.</param>
        /// <param name="progress">An optional progress reporter that receives updates about the write operation. May be null.</param>
        /// <returns>A <see cref="FileInformation"/> object containing updated metadata about the file after the write operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the write operation fails due to an I/O error or insufficient permissions.</exception>
        public static FileInformation Write(
            FileObject source,
            Stream sourceStream,
            bool overwrite = false,
            IProgress<StorageProgress>? progress = null)
        {
            // INITIALIZATION
            var bufferSize = source.GetBufferSize();
            var destination = source.FullPath;

            // OPERATION
            lock(source.StateLock)
            {
                try
                {
                    // Ensure we start reading from the beginning
                    sourceStream.Seek(0, SeekOrigin.Begin);

                    CopyStreamToFile(
                        sourceStream,
                        destination,
                        overwrite,
                        bufferSize,
                        progress);
                    
                    // FINALIZATION - Create new information and raise event
                    var newInfo = new FileInformation(destination);
                    source.RaiseChanged(StorageChangeType.Modified, newInfo);
                    return newInfo;
                }
                catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
                {
                    throw new InvalidOperationException($"Failed to write to file: {destination}", ex);
                }
            }
        }

        /// <summary>
        /// Core implementation for copying data from a stream to a file using synchronous I/O.
        /// </summary>
        /// <remarks>This internal method implements buffered stream copying for reliable file transfer. The
        /// method does not acquire locks or manage FileObject lifecycle - callers are responsible for synchronization
        /// and resource management.</remarks>
        /// <param name="sourceStream">The source stream to read from. Must support reads and have a known length.</param>
        /// <param name="destinationPath">The full path to the destination file.</param>
        /// <param name="overwrite">Whether to overwrite the destination file if it exists.</param>
        /// <param name="bufferSize">The buffer size to use for reading and writing.</param>
        /// <param name="progress">Optional progress reporter for tracking the operation.</param>
        private static void CopyStreamToFile(
            Stream sourceStream,
            string destinationPath,
            bool overwrite,
            int bufferSize,
            IProgress<StorageProgress>? progress)
        {
            using var destStream = new FileStream(
                destinationPath,
                overwrite ? FileMode.Create : FileMode.CreateNew,
                FileAccess.Write,
                FileShare.None,
                bufferSize,
                FileOptions.SequentialScan);

            var totalBytes = sourceStream.Length;
            var totalRead = 0L;
            var stopwatch = Stopwatch.StartNew();
            var buffer = new byte[bufferSize];
            int bytesRead;

            while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                destStream.Write(buffer, 0, bytesRead);
                totalRead += bytesRead;

                if (progress != null)
                {
                    // Report progress after each successful write
                    double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
                    double bytesPerSecond = elapsedSeconds > 0 ? totalRead / elapsedSeconds : 0;
                    progress.Report(new StorageProgress
                    {
                        TotalBytes = totalBytes,
                        BytesTransferred = totalRead,
                        BytesPerSecond = bytesPerSecond
                    });
                }
            }
        }
    }
}
