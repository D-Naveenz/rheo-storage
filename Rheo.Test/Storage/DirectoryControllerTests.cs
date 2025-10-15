using Moq;
using Rheo.Storage;

namespace Rheo.Test.Storage
{
    public class DirectoryControllerTests : IDisposable
    {
        private const string TestDir = "TestDir";
        private const string SubDir = "SubDir";
        private const string TestFile = "file.txt";
        private const string TestFileContent = "Hello, World!";
        private readonly string _testDirPath;
        private readonly string _subDirPath;
        private readonly string _testFilePath;

        public DirectoryControllerTests()
        {
            _testDirPath = Path.Combine(Directory.GetCurrentDirectory(), TestDir);
            _subDirPath = Path.Combine(_testDirPath, SubDir);
            _testFilePath = Path.Combine(_testDirPath, TestFile);

            Directory.CreateDirectory(_testDirPath);
            Directory.CreateDirectory(_subDirPath);
            File.WriteAllText(_testFilePath, TestFileContent);
        }

        public void Dispose()
        {
            if (Directory.Exists(_testDirPath))
                Directory.Delete(_testDirPath, true);
        }

        private DirectoryController CreateController(string path = null)
            => new DirectoryController(path ?? _testDirPath);

        [Fact]
        public void CreatedAt_ReturnsDirectoryCreationTime()
        {
            var controller = CreateController();
            var expected = Directory.GetCreationTime(_testDirPath);
            Assert.Equal(expected, controller.CreatedAt);
        }

        [Fact]
        public void IsAvailable_ReturnsTrueIfDirectoryExists()
        {
            var controller = CreateController();
            Assert.True(controller.IsAvailable);
        }

        [Fact]
        public void GetFiles_ReturnsFilesInDirectory()
        {
            var controller = CreateController();
            var files = controller.GetFiles();
            Assert.Contains(files, f => f == _testFilePath);
        }

        [Fact]
        public void GetFiles_ThrowsIOExceptionForInvalidPattern()
        {
            var controller = CreateController();
            Assert.Throws<IOException>(() => controller.GetFiles("[invalid pattern]"));
        }

        [Fact]
        public void GetDirectories_ReturnsSubDirectories()
        {
            var controller = CreateController();
            var dirs = controller.GetDirectories();
            Assert.Contains(dirs, d => d == _subDirPath);
        }

        [Fact]
        public void GetDirectories_ThrowsIOExceptionForInvalidPattern()
        {
            var controller = CreateController();
            Assert.Throws<IOException>(() => controller.GetDirectories("[invalid pattern]"));
        }

        [Fact]
        public void GetFile_ReturnsFileControllerForExistingFile()
        {
            var controller = CreateController();
            var fileController = controller.GetFile(TestFile);
            Assert.True(fileController.IsAvailable);
        }

        [Fact]
        public void GetFile_ThrowsForAbsolutePath()
        {
            var controller = CreateController();
            Assert.Throws<ArgumentException>(() => controller.GetFile(Path.GetFullPath(TestFile)));
        }

        [Fact]
        public void GetFile_ThrowsForNonExistentFile()
        {
            var controller = CreateController();
            Assert.Throws<FileNotFoundException>(() => controller.GetFile("nonexistent.txt"));
        }

        [Fact]
        public void GetDirectory_ReturnsDirectoryControllerForExistingSubDir()
        {
            var controller = CreateController();
            var subDirController = controller.GetDirectory(SubDir);
            Assert.True(subDirController.IsAvailable);
        }

        [Fact]
        public void GetDirectory_ThrowsForAbsolutePath()
        {
            var controller = CreateController();
            Assert.Throws<ArgumentException>(() => controller.GetDirectory(Path.GetFullPath(SubDir)));
        }

        [Fact]
        public void GetDirectory_ThrowsForNonExistentDirectory()
        {
            var controller = CreateController();
            Assert.Throws<DirectoryNotFoundException>(() => controller.GetDirectory("nonexistent"));
        }

        [Fact]
        public void GetSize_ReturnsCorrectSizeInKB()
        {
            var controller = CreateController();
            var expected = (long)(TestFileContent.Length / 1024.0);
            Assert.Equal(expected, controller.GetSize(UOM.KB));
        }

        [Fact]
        public async Task CopyAsync_CopiesDirectoryToDestination_ReportsProgress()
        {
            var controller = CreateController();
            var destDir = _testDirPath + "_copy";
            if (Directory.Exists(destDir))
                Directory.Delete(destDir, true);

            var mockProgress = new Mock<IProgress<StorageProgress>>();
            StorageProgress? reportedProgress = null;
            mockProgress.Setup(p => p.Report(It.IsAny<StorageProgress>()))
                        .Callback<StorageProgress>(p => reportedProgress = p);

            await controller.CopyAsync(destDir, overwrite: true, progress: mockProgress.Object);

            Assert.True(Directory.Exists(destDir));
            Assert.True(File.Exists(Path.Combine(destDir, TestFile)));
            mockProgress.Verify(p => p.Report(It.IsAny<StorageProgress>()), Times.AtLeastOnce());

            Directory.Delete(destDir, true);
        }

        [Fact]
        public async Task DeleteAsync_DeletesDirectory()
        {
            var controller = CreateController();
            await controller.DeleteAsync();
            Assert.False(Directory.Exists(_testDirPath));
        }

        [Fact]
        public async Task MoveAsync_MovesDirectoryToDestination_ReportsProgress()
        {
            var controller = CreateController();
            var destDir = _testDirPath + "_moved";
            if (Directory.Exists(destDir))
                Directory.Delete(destDir, true);

            var mockProgress = new Mock<IProgress<StorageProgress>>();
            await controller.MoveAsync(destDir, overwrite: true, progress: mockProgress.Object);

            Assert.True(Directory.Exists(destDir));
            Assert.False(Directory.Exists(_testDirPath));
            mockProgress.Verify(p => p.Report(It.IsAny<StorageProgress>()), Times.AtLeastOnce());

            Directory.Delete(destDir, true);
        }

        [Fact]
        public async Task RenameAsync_RenamesDirectory()
        {
            var controller = CreateController();
            var newName = "RenamedDir";
            var parentDir = Path.GetDirectoryName(_testDirPath);
            var newPath = Path.Combine(parentDir, newName);

            if (Directory.Exists(newPath))
                Directory.Delete(newPath, true);

            await controller.RenameAsync(newName);

            Assert.True(Directory.Exists(newPath));
            Directory.Delete(newPath, true);
        }

        [Fact]
        public void ToString_ReturnsStringRepresentation()
        {
            var controller = CreateController();
            var result = controller.ToString();
            Assert.False(string.IsNullOrWhiteSpace(result));
        }
    }
}