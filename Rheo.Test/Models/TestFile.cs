using Rheo.Storage;
using Rheo.Test.Models;
using System.Text;

namespace IconTeX.Test.Models
{
    internal class TestFile : ITestModel<FileController>
    {
        public int SampleNo { get; private set; }
        public FileController? Content { get; private set; }
        public string? Name => Content?.Name;
        public string OriginalPath { get; }
        public string? Operation { get; set; }
        public string? DestinationPath { get; set; }

        public TestFile(string rootPath, int sampleNo, string extention)
        {
            var filePath = Path.Combine(rootPath, $"sample-{sampleNo}{extention}");
            Content = new FileController(filePath);
            OriginalPath = Content.ParentDirectory;    // More reliable than 'filePath'
        }

        public void Update(string operation, string newPath)
        {
            var newDir = Path.GetDirectoryName(newPath);
            var newName = Path.GetFileName(newPath);
            var newModel = new FileController(
                Path.Combine(newDir ?? throw new InvalidOperationException("Directory name is null"), newName));

            Operation = operation;
            Content = newModel;
            
            if (operation.Equals("rename", StringComparison.OrdinalIgnoreCase))
            {
                SampleNo = GetSampleNo(newModel.Name);
            }
            else if (operation.Equals("move", StringComparison.OrdinalIgnoreCase))
            {
                // Assume the file name remains the same
                DestinationPath = newModel.ParentDirectory;
            }
            else if (operation.Equals("copy", StringComparison.OrdinalIgnoreCase))
            {
                // Assume the file name remains the same
                DestinationPath = newModel.ParentDirectory;
            }
            else
            {
                DestinationPath = null;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"[Sample-{SampleNo}] ");
            sb.Append($"File: {Name} ");
            if (!string.IsNullOrEmpty(Operation))
            {
                sb.Append($"| Operation: {Operation} ");
                if (Operation.Equals("rename", StringComparison.OrdinalIgnoreCase))
                {
                    sb.Append($"| New Name: {Name} ");
                }
                else if (Operation.Equals("move", StringComparison.OrdinalIgnoreCase) 
                    || Operation.Equals("copy", StringComparison.OrdinalIgnoreCase))
                {
                    sb.Append($"| Destination: {DestinationPath} ");
                }
            }
            return sb.ToString().TrimEnd();
        }

        private static int GetSampleNo(string fileName)
        {
            var name = Path.GetFileNameWithoutExtension(fileName);
            if (name.StartsWith("sample-", StringComparison.OrdinalIgnoreCase)
                && int.TryParse(name["sample-".Length..], out int no))
            {
                return no;
            }
            return -1;
        }
    }
}
