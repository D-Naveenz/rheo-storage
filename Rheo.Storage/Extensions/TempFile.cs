using Rheo.Storage.Information;

namespace Rheo.Storage.Extensions
{
    /// <summary>
    /// Represents a temporary file used for test execution, providing methods to write data and manage file lifecycle
    /// within a test directory.
    /// </summary>
    /// <remarks>The TempFile class is intended for scenarios where temporary file management is required
    /// during testing. It offers both synchronous and asynchronous methods for writing data, and ensures integration
    /// with a designated test directory. Instances of TempFile are typically used in conjunction with TempDirectory to
    /// facilitate cleanup and isolation of test artifacts.</remarks>
    public class TempFile : FileObject
    {
        /// <summary>
        /// Initializes a new instance of the TempFile class for the specified file path.
        /// </summary>
        /// <param name="filePath">The full path of the file to be managed as a temporary file. Cannot be null or empty.</param>
        public TempFile(string filePath) : base(filePath)
        {
        }

        internal TempFile(FileInformation information) : base(information)
        {
        }


        /// <summary>
        /// Gets the test directory used for storing and accessing test files during execution.
        /// </summary>
        public TempDirectory TestDirectory { get; init; } = null!;

        /// <summary>
        /// Asynchronously writes the specified byte array to storage.
        /// </summary>
        /// <param name="content">The byte array containing the data to write. Cannot be null.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the write operation.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteAsync(byte[] content, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(content);

            using var memoryStream = new MemoryStream(content);
            await WriteAsync(memoryStream, cancellationToken);
        }

        /// <summary>
        /// Writes the specified byte array to the target destination, optionally overwriting any existing content.
        /// </summary>
        /// <param name="content">The byte array containing the data to write. Cannot be null.</param>
        public void Write(byte[] content)
        {
            ArgumentNullException.ThrowIfNull(content);

            using var memoryStream = new MemoryStream(content);
            Write(memoryStream);
        }
    }
}
