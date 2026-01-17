using Rheo.Storage.Contracts;
using Rheo.Storage.Core;
using Rheo.Storage.Information;

namespace Rheo.Storage
{
    /// <summary>
    /// Represents a file in the file system and provides methods for file manipulation, including copying, moving,
    /// deleting, renaming, and reading or writing file data to streams.
    /// </summary>
    /// <remarks>FileObject instances encapsulate file operations with thread safety and support both
    /// synchronous and asynchronous workflows. The class ensures that the underlying file exists upon initialization
    /// and provides mechanisms for progress reporting and cancellation in long-running operations. FileObject is
    /// designed to be used in scenarios where robust file management and integration with streams are
    /// required.</remarks>
    public class FileObject : FileHandler, IFileObject
    {
        /// <summary>
        /// Initializes a new instance of the FileObject class for the specified file path, creating the file if it does
        /// not already exist.
        /// </summary>
        /// <remarks>If the specified file does not exist, it is created. The constructor ensures proper
        /// file handle cleanup to prevent file locking issues.</remarks>
        /// <param name="path">The path to the file to be represented by this object. Can be either an absolute or relative path.</param>
        public FileObject(string path) : base(path)
        {
            path = FullPath; // Ensure base class has processed the path

            // Ensure the file exists without holding a stream open
            // Use 'using' to guarantee disposal even if an exception occurs
            // Use FileShare.ReadWrite to avoid blocking other operations
            using var fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        }

        internal FileObject(FileInformation information) : base(information)
        {
        }

        /// <inheritdoc/>
        public override string Name
        {
            get
            {
                lock (StateLock)
                {
                    return Path.GetFileName(FullPath);
                }
            }
        }

        /// <inheritdoc/>
        public new FileInformation Information => base.Information as FileInformation ?? throw new InvalidOperationException("Information is not of type FileInformation.");

        /// <inheritdoc/>
        public IFileObject Copy(string destination, bool overwrite)
        {
            ThrowIfDisposed();
            var info = CopyInternal(destination, overwrite);
            return new FileObject(info);
        }

        /// <inheritdoc/>
        public IFileObject Copy(string destination, IProgress<StorageProgress>? progress, bool overwrite = false)
        {
            ThrowIfDisposed();
            var info = CopyInternal(destination, overwrite, progress);
            return new FileObject(info);
        }

        /// <inheritdoc/>
        public async Task<IFileObject> CopyAsync(string destination, bool overwrite, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            var info = await CopyInternalAsync(destination, overwrite, null, cancellationToken);
            return new FileObject(info);
        }

        /// <inheritdoc/>
        public async Task<IFileObject> CopyAsync(string destination, IProgress<StorageProgress>? progress, bool overwrite = false, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            var info = await CopyInternalAsync(destination, overwrite, progress, cancellationToken);
            return new FileObject(info);
        }

        /// <inheritdoc/>
        public void Delete()
        {
            ThrowIfDisposed();
            DeleteInternal();
        }

        /// <inheritdoc/>
        public Task DeleteAsync(CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            return DeleteInternalAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public void Move(string destination, bool overwrite)
        {
            ThrowIfDisposed();
            MoveInternal(destination, overwrite);
        }

        /// <inheritdoc/>
        public void Move(string destination, IProgress<StorageProgress>? progress, bool overwrite = false)
        {
            ThrowIfDisposed();
            MoveInternal(destination, overwrite, progress);
        }

        /// <inheritdoc/>
        public async Task MoveAsync(string destination, bool overwrite, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            await MoveInternalAsync(destination, overwrite, null, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task MoveAsync(string destination, IProgress<StorageProgress>? progress, bool overwrite = false, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            await MoveInternalAsync(destination, overwrite, progress, cancellationToken);
        }

        /// <inheritdoc/>
        public void Rename(string newName)
        {
            ThrowIfDisposed();

            // ✅ NO LOCK - FileHandling.Rename already locks
            RenameInternal(newName);
        }

        /// <inheritdoc/>
        public async Task RenameAsync(string newName, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            // ❌ REMOVE THE LOCK - FileHandling.RenameAsync already locks!
            await RenameInternalAsync(newName, cancellationToken);
        }

        /// <inheritdoc/>
        public void Write(Stream stream)
        {
            ThrowIfDisposed();

            // ✅ NO LOCK - FileHandling.Write already locks
            WriteInternal(stream, null);
        }

        /// <inheritdoc/>
        public void Write(Stream stream, IProgress<StorageProgress> progress)
        {
            ThrowIfDisposed();

            // ✅ NO LOCK - FileHandling.Write already locks
            WriteInternal(stream, progress);
        }

        /// <inheritdoc/>
        public async Task WriteAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            // ❌ REMOVE THE LOCK - FileHandling.WriteAsync already locks!
            await WriteInternalAsync(stream, null, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task WriteAsync(Stream stream, IProgress<StorageProgress> progress, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            // ❌ REMOVE THE LOCK - FileHandling.WriteAsync already locks!
            await WriteInternalAsync(stream, progress, cancellationToken);
        }
    }
}
