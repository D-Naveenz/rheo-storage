using Rheo.Storage.Contracts;

namespace Rheo.Storage
{
    /// <summary>
    /// Provides an abstract base class for file system storage objects, encapsulating common functionality such as path
    /// validation, resource management, and change notification.
    /// </summary>
    /// <remarks>The StorageObject class serves as a foundation for implementing file- or directory-based
    /// storage abstractions. It manages the association with a file system path, ensures the existence of parent
    /// directories, and provides thread-safe state management. Derived classes should implement the required members to
    /// provide specific storage behaviors. The class supports change notification through the Changed event and
    /// implements resource cleanup via IDisposable. Instances should not be used after they have been
    /// disposed.</remarks>
    public abstract class StorageObject: IStorageObject    // Using Curiously Recurring Template Pattern (CRTP)
    {
        private const int MIN_BUFFER_SIZE = 1024; // 1KB
        private const int MAX_BUFFER_SIZE = 16 * 1024 * 1024; // 16MB
        
        private readonly SemaphoreSlim _stateLockingSemaphore = new(1, 1);
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the StorageObject class for the specified file or path.
        /// </summary>
        /// <remarks>If the specified path does not exist, the constructor creates the necessary parent
        /// directory. This ensures that the storage object is always associated with a valid file system
        /// location.</remarks>
        /// <param name="fileNameOrPath">The file name or full path to associate with this storage object. Cannot be null or empty.</param>
        public StorageObject(string fileNameOrPath)
        {
            FullPath = GetValidPath(fileNameOrPath);

            // Ensure the root path exists.
            if (!Directory.Exists(ParentDirectory))
            {
                Directory.CreateDirectory(ParentDirectory);
            }

            // Subscribe to change events
            Changed += OnStateChanged;
        }

        /// <summary>
        /// Releases all resources used by the current instance of the class.
        /// </summary>
        /// <remarks>Call this method when you are finished using the object to release any resources it
        /// is holding. After calling Dispose, the object should not be used. This method can be overridden in a derived
        /// class to release additional resources.</remarks>
        public virtual void Dispose()
        {
            lock (StateLock)
            {
                if (!_disposed)
                {
                    // Unsubscribe from events
                    Changed -= OnStateChanged;

                    // Clean up managed resources here, if any
                    FullPath = string.Empty;
                    Information = default!;
                    _disposed = true;
                }
            }

            GC.SuppressFinalize(this);
        }

        #region Properties
        /// <inheritdoc/>
        public abstract IStorageInformation Information { get; protected set; }

        /// <inheritdoc/>
        public abstract string Name { get; }

        /// <inheritdoc/>
        public string ParentDirectory => GetDirectoryPath(FullPath);

        /// <inheritdoc/>
        public string FullPath { get; protected set; }

        /// <inheritdoc/>
        public bool IsDisposed => _disposed;

        /// <summary>
        /// Gets the internal lock object used to synchronize access to the state of this storage object.
        /// </summary>
        public Lock StateLock { get; } = new();

        internal SemaphoreSlim Semaphore => _stateLockingSemaphore;

        #endregion

        /// <inheritdoc/>
        public event EventHandler<StorageChangedEventArgs>? Changed;

        /// <inheritdoc/>
        public int GetBufferSize()
        {
            if (Information is null)
            {
                throw new InvalidOperationException("Storage information is not initialized.");
            }
            var size = Information.Size;

            if (size == 0)
                return MIN_BUFFER_SIZE;
            else if (size < MIN_BUFFER_SIZE)
                return MIN_BUFFER_SIZE;
            else if (size > MAX_BUFFER_SIZE)
                return MAX_BUFFER_SIZE;
            else
                return Math.Min(MAX_BUFFER_SIZE, Math.Max(MIN_BUFFER_SIZE, (int)(size / 100))); // Aim for ~100 chunks
        }

        /// <inheritdoc/>
        public void ThrowIfDisposed()
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (Information is null)
            {
                return $"{Name} | Info: N/A";
            }

            return Information.ToString()!;
        }

        /// <summary>
        /// Validates the specified path and returns its absolute form if it meets the required criteria for the given
        /// assertion type.
        /// </summary>
        /// <remarks>Use this method to ensure that a path is valid and appropriate for the intended file
        /// or directory operation before proceeding. The method does not check for the existence of the file or
        /// directory unless it is necessary to disallow an existing file or directory based on the assertion
        /// type.</remarks>
        /// <param name="path">The file system path to validate. Cannot be null, empty, or consist only of white-space characters, and must
        /// not contain invalid path characters.</param>
        /// <returns>The absolute path corresponding to the specified path if it passes validation.</returns>
        /// <exception cref="ArgumentException">Thrown if the path is null, empty, consists only of white-space characters, contains invalid path
        /// characters, points to an existing directory when a file is expected, points to an existing file when a
        /// directory is expected, or if an invalid assertion type is specified.</exception>
        protected virtual string GetValidPath(string path)
        {
            // Method 1: Check if the path is null, empty, or whitespace
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("The path cannot be null, empty, or whitespace.", nameof(path));
            }

