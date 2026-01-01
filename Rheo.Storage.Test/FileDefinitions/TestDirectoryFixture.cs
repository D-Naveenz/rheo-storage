using Rheo.Storage.Test.Models;

namespace Rheo.Storage.Test.FileDefinitions
{
    public class TestDirectoryFixture : IDisposable
    {
        public TestDirectory TestDir { get; }

        public TestDirectoryFixture()
        {
            TestDir = TestDirectory.Create();

#if DEBUG
            // Open the folder in file explorer for debugging
            TestDir.OpenInFileBrowser();
#endif
        }

        public void Dispose()
        {
            TestDir.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
