namespace Rheo.Storage.Contracts
{
    /// <summary>
    /// Provides a non-generic interface for storage objects, enabling polymorphic handling of files and directories
    /// without requiring generic type parameters.
    /// </summary>
    /// <remarks>
    /// This interface allows working with storage objects in scenarios where the specific generic types are not known
    /// at compile time, such as collections of mixed storage types or factory patterns. The concrete generic class
    /// <see cref="Storage.StorageObject{TObj, TInfo}"/> implements this interface.
    /// </remarks>
    public interface IStorageObject : IDisposable
    {
        /// <summary>
        /// Gets metadata information about the storage object, such as size, attributes, and timestamps.
        /// </summary>
        IStorageInformation Information { get; }

        /// <summary>
        /// Gets the name of the storage object, typically the file or directory name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the full path of the parent directory for the current file or directory.
        /// </summary>
        string ParentDirectory { get; }

        /// <summary>
        /// Gets the full path of the file or directory.
        /// </summary>
        string FullPath { get; }

        /// <summary>
        /// Gets a value indicating whether this storage object has been disposed.
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// Occurs when the storage content changes.
        /// </summary>
        /// <remarks>Subscribers are notified whenever an item is added, removed, or updated in the
        /// storage. The event provides details about the change through the <see cref="StorageChangedEventArgs"/>
        /// parameter. This event is typically raised on the thread where the change occurs; callers should ensure
        /// thread safety when handling the event.</remarks>
        event EventHandler<StorageChangedEventArgs>? Changed;

        /// <summary>
        /// Deletes the storage object from the file system.
        /// </summary>
        void Delete();

        /// <summary>
        /// Asynchronously deletes the storage object from the file system.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous delete operation.</returns>
        Task DeleteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Renames the current object to the specified name.
        /// </summary>
        /// <param name="newName">The new name to assign to the object. Cannot be null or empty.</param>
        void Rename(string newName);

        /// <summary>
        /// Asynchronously renames the current item to the specified name.
        /// </summary>
        /// <param name="newName">The new name to assign to the item. Cannot be null or empty.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the rename operation.</param>
        /// <returns>A task that represents the asynchronous rename operation.</returns>
        Task RenameAsync(string newName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Calculates the recommended buffer size based on the current storage information.
        /// </summary>
        /// <returns>An integer representing the recommended buffer size.</returns>
        int GetBufferSize();

        /// <summary>
        /// Throws an <see cref="ObjectDisposedException"/> if this storage object has been disposed.
        /// </summary>
        /// <exception cref="ObjectDisposedException">Thrown if the object has already been disposed.</exception>
        void ThrowIfDisposed();
    }
}