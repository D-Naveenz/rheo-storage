using Rheo.Storage.Handling;
using Rheo.Storage.Information;

namespace Rheo.Storage
{
    /// <summary>
    /// Represents a file in the file system and provides methods for file manipulation, such as copying, moving,
    /// renaming, deleting, and writing data.
    /// </summary>
    /// <remarks>FileObject ensures that the specified file exists upon instantiation, creating it if
    /// necessary. The class offers both synchronous and asynchronous operations for file management. All methods throw
    /// an ObjectDisposedException if the instance has been disposed. Thread safety is not guaranteed; callers should
    /// ensure appropriate synchronization if accessing the same instance from multiple threads.</remarks>
    public class FileObject : StorageObject<FileObject, FileInformation>
    {
        /// <summary>
        /// Initializes a new instance of the FileObject class for the specified file path, creating the file if it does
        /// not already exist.
        /// </summary>
        /// <remarks>If the specified file does not exist, it is created. The constructor does not keep
        /// the file open after initialization.</remarks>
        /// <param name="path">The path to the file to be represented by this object. Can be either an absolute or relative path.</param>
        public FileObject(string path) : base(path)
        {
            path = FullPath; // Ensure base class has processed the path

            // Ensure the file exists without holding a stream open
            File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read).Dispose();
        }

        /// <inheritdoc/>
        public override string Name => Path.GetFileName(FullPath);

        /// <inheritdoc/>
        public override FileObject Copy(string destination, bool overwrite)
        {
            ThrowIfDisposed();
            return FileHandling.Copy(this, destination, overwrite);
        }

        /// <inheritdoc/>
        public override FileObject Copy(string destination, IProgress<StorageProgress>? progress, bool overwrite = false)
        {
            ThrowIfDisposed();
            return FileHandling.Copy(this, destination, overwrite, progress);
        }

        /// <inheritdoc/>
        public override Task<FileObject> CopyAsync(string destination, bool overwrite, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            return FileHandling.CopyAsync(this, destination, overwrite, null, cancellationToken);
        }

        /// <inheritdoc/>
        public override Task<FileObject> CopyAsync(string destination, IProgress<StorageProgress>? progress, bool overwrite = false, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            return FileHandling.CopyAsync(this, destination, overwrite, progress, cancellationToken);
        }

        /// <inheritdoc/>
        public override void Delete()
        {
            ThrowIfDisposed();
            FileHandling.Delete(this);
        }

        /// <inheritdoc/>
        public override Task DeleteAsync(CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            return FileHandling.DeleteAsync(this, cancellationToken);
        }

        /// <inheritdoc/>
        public override FileObject Move(string destination, bool overwrite)
        {
            ThrowIfDisposed();
            return FileHandling.Move(this, destination, overwrite);
        }

        /// <inheritdoc/>
        public override FileObject Move(string destination, IProgress<StorageProgress>? progress, bool overwrite = false)
        {
            ThrowIfDisposed();
            return FileHandling.Move(this, destination, overwrite, progress);
        }

        /// <inheritdoc/>
        public override Task<FileObject> MoveAsync(string destination, bool overwrite, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            return FileHandling.MoveAsync(this, destination, overwrite, null, cancellationToken);
        }

        /// <inheritdoc/>
        public override Task<FileObject> MoveAsync(string destination, IProgress<StorageProgress>? progress, bool overwrite = false, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            return FileHandling.MoveAsync(this, destination, overwrite, progress, cancellationToken);
        }

        /// <inheritdoc/>
        public override FileObject Rename(string newName)
        {
            ThrowIfDisposed();
            return FileHandling.Rename(this, newName);
        }

        /// <inheritdoc/>
        public override Task<FileObject> RenameAsync(string newName, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            return FileHandling.RenameAsync(this, newName, cancellationToken);
        }

        /// <inheritdoc/>
        public FileObject Write(Stream stream, bool overwrite)
        {
            ThrowIfDisposed();
            return FileHandling.Write(this, stream, overwrite, null);
        }

        /// <inheritdoc/>
        public FileObject Write(Stream stream, bool overwrite, IProgress<StorageProgress>? progress)
        {
            ThrowIfDisposed();
            return FileHandling.Write(this, stream, overwrite, progress);
        }

        /// <inheritdoc/>
        public Task<FileObject> WriteAsync(Stream stream, bool overwrite = false, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            return FileHandling.WriteAsync(this, stream, overwrite, null, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<FileObject> WriteAsync(Stream stream, IProgress<StorageProgress>? progress, bool overwrite = false, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            return FileHandling.WriteAsync(this, stream, overwrite, progress, cancellationToken);
        }
    }
}
