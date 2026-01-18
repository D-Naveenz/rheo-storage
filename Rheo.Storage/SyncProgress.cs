using Rheo.Storage.Contracts;

namespace Rheo.Storage
{
    /// <summary>
    /// Provides a synchronous implementation of <see cref="IProgressCallback{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of progress update value.</typeparam>
    /// <remarks>
    /// This class wraps an <see cref="Action{T}"/> and invokes it synchronously when progress is reported.
    /// Unlike <see cref="Progress{T}"/> which posts callbacks to a synchronization context asynchronously,
    /// this implementation calls the callback immediately on the reporting thread, making it suitable for
    /// synchronous operations where immediate feedback is required.
    /// </remarks>
    public class SyncProgress<T> : IProgressCallback<T>
    {
        private readonly Action<T> _callback;

        /// <summary>
        /// Initializes a new instance of the <see cref="SyncProgress{T}"/> class.
        /// </summary>
        /// <param name="callback">The callback to invoke when progress is reported.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="callback"/> is null.</exception>
        public SyncProgress(Action<T> callback)
        {
            _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        }

        /// <inheritdoc/>
        public void Report(T value)
        {
            _callback(value);
        }
    }
}
