using Rheo.Storage.Info;
using System.Diagnostics;

namespace Rheo.Storage
{
    /// <summary>
    /// Represents a file stored in the system, providing methods for file operations such as copying, moving, renaming,
    /// and deleting.
    /// </summary>
    /// <remarks>This class extends <see cref="StorageController{T}"/> to provide file-specific functionality,
    /// including retrieving file metadata, checking availability, and performing asynchronous file operations. It
    /// supports progress reporting and cancellation for long-running tasks.</remarks>
    /// <param name="fileNameOrPath"></param>
    /// <param name="isInfoRequired"></param>
    public class FileController(string fileNameOrPath, bool isInfoRequired = true) : 
        StorageController<FileInfomation>(fileNameOrPath, isInfoRequired, AssertAs.File)
    {
        public override DateTime CreatedAt => File.GetCreationTime(FullPath);

        /// <inheritdoc cref="FileInfomation.Extension"/>
        public string? Extension => Information.Extension;

        public override bool IsAvailable => File.Exists(FullPath);

        /// <summary>
        /// Gets a value indicating whether the file is binary.
        /// </summary>
        public bool? IsBinary => Information.IsBinaryFile();

        public override async Task CopyAsync(
            string destination,
            bool overwrite = false,
            int maxConcurrent = 4,
            IProgress<StorageProgress>? progress = null,
            CancellationToken cancellationToken = default)
        {
            ProcessDestinationPath(ref destination, overwrite);

            using var sourceStream = new FileStream(
                FullPath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                BufferSize,
                true);

            using var destStream = new FileStream(
                destination,
                overwrite ? FileMode.Create : FileMode.CreateNew,
                FileAccess.Write,
                FileShare.None,
                BufferSize,
                true);

            long totalBytes = sourceStream.Length;
            long totalBytesRead = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Use a semaphore to throttle concurrent buffer reads/writes
            using var semaphore = new SemaphoreSlim(maxConcurrent > 0 ? maxConcurrent : 1);

            byte[] buffer = new byte[BufferSize];
            int bytesRead;

            while ((bytesRead = await sourceStream.ReadAsync(buffer, cancellationToken)) > 0)
            {
                await semaphore.WaitAsync(cancellationToken);
                try
                {
                    await destStream.WriteAsync(buffer.AsMemory(0, bytesRead), cancellationToken);
                    totalBytesRead += bytesRead;

                    if (progress != null)
                    {
                        double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
                        double bytesPerSecond = elapsedSeconds > 0 ? totalBytesRead / elapsedSeconds : 0;
                        progress.Report(new StorageProgress
                        {
                            TotalBytes = totalBytes,
                            BytesTransferred = totalBytesRead,
                            BytesPerSecond = bytesPerSecond
                        });
                    }
                }
                finally
                {
                    semaphore.Release();
                }

                if (cancellationToken.IsCancellationRequested)
                    break;
            }
        }

        public override Task DeleteAsync()
        {
            return Task.Run(() =>
            {
                File.Delete(FullPath);
            });
        }

        public override long GetSize(UOM uom = UOM.KB)
        {
            if (!File.Exists(FullPath))
            {
                return 0;
            }
            var sizeInBytes = new FileInfo(FullPath).Length;
            // Use Math.Pow for correct unit conversion and cast the result to long
            return (long)(sizeInBytes / Math.Pow(1024, (int)uom));
        }

        public override async Task MoveAsync(
            string destination,
            bool overwrite = false,
            int maxConcurrent = 4,
            IProgress<StorageProgress>? progress = null,
            CancellationToken cancellationToken = default)
        {
            ProcessDestinationPath(ref destination, overwrite);

            if (AreOnSameVolume(FullPath, destination))
            {
                // Same volume move - fast operation (just directory entry update)
                if (overwrite && File.Exists(destination))
                {
                    File.Delete(destination);
                }

                // Use Task.Run for async context and cancellation support
                await Task.Run(() =>
                {
                    File.Move(FullPath, destination, overwrite);
                }, cancellationToken);

                progress?.Report(new StorageProgress
                {
                    TotalBytes = 1,
                    BytesTransferred = 1,
                    BytesPerSecond = 0
                });
            }
            else
            {
                // Cross-volume move - requires copy then delete
                await CopyAsync(destination, overwrite, maxConcurrent, progress, cancellationToken);
                await DeleteAsync();
            }
        }

        public override async Task RenameAsync(string newName)
        {
            // Check if the name is null, empty, or whitespace
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("The name cannot be null, empty, or whitespace.", nameof(newName));
            }

            // Verify the name does not contain invalid characters
            var invalidChars = Path.GetInvalidPathChars();
            if (newName.IndexOfAny(invalidChars) >= 0)
            {
                throw new ArgumentException("The name contains invalid characters.", nameof(newName));
            }

            string newPath = Path.Combine(Path.GetDirectoryName(FullPath) ?? throw new InvalidOperationException("Directory name is null"), newName);
            if (File.Exists(newPath))
            {
                throw new IOException($"A file with the name '{newName}' already exists.");
            }

            // Perform the rename (move)
            await Task.Run(() => File.Move(FullPath, newPath));

            // Update internal state
            Name = newName;
        }

        public override string ToString()
        {
            return Stringify(AssertAs.File, DisplayName, DisplayType);
        }

        /// <inheritdoc/>
        /// <exception cref="IOException">Thrown if <paramref name="overwrite"/> is <see langword="false"/> and the file already exists at the
        /// destination path.</exception>
        protected override void ProcessDestinationPath(ref string destination, bool overwrite)
        {
            base.ProcessDestinationPath(ref destination, overwrite);

            // Combine the destination directory with the current file name
            destination = Path.Combine(destination, Name);
            if (!overwrite && File.Exists(destination))
                throw new IOException("File already exists.");
        }
    }
}
