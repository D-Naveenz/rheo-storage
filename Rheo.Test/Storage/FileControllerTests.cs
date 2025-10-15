using Moq;
using Rheo.Storage;

namespace Rheo.Test.Storage
{
    public class FileControllerTests
    {
        private const string TestFilePath = "testfile.txt";
        private const string TestDirectory = "TestDir";
        private const string RenamedFile = "renamed.txt";

        private static FileController CreateController(string filePath = TestFilePath, bool isInfoRequired = true)
        {
            // Create a dummy file for testing
            if (!File.Exists(filePath))
                File.WriteAllText(filePath, "Test content");

            return new FileController(filePath, isInfoRequired);
        }

        [Fact]
        public void CreatedAt_ReturnsFileCreationTime()
        {
            var controller = CreateController();
            var expected = File.GetCreationTime(TestFilePath);
            Assert.Equal(expected, controller.CreatedAt);
        }

        [Fact]
        public void Extension_ReturnsFileExtension()
        {
            var controller = CreateController();
            Assert.Equal(".txt", controller.Extension);
        }

        [Fact]
        public void IsAvailable_ReturnsTrueIfFileExists()
        {
            var controller = CreateController();
            Assert.True(controller.IsAvailable);
        }

        [Fact]
        public void GetSize_ReturnsCorrectSizeInKB()
        {
            var controller = CreateController();
            var expected = (long)(new FileInfo(TestFilePath).Length / Math.Pow(1024, 1));
            Assert.Equal(expected, controller.GetSize(UOM.KB));
        }

        [Fact]
        public async Task CopyAsync_CopiesFileToDestination()
        {
            var controller = CreateController();
            var destDir = TestDirectory;
            Directory.CreateDirectory(destDir);

            var destPath = Path.Combine(destDir, TestFilePath);
            if (File.Exists(destPath))
                File.Delete(destPath);

            await controller.CopyAsync(destDir, overwrite: true);

            Assert.True(File.Exists(destPath));
            File.Delete(destPath);
            Directory.Delete(destDir);
        }

        [Fact]
        public async Task DeleteAsync_DeletesFile()
        {
            var controller = CreateController();
            await controller.DeleteAsync();
            Assert.False(File.Exists(TestFilePath));
        }

        [Fact]
        public async Task MoveAsync_MovesFileToDestination()
        {
            var controller = CreateController();
            var destDir = TestDirectory;
            Directory.CreateDirectory(destDir);

            var destPath = Path.Combine(destDir, TestFilePath);
            if (File.Exists(destPath))
                File.Delete(destPath);

            await controller.MoveAsync(destDir, overwrite: true);

            Assert.True(File.Exists(destPath));
            Assert.False(File.Exists(TestFilePath));
            File.Delete(destPath);
            Directory.Delete(destDir);
        }

        [Fact]
        public async Task RenameAsync_RenamesFile()
        {
            var controller = CreateController();
            var newName = RenamedFile;
            var newPath = Path.Combine(Path.GetDirectoryName(TestFilePath) ?? ".", newName);

            if (File.Exists(newPath))
                File.Delete(newPath);

            await controller.RenameAsync(newName);

            Assert.True(File.Exists(newPath));
            File.Delete(newPath);
        }

        [Fact]
        public void ToString_ReturnsStringRepresentation()
        {
            var controller = CreateController();
            var result = controller.ToString();
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public async Task CopyAsync_ReportsProgress()
        {
            // Arrange
            var testFile = "mockfile.txt";
            File.WriteAllText(testFile, "Mock content");
            var controller = new FileController(testFile);

            var mockProgress = new Mock<IProgress<StorageProgress>>();
            StorageProgress? reportedProgress = null;
            mockProgress.Setup(p => p.Report(It.IsAny<StorageProgress>()))
                        .Callback<StorageProgress>(p => reportedProgress = p);

            var destDir = "MockDest";
            Directory.CreateDirectory(destDir);

            // Act
            await controller.CopyAsync(destDir, overwrite: true, progress: mockProgress.Object);

            // Assert
            mockProgress.Verify(p => p.Report(It.IsAny<StorageProgress>()), Times.AtLeastOnce());
            Assert.NotNull(reportedProgress);

            // Cleanup
            var destPath = Path.Combine(destDir, testFile);
            File.Delete(testFile);
            File.Delete(destPath);
            Directory.Delete(destDir);
        }
    }
}