using Moq;
using Rheo.Storage.Test.Models;
using Rheo.Storage.Test.Utilities;

namespace Rheo.Storage.Test.IOOperations
{
    [Trait(TestTraits.Category, TestTraits.Storage)]
    [Trait(TestTraits.Feature, TestTraits.DirectoryController)]
    public class DirectoryControllerTests : IAsyncLifetime
    {
        private const string InvalidPattern = "\0";

        private TestDirectory _testDir = null!;
        private string _testDirPath = null!;
        private string _subDirPath = null!;
        private TestDirectory? _destDir;

        public async ValueTask InitializeAsync()
        {
            // Create directory for testing
            _testDir = TestDirectory.Create();
            _testDirPath = _testDir.FullPath;
            _subDirPath = Path.Combine(_testDir.FullPath, "SubDir");
            Directory.CreateDirectory(_subDirPath);

            // Create test files to add some content
            await _testDir.CreateTestFileAsync(ResourceType.Text);
            await _testDir.CreateTestFileAsync(ResourceType.Video);
            await _testDir.CreateTestFileAsync(ResourceType.Binary);

#if DEBUG
            // Open the folder in file explorer for debugging
            _testDir.OpenInFileBrowser();
#endif
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
        public void CreatedAt_ReturnsDirectoryCreationTime()
        {
            var controller = _testDir;
            var expected = Directory.GetCreationTime(_testDirPath);
            Assert.Equal(expected, controller.CreatedAt);
        }

        [Fact]
        public void IsAvailable_ReturnsTrueIfDirectoryExists()
        {
            var controller = _testDir;
            Assert.True(controller.IsAvailable);
        }

        [Fact]
        public void GetFiles_ReturnsFilesInDirectory()
        {
            var controller = _testDir;
            var files = controller.GetFiles();
            var topLevelFiles = files.Where(f => Path.GetDirectoryName(f) == _testDirPath);

            foreach (var testFile in topLevelFiles)
            {
                Assert.Contains(files, f => f == testFile);
            }
        }

        [Fact]
        public void GetFiles_ThrowsIOExceptionForInvalidPattern()
        {
            var controller = _testDir;
            Assert.Throws<IOException>(() => controller.GetFiles(InvalidPattern));
        }

        [Fact]
        public void GetDirectories_ReturnsSubDirectories()
        {
            var controller = _testDir;
            var dirs = controller.GetDirectories();
            Assert.Contains(dirs, d => d == _subDirPath);
        }

        [Fact]
        public void GetDirectories_ThrowsIOExceptionForInvalidPattern()
        {
            var controller = _testDir;
            Assert.Throws<IOException>(() => controller.GetDirectories(InvalidPattern));
        }

        [Fact]
        public void GetFile_ReturnsFileControllerForExistingFile()
        {
            var controller = _testDir;
            var fileController = controller.GetFile(Path.GetFileName(_testDir.TestFiles[0].FullPath));
            Assert.True(fileController.IsAvailable);
        }

        [Fact]
        public void GetFile_ThrowsForAbsolutePath()
        {
            var controller = _testDir;
            Assert.Throws<ArgumentException>(() => controller.GetFile(_testDir.TestFiles[0].FullPath));
        }

        [Fact]
        public void GetFile_ThrowsForNonExistentFile()
        {
            var controller = _testDir;
            Assert.Throws<FileNotFoundException>(() => controller.GetFile("nonexistent.txt"));
        }

        [Fact]
        public void GetDirectory_ReturnsDirectoryControllerForExistingSubDir()
        {
            var controller = _testDir;
            var dirController = controller.GetDirectory("SubDir");
            Assert.True(dirController.IsAvailable);
        }

        [Fact]
        public void GetDirectory_ThrowsForAbsolutePath()
        {
            var controller = _testDir;
            Assert.Throws<ArgumentException>(() => controller.GetDirectory(Path.GetFullPath(_subDirPath)));
        }

        [Fact]
        public void GetDirectory_ThrowsForNonExistentDirectory()
        {
            var controller = _testDir;
            Assert.Throws<DirectoryNotFoundException>(() => controller.GetDirectory("nonexistent"));
        }

        [Fact]
        public void GetSize_ReturnsCorrectSizeInKB()
        {
            var controller = _testDir;
            var DirectorySize = controller.GetSize(UOM.KB);
            var expectedSize = _testDir.TestFiles.Sum(f => f.GetSize(UOM.KB));
            Assert.Equal(expectedSize, DirectorySize);
        }

        [Fact]
        public async Task CopyAsync_CopiesDirectoryToDestination_ReportsProgress()
        {
            // Arrange
            var controller = _testDir;
            _destDir = TestDirectory.Create();
            var destDirPath = _destDir.FullPath;

            var mockProgress = new Mock<IProgress<StorageProgress>>();
            StorageProgress? reportedProgress = null;
            mockProgress.Setup(p => p.Report(It.IsAny<StorageProgress>()))
                        .Callback<StorageProgress>(p => reportedProgress = p);

            // Act
            await controller.CopyAsync(destDirPath, overwrite: true, progress: mockProgress.Object, cancellationToken: TestContext.Current.CancellationToken);

            // Assert
            Assert.True(_destDir.IsAvailable);
            Assert.True(_testDir.TestFiles[0].IsAvailable);
            mockProgress.Verify(p => p.Report(It.IsAny<StorageProgress>()), Times.AtLeastOnce());
        }

        [Fact]
        public async Task DeleteAsync_DeletesDirectory()
        {
            var controller = _testDir;
            await controller.DeleteAsync();
            Assert.False(Directory.Exists(_testDirPath));
        }

        [Fact]
        public async Task MoveAsync_MovesDirectoryToDestination_ReportsProgress()
        {
            // Arrange
            var controller = _testDir;
            _destDir = TestDirectory.Create();
            var destDirPath = _destDir.FullPath;

            var mockProgress = new Mock<IProgress<StorageProgress>>();

            // Act
            await controller.MoveAsync(destDirPath, overwrite: true, progress: mockProgress.Object, cancellationToken: TestContext.Current.CancellationToken);

            // Assert
            Assert.True(_destDir.IsAvailable);
            Assert.False(Directory.Exists(_testDirPath));
            mockProgress.Verify(p => p.Report(It.IsAny<StorageProgress>()), Times.AtLeastOnce());
        }

        [Fact]
        public async Task RenameAsync_RenamesDirectory()
        {
            // Arrange
            var controller = _testDir;
            var newName = "RenamedDir";
            var newPath = Path.Combine(controller.ParentDirectory, newName);

            if (Directory.Exists(newPath))
                Directory.Delete(newPath, true);

            // Act
            await controller.RenameAsync(newName);

            // Assert
            Assert.True(Directory.Exists(newPath));
        }

        [Fact]
        public void ToString_ReturnsStringRepresentation()
        {
            var controller = _testDir;
            var result = controller.ToString();
            Assert.False(string.IsNullOrWhiteSpace(result));
        }
    }
}