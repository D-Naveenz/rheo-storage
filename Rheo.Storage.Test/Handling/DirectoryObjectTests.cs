using Rheo.Storage.Test.Models;

namespace Rheo.Storage.Test.Handling;

[Trait(TestTraits.Feature, "DirectoryObject")]
[Trait(TestTraits.Category, "Storage Operations")]
public class DirectoryObjectTests(TestDirectoryFixture fixture) : IClassFixture<TestDirectoryFixture>
{
  private readonly TestDirectoryFixture _fixture = fixture;
  private TestDirectory TestDir => _fixture.TestDir;

    #region Constructor Tests

    [Fact]
  public void Constructor_WithValidPath_CreatesDirectory()
  {
    // Arrange
    var dirPath = Path.Combine(TestDir.FullPath, "test_dir");

    // Act
    using var dirObj = new DirectoryObject(dirPath);

    // Assert
    Assert.True(Directory.Exists(dirPath));
    Assert.Equal(dirPath, dirObj.FullPath);
  }

  [Fact]
  public void Constructor_WithNonExistentDirectory_CreatesDirectory()
  {
    // Arrange
    var dirPath = Path.Combine(TestDir.FullPath, "new_directory");

    // Act
    using var dirObj = new DirectoryObject(dirPath);

    // Assert
    Assert.True(Directory.Exists(dirPath));
  }

  [Fact]
  public void Constructor_WithFilePath_ThrowsArgumentException()
  {
    // Arrange
    var filePath = Path.Combine(TestDir.FullPath, "test_file.txt");
    File.WriteAllText(filePath, "test");

    // Act & Assert
    Assert.Throws<ArgumentException>(() => new DirectoryObject(filePath));
  }

  #endregion

  #region GetFiles Tests

  [Fact]
  public async Task GetFiles_ReturnsAllFiles()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("getfiles_test");
    await testDir.CreateTestFileAsync(ResourceType.Text, cancellationToken: TestContext.Current.CancellationToken);
    await testDir.CreateTestFileAsync(ResourceType.Binary, cancellationToken: TestContext.Current.CancellationToken);

    // Act
    var files = testDir.GetFiles();

    // Assert
    Assert.Equal(2, files.Length);
  }

  [Fact]
  public async Task GetFiles_WithSearchPattern_ReturnsMatchingFiles()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("getfiles_pattern_test");
    await testDir.CreateTestFileAsync(ResourceType.Text, cancellationToken: TestContext.Current.CancellationToken);
    File.WriteAllText(Path.Combine(testDir.FullPath, "test.log"), "log content");

    // Act
    var txtFiles = testDir.GetFiles("*.txt");

    // Assert
    Assert.Single(txtFiles);
  }

  [Fact]
  public async Task GetFiles_WithAllDirectories_ReturnsFilesFromSubdirectories()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("getfiles_recursive_test");
    await testDir.CreateTestFileAsync(ResourceType.Text, cancellationToken: TestContext.Current.CancellationToken);
    
    var subDir = testDir.CreateSubdirectory("sub");
    await subDir.CreateTestFileAsync(ResourceType.Binary, cancellationToken: TestContext.Current.CancellationToken);

    // Act
    var allFiles = testDir.GetFiles("*", SearchOption.AllDirectories);

    // Assert
    Assert.Equal(2, allFiles.Length);
  }

  #endregion

  #region GetFile Tests

  [Fact]
  public async Task GetFile_WithValidRelativePath_ReturnsFileObject()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("getfile_test");
    var testFile = await testDir.CreateTestFileAsync(ResourceType.Text, cancellationToken: TestContext.Current.CancellationToken);
    var relativePath = Path.GetFileName(testFile.FullPath);

    // Act
    using var fileObj = testDir.GetFile(relativePath);

    // Assert
    Assert.Equal(testFile.FullPath, fileObj.FullPath);
  }

  [Fact]
  public void GetFile_WithAbsolutePath_ThrowsArgumentException()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("getfile_absolute_test");
    var absolutePath = Path.Combine(TestDir.FullPath, "file.txt");

    // Act & Assert
    Assert.Throws<ArgumentException>(() => testDir.GetFile(absolutePath));
  }

  [Fact]
  public void GetFile_WithNonExistentFile_ThrowsFileNotFoundException()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("getfile_notfound_test");

    // Act & Assert
    Assert.Throws<FileNotFoundException>(() => testDir.GetFile("nonexistent.txt"));
  }

  #endregion

  #region GetDirectories Tests

  [Fact]
  public void GetDirectories_ReturnsAllSubdirectories()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("getdirs_test");
    testDir.CreateSubdirectory("sub1");
    testDir.CreateSubdirectory("sub2");

    // Act
    var dirs = testDir.GetDirectories();

    // Assert
    Assert.Equal(2, dirs.Length);
  }

  [Fact]
  public void GetDirectories_WithSearchPattern_ReturnsMatchingDirectories()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("getdirs_pattern_test");
    testDir.CreateSubdirectory("test_dir");
    testDir.CreateSubdirectory("other_dir");

    // Act
    var testDirs = testDir.GetDirectories("test_*");

    // Assert
    Assert.Single(testDirs);
  }

  #endregion

  #region GetDirectory Tests

  [Fact]
  public void GetDirectory_WithValidRelativePath_ReturnsDirectoryObject()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("getdir_test");
    var subDir = testDir.CreateSubdirectory("sub");
    var relativePath = Path.GetFileName(subDir.FullPath);

    // Act
    using var dirObj = testDir.GetDirectory(relativePath);

    // Assert
    Assert.Equal(subDir.FullPath, dirObj.FullPath);
  }

  [Fact]
  public void GetDirectory_WithAbsolutePath_ThrowsArgumentException()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("getdir_absolute_test");
    var absolutePath = Path.Combine(TestDir.FullPath, "dir");

    // Act & Assert
    Assert.Throws<ArgumentException>(() => testDir.GetDirectory(absolutePath));
  }

  [Fact]
  public void GetDirectory_WithNonExistentDirectory_ThrowsDirectoryNotFoundException()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("getdir_notfound_test");

    // Act & Assert
    Assert.Throws<DirectoryNotFoundException>(() => testDir.GetDirectory("nonexistent"));
  }

  #endregion

  #region Copy Tests

  [Fact]
  public async Task Copy_WithValidDestination_CopiesDirectory()
  {
    // Arrange
    var sourceDir = TestDir.CreateSubdirectory("copy_source");
    await sourceDir.CreateTestFileAsync(ResourceType.Text, cancellationToken: TestContext.Current.CancellationToken);
    var subDir = sourceDir.CreateSubdirectory("sub");
    await subDir.CreateTestFileAsync(ResourceType.Binary, cancellationToken: TestContext.Current.CancellationToken);

    var destParent = TestDir.CreateSubdirectory("copy_dest_parent");

    // Act
    using var copiedDir = sourceDir.Copy(destParent.FullPath, overwrite: false);

    // Assert
    Assert.True(Directory.Exists(copiedDir.FullPath));
    Assert.Equal(2, copiedDir.GetFiles("*", SearchOption.AllDirectories).Length);
  }

  [Fact]
  public async Task Copy_PreservesEmptyDirectories()
  {
    // Arrange
    var sourceDir = TestDir.CreateSubdirectory("copy_empty_source");
    sourceDir.CreateSubdirectory("empty_sub");
    await sourceDir.CreateTestFileAsync(ResourceType.Text, cancellationToken: TestContext.Current.CancellationToken);

    var destParent = TestDir.CreateSubdirectory("copy_empty_dest");

    // Act
    using var copiedDir = sourceDir.Copy(destParent.FullPath, overwrite: false);

    // Assert
    Assert.Single(copiedDir.GetDirectories());
  }

  [Fact]
  public async Task Copy_WithProgress_ReportsProgress()
  {
    // Arrange
    var sourceDir = TestDir.CreateSubdirectory("copy_progress_source");
    await sourceDir.CreateTestFileAsync(ResourceType.Image, cancellationToken: TestContext.Current.CancellationToken);
    await sourceDir.CreateTestFileAsync(ResourceType.Document, cancellationToken: TestContext.Current.CancellationToken);

    var destParent = TestDir.CreateSubdirectory("copy_progress_dest");
    var progressReports = new List<StorageProgress>();
    var progress = new Progress<StorageProgress>(p => progressReports.Add(p));

    // Act
    using var copiedDir = sourceDir.Copy(destParent.FullPath, progress, overwrite: false);

    // Assert
    Assert.NotEmpty(progressReports);
  }

  [Fact]
  public async Task CopyAsync_WithValidDestination_CopiesDirectory()
  {
    // Arrange
    var sourceDir = TestDir.CreateSubdirectory("copy_async_source");
    await sourceDir.CreateTestFileAsync(ResourceType.Text, cancellationToken: TestContext.Current.CancellationToken);
    await sourceDir.CreateTestFileAsync(ResourceType.Binary, cancellationToken: TestContext.Current.CancellationToken);

    var destParent = TestDir.CreateSubdirectory("copy_async_dest");

    // Act
    using var copiedDir = await sourceDir.CopyAsync(destParent.FullPath, overwrite: false, cancellationToken: TestContext.Current.CancellationToken);

    // Assert
    Assert.True(Directory.Exists(copiedDir.FullPath));
    Assert.Equal(2, copiedDir.GetFiles().Length);
  }

  #endregion

  #region Move Tests

  [Fact]
  public async Task Move_WithValidDestination_MovesDirectory()
  {
    // Arrange
    var sourceDir = TestDir.CreateSubdirectory("move_source");
    await sourceDir.CreateTestFileAsync(ResourceType.Text, cancellationToken: TestContext.Current.CancellationToken);
    var originalPath = sourceDir.FullPath;

    var destParent = TestDir.CreateSubdirectory("move_dest_parent");

    // Act
    using var movedDir = sourceDir.Move(destParent.FullPath, overwrite: false);

    // Assert
    Assert.False(Directory.Exists(originalPath));
    Assert.True(Directory.Exists(movedDir.FullPath));
  }

  [Fact]
  public async Task Move_SameVolume_PerformsQuickMove()
  {
    // Arrange
    var sourceDir = TestDir.CreateSubdirectory("move_same_source");
    await sourceDir.CreateTestFileAsync(ResourceType.Binary, cancellationToken: TestContext.Current.CancellationToken);
    
    var destParent = TestDir.CreateSubdirectory("move_same_dest");
    var progressReports = new List<StorageProgress>();
    var progress = new Progress<StorageProgress>(p => progressReports.Add(p));

    // Act
    using var movedDir = sourceDir.Move(destParent.FullPath, progress, overwrite: false);

    // Assert
    Assert.True(Directory.Exists(movedDir.FullPath));
    Assert.Single(progressReports); // Same volume should report single update
  }

  [Fact]
  public async Task MoveAsync_WithValidDestination_MovesDirectory()
  {
    // Arrange
    var sourceDir = TestDir.CreateSubdirectory("move_async_source");
    await sourceDir.CreateTestFileAsync(ResourceType.Image, cancellationToken: TestContext.Current.CancellationToken);
    var originalPath = sourceDir.FullPath;

    var destParent = TestDir.CreateSubdirectory("move_async_dest");

    // Act
    using var movedDir = await sourceDir.MoveAsync(destParent.FullPath, overwrite: false, cancellationToken: TestContext.Current.CancellationToken);

    // Assert
    Assert.False(Directory.Exists(originalPath));
    Assert.True(Directory.Exists(movedDir.FullPath));
  }

  #endregion

  #region Delete Tests

  [Fact]
  public async Task Delete_RemovesDirectory()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("delete_test");
    await testDir.CreateTestFileAsync(ResourceType.Text, cancellationToken: TestContext.Current.CancellationToken);
    var dirPath = testDir.FullPath;

    // Act
    testDir.Delete();

    // Assert
    Assert.False(Directory.Exists(dirPath));
  }

  [Fact]
  public async Task DeleteAsync_RemovesDirectory()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("delete_async_test");
    await testDir.CreateTestFileAsync(ResourceType.Binary, cancellationToken: TestContext.Current.CancellationToken);
    var dirPath = testDir.FullPath;

    // Act
    await testDir.DeleteAsync(cancellationToken: TestContext.Current.CancellationToken);

    // Assert
    Assert.False(Directory.Exists(dirPath));
  }

  #endregion

  #region Rename Tests

  [Fact]
  public void Rename_WithValidName_RenamesDirectory()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("rename_source");
    var originalPath = testDir.FullPath;
    var newName = "renamed_dir";

    // Act
    testDir.Rename(newName);

    // Assert
    Assert.False(Directory.Exists(originalPath));
    Assert.True(Directory.Exists(Path.Combine(TestDir.FullPath, newName)));
    Assert.Equal(newName, testDir.Name);
  }

  [Theory]
  [InlineData("")]
  [InlineData(null)]
  [InlineData("   ")]
  [InlineData("invalid<>name")]
  [InlineData("invalid|name")]
  public void Rename_WithInvalidName_ThrowsArgumentException(string invalidName)
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("rename_invalid");

    // Act & Assert
    Assert.Throws<ArgumentException>(() => testDir.Rename(invalidName));
  }

  [Fact]
  public async Task RenameAsync_WithValidName_RenamesDirectory()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("rename_async_source");
    var originalPath = testDir.FullPath;
    var newName = "renamed_async_dir";

    // Act
    await testDir.RenameAsync(newName, cancellationToken: TestContext.Current.CancellationToken);

    // Assert
    Assert.False(Directory.Exists(originalPath));
    Assert.True(Directory.Exists(Path.Combine(TestDir.FullPath, newName)));
    Assert.Equal(newName, testDir.Name);
  }

  #endregion

  #region Property Tests

  [Fact]
  public void Name_ReturnsDirectoryName()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("name_test");

    // Act
    var name = testDir.Name;

    // Assert
    Assert.Equal(Path.GetFileName(testDir.FullPath), name);
  }

  [Fact]
  public async Task Information_ReturnsDirectoryInformation()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("info_test");
    await testDir.CreateTestFileAsync(ResourceType.Image, cancellationToken: TestContext.Current.CancellationToken);

    // Act
    var info = testDir.Information;

    // Assert
    Assert.NotNull(info);
    Assert.True(info.Size > 0);
  }

  #endregion

  #region FileSystemWatcher Tests

  [Fact]
  public async Task FileSystemWatcher_DetectsFileChanges()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("watcher_test");
    var initialInfo = testDir.Information;
    
    // Wait for watcher to stabilize
    await Task.Delay(100);

    // Act
    await testDir.CreateTestFileAsync(ResourceType.Text, cancellationToken: TestContext.Current.CancellationToken);
    
    // Wait for debounce timer (2 seconds as per DirectoryObject implementation)
    await Task.Delay(2500);

    // Assert
    var updatedInfo = testDir.Information;
    Assert.NotEqual(initialInfo.Size, updatedInfo.Size);
  }

  #endregion

  #region Disposal Tests

  [Fact]
  public void Dispose_DisposesObject()
  {
    // Arrange
    var testDir = TestDir.CreateSubdirectory("dispose_test");

    // Act
    testDir.Dispose();

    // Assert
    Assert.Throws<ObjectDisposedException>(() => testDir.Copy(TestDir.FullPath, overwrite: false));
  }

  #endregion
}