using Moq;
using Rheo.Storage.Test.Models;
using Rheo.Storage.Test.Utilities;

namespace Rheo.Storage.Test.IOOperations
{
    [Trait(TestTraits.Category, TestTraits.Storage)]
    [Trait(TestTraits.Feature, TestTraits.FileController)]
    public class FileControllerTests : IAsyncLifetime
    {
        private TestDirectory _testDir = null!;
        private TestFile _testFile = null!;
        private string _testFilePath = null!;
        private TestDirectory? _destDir;

        public async ValueTask InitializeAsync()
        {
            // Create test storages
            _testDir = TestDirectory.Create();
            _testFile = await _testDir.CreateTestFileAsync(ResourceType.Text, TestContext.Current.CancellationToken);
            _testFilePath = _testFile.FullPath;
        }

        public ValueTask DisposeAsync()
        {
            // Cleanup test storages
            _destDir?.Dispose();
            _testDir?.Dispose();
            GC.SuppressFinalize(this);
            return ValueTask.CompletedTask;
        }

        [Fact]
        public void CreatedAt_ReturnsFileCreationTime()
        {
            var controller = _testFile;
            var expected = File.GetCreationTime(_testFile.FullPath);
            Assert.Equal(expected, controller.CreatedAt);
        }

        [Fact]
        public void Extension_ReturnsFileExtension()
        {
            var controller = _testFile;
            Assert.Equal(".txt", controller.Extension);
        }

        [Fact]
        public void IsAvailable_ReturnsTrueIfFileExists()
        {
            var controller = _testFile;
            Assert.True(controller.IsAvailable);
        }

        [Fact]
        public void GetSize_ReturnsCorrectSizeInKB()
        {
            var controller = _testFile;
            var expected = (long)(new FileInfo(_testFilePath).Length / Math.Pow(1024, 1));
            Assert.Equal(expected, controller.GetSize(UOM.KB));
        }

        [Fact]
        public async Task CopyAsync_CopiesFileToDestination()
        {
            var controller = _testFile;
            _destDir = TestDirectory.Create();
            var destDirPath = _destDir.FullPath;
            var destFilePath = Path.Combine(destDirPath, controller.Name);

            if (File.Exists(destFilePath))
                File.Delete(destFilePath);

            await controller.CopyAsync(destDirPath, overwrite: true, cancellationToken: TestContext.Current.CancellationToken);

            Assert.True(File.Exists(destFilePath));
        }

        [Fact]
        public async Task DeleteAsync_DeletesFile()
        {
            var controller = _testFile;
            await controller.DeleteAsync();
            Assert.False(File.Exists(_testFilePath));
        }

        [Fact]
        public async Task MoveAsync_MovesFileToDestination()
        {
            var controller = _testFile;
            _destDir = TestDirectory.Create();
            var destDirPath = _destDir.FullPath;
            var destFilePath = Path.Combine(destDirPath, controller.Name);

            if (File.Exists(destFilePath))
                File.Delete(destFilePath);

            await controller.MoveAsync(destDirPath, overwrite: true, cancellationToken: TestContext.Current.CancellationToken);

            Assert.True(File.Exists(destFilePath));
            Assert.False(File.Exists(_testFilePath));
        }

        [Fact]
        public async Task RenameAsync_RenamesFile()
        {
            var controller = _testFile;
            var newName = $"renamed_{controller.Name}";
            var newPath = Path.Combine(controller.ParentDirectory, newName);

            if (File.Exists(newPath))
                File.Delete(newPath);

            await controller.RenameAsync(newName);

            Assert.True(File.Exists(newPath));
        }

        [Fact]
        public void ToString_ReturnsStringRepresentation()
        {
            var controller = _testFile;
            var result = controller.ToString();
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public async Task CopyAsync_ReportsProgress()
        {
            // Arrange
            var controller = _testFile;
            _destDir = TestDirectory.Create();
            var destDirPath = _destDir.FullPath;
            var destFilePath = Path.Combine(destDirPath, controller.Name);

            var mockProgress = new Mock<IProgress<StorageProgress>>();
            StorageProgress? reportedProgress = null;
            mockProgress.Setup(p => p.Report(It.IsAny<StorageProgress>()))
                        .Callback<StorageProgress>(p => reportedProgress = p);

            // Act
            await controller.CopyAsync(destDirPath, overwrite: true, progress: mockProgress.Object, cancellationToken: TestContext.Current.CancellationToken);

            // Assert
            mockProgress.Verify(p => p.Report(It.IsAny<StorageProgress>()), Times.AtLeastOnce());
            Assert.NotNull(reportedProgress);
        }
    }
}