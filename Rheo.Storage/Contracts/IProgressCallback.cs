namespace Rheo.Storage.Contracts
{
    /// <summary>
    /// Defines a provider for synchronous progress updates.
    /// </summary>
    /// <typeparam name="T">The type of progress update value.</typeparam>
    /// <remarks>
    /// Unlike <see cref="IProgress{T}"/> which may post callbacks asynchronously to a synchronization context,
    /// this interface guarantees that the <see cref="Report"/> method will be called synchronously
    /// on the same thread that is reporting progress. This is particularly useful for synchronous operations
    /// where immediate feedback is required without the overhead of context switching.
    /// </remarks>
    public interface IProgressCallback<in T>
    {
        /// <summary>
        /// Reports a progress update synchronously.
        /// </summary>
        /// <param name="value">The value of the updated progress.</param>
        /// <remarks>
        /// This method is called synchronously and will block the reporting thread until the callback completes.
        /// Implementations should avoid long-running operations to prevent blocking the operation being monitored.
        /// </remarks>
        void Report(T value);
    }
}
