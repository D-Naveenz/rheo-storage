using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rheo.Storage.DefinitionsBuilder.Generation
{
    /// <summary>
    /// Provides a mechanism for reporting progress synchronously using a specified handler.
    /// </summary>
    /// <remarks>This implementation of <see cref="IProgress{T}"/> invokes the provided handler directly and
    /// synchronously when <see cref="Report(T)"/> is called. It does not perform any asynchronous dispatch, making it
    /// suitable for scenarios where immediate execution is required.</remarks>
    /// <typeparam name="T">The type of the progress value.</typeparam>
    /// <param name="handler"></param>
    internal class SynchronousProgress<T>(Action<T> handler) : IProgress<T>
    {
        private readonly Action<T> _handler = handler ?? throw new ArgumentNullException(nameof(handler));

        public void Report(T value)
        {
            // Direct synchronous call — no async dispatch
            _handler(value);
        }
    }
}