            // Method 2: Verify the path does not contain invalid characters
            var invalidChars = Path.GetInvalidPathChars();
            if (path.IndexOfAny(invalidChars) >= 0)
            {
                throw new ArgumentException("The path contains invalid characters.", nameof(path));
            }

            var fullPath = Path.GetFullPath(path);

            return fullPath;
        }

        /// <summary>
        /// Asynchronously waits until the specified file is unlocked (available for exclusive access).
        /// </summary>
        /// <param name="filePath">Full path to the file.</param>
        /// <param name="timeoutMilliseconds">Maximum wait time in milliseconds (0 for infinite).</param>
        /// <param name="checkIntervalMilliseconds">Delay between checks in milliseconds.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the wait operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is true if the file became available, false if timed out.</returns>
        /// <exception cref="ArgumentException">Thrown if the file path is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Thrown if the file does not exist.</exception>
        /// <exception cref="OperationCanceledException">Thrown if the operation is cancelled.</exception>
        protected static async Task<bool> WaitForFileUnlockAsync(string filePath, int timeoutMilliseconds = 10000, int checkIntervalMilliseconds = 200, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found.", filePath);

            var startTime = DateTime.UtcNow;

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                try
                {
                    // Try opening with exclusive access
                    using FileStream fs = new(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                    // Successfully opened — file is unlocked
                    return true;
                }
                catch (IOException)
                {
                    // File is still locked by another process
                }
                catch (UnauthorizedAccessException)
                {
                    // File might be read-only or locked by OS
                }

                // Check timeout
                if (timeoutMilliseconds > 0 &&
                    (DateTime.UtcNow - startTime).TotalMilliseconds > timeoutMilliseconds)
                {
                    return false; // Timed out
                }

                await Task.Delay(checkIntervalMilliseconds, cancellationToken);
            }
        }

        /// <summary>
        /// Synchronously waits until the specified file is unlocked (available for exclusive access).
        /// </summary>
        /// <param name="filePath">Full path to the file.</param>
        /// <param name="timeoutMilliseconds">Maximum wait time in milliseconds (0 for infinite).</param>
        /// <param name="checkIntervalMilliseconds">Delay between checks in milliseconds.</param>
        /// <returns>True if the file became available, false if timed out.</returns>
        /// <exception cref="ArgumentException">Thrown if the file path is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Thrown if the file does not exist.</exception>
        protected static bool WaitForFileUnlock(string filePath, int timeoutMilliseconds = 10000, int checkIntervalMilliseconds = 200)
        {
            return WaitForFileUnlockAsync(filePath, timeoutMilliseconds, checkIntervalMilliseconds, CancellationToken.None)
                .GetAwaiter()
                .GetResult();
        }

        internal bool IsInTheSameRoot(string destpath)
        {
            try
            {
                var drive1 = Path.GetPathRoot(Path.GetFullPath(FullPath));
                var drive2 = Path.GetPathRoot(Path.GetFullPath(destpath));

                return string.Equals(drive1, drive2, StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                // If we can't determine, assume different volumes
                return false;
            }
        }

        internal void RaiseChanged(StorageChangeType changeType, IStorageInformation? newInformation)
        {
            Changed?.Invoke(this, new StorageChangedEventArgs(changeType, newInformation));
        }

        private void OnStateChanged(object? sender, StorageChangedEventArgs e)
        {
            ThrowIfDisposed();

            if (e.ChangeType != StorageChangeType.Deleted && e.NewInfo is not null)
            {
                lock (StateLock)
                {
                    // Update information and path on modification or relocation
                    Information = e.NewInfo;
                    FullPath = Information.AbsolutePath;
                }
            }
            else if (e.ChangeType == StorageChangeType.Deleted)
            {
                // Dispose the object if it has been deleted
                Dispose();
            }
        }

        private static string GetDirectoryPath(string pathlike)
        {
            string? dir;

            try
            {
                dir = Path.GetFullPath(pathlike);

                do
                {
                    dir = Path.GetDirectoryName(dir);

                    if (!string.IsNullOrEmpty(dir))
                    {
                        return dir;
                    }
                }
                while (dir is not null);

                throw new ArgumentException($"The path '{pathlike}' does not contain a valid directory.");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"The path '{pathlike}' is not a valid path.", ex);
            }
        }
    }
}
