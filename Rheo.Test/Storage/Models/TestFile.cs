using Rheo.Storage;
using Rheo.Test.Properties;
using System.Text;

namespace Rheo.Test.Storage.Models
{
    /// <summary>
    /// Represents a test file that supports various resource types and provides functionality for creating, updating,
    /// and managing storage records.
    /// </summary>
    /// <remarks>A <see cref="TestFile"/> instance encapsulates a file created for testing purposes, with
    /// support for different resource types such as text, images, binary data, documents, and videos. It maintains a
    /// collection of storage records and provides metadata such as the timestamp of the last record.</remarks>
    internal class TestFile : FileController, ITestStorage
    {
        private TestFile(string fileNameOrPath) : base(fileNameOrPath)
        {
        }

        public List<StorageRecord> StorageRecords { get; } = [];

        public DateTimeOffset LastRecordTime => StorageRecords.Count > 0 ? StorageRecords[^1].Timestamp : DateTimeOffset.MinValue;

        /// <summary>
        /// Creates a test file of the specified resource type in the given directory.
        /// </summary>
        /// <remarks>The content and file extension of the created file depend on the specified <paramref
        /// name="resourceType"/>: <list type="bullet"> <item><description><see cref="ResourceType.Text"/>: A plain text
        /// file with sample content.</description></item> <item><description><see cref="ResourceType.Image"/>: A small
        /// PNG image.</description></item> <item><description><see cref="ResourceType.Binary"/>: A binary file with
        /// predefined data.</description></item> <item><description><see cref="ResourceType.Document"/>: A document
        /// file with predefined content.</description></item> <item><description><see cref="ResourceType.Video"/>: A
        /// video file with predefined content.</description></item> </list></remarks>
        /// <param name="resourceType">The type of resource to create. This determines the content and file extension of the test file.</param>
        /// <param name="directory">The directory in which the test file will be created. The directory must exist and be writable.</param>
        /// <returns>A <see cref="TestFile"/> instance representing the created file, including its full path.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="resourceType"/> is not a valid <see cref="ResourceType"/> value.</exception>
        public static TestFile Create(ResourceType resourceType, TestDirectory directory)
        {
            var directoryPath = directory.FullPath;
            byte[] resourceBytes;
            string fileExtension;

            switch (resourceType)
            {
                case ResourceType.Text:
                    resourceBytes = Encoding.UTF8.GetBytes("This is a sample text file for testing purposes.");
                    fileExtension = ".txt";
                    break;
                case ResourceType.Image:
                    // A small red dot PNG image in byte array form
                    resourceBytes = Convert.FromBase64String(
                        "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/wcAAwAB/6XK" +
                        "pAAAAABJRU5ErkJggg==");
                    fileExtension = ".png";
                    break;
                case ResourceType.Binary:
                    resourceBytes = [0x00, 0xFF, 0x7A, 0x3C, 0x5D, 0xA1];
                    fileExtension = ".bin";
                    break;
                case ResourceType.Document:
                    resourceBytes = Resources.TestData_Document;
                    fileExtension = Resources.TestData_Document_Extension;
                    break;
                case ResourceType.Video:
                    resourceBytes = Resources.TestData_Video;
                    fileExtension = Resources.TestData_Video_Extension;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(resourceType), resourceType, null);
            }

            var fileName = $"Test{resourceType}{fileExtension}";
            var fullPath = Path.Combine(directoryPath, fileName);

            // Write the resource bytes to the file
            File.WriteAllBytes(fullPath, resourceBytes);

            // Create and return the TestFile instance
            return new TestFile(fullPath);
        }

        public void Update(OperationType operation)
        {
            StorageRecords.Add(new StorageRecord(this, operation));
        }
    }
}
