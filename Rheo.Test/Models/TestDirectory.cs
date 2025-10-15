using IconTeX.Test.Models;
using Rheo.Storage;

namespace Rheo.Test.Models
{
    internal class TestDirectory : Dictionary<int, TestFile>, ITestModel<DirectoryController>
    {
        public DirectoryController Content { get; private set; }
        public string Name => Content.Name;
        public string OriginalPath { get; }
        public string? Operation { get; set; }
        public string? DestinationPath { get; set; }

        public TestDirectory(string dirPath)
        {
            Content = new DirectoryController(dirPath);
            OriginalPath = Content.FullPath;    // More reliable than 'dirPath'
        }

        public void Update(string operation, string newPath)
        {
            var newModel = new DirectoryController(newPath);
            Operation = operation;
            Content = newModel;

            if (operation.Equals("move", StringComparison.OrdinalIgnoreCase))
            {
                // Assume the directory name remains the same
                DestinationPath = newModel.ParentDirectory;
            }
            else if (operation.Equals("copy", StringComparison.OrdinalIgnoreCase))
            {
                // Assume the directory name remains the same
                DestinationPath = newModel.ParentDirectory;
            }
            else
            {
                DestinationPath = null;
            }
        }
    }
}
