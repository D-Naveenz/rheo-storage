using MessagePack;
using Rheo.Storage.DefinitionsBuilder.Models.Definition;
using Rheo.Storage.DefinitionsBuilder.Models.Package;
using Rheo.Storage.DefinitionsBuilder.RIFF;
using Rheo.Storage.DefinitionsBuilder.RIFF.Models;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rheo.Storage.DefinitionsBuilder
{
    public class PackageCompiler
    {
        private const string TrIDLocation = @"Data";
        private const string ScriptName = "trid.py";
        private const string PackageName = "triddefs.trd";
        private const string OutputJson = "filedefs.metadata.json";
        private const string OutputPackage = "filedefs.dat";

        private readonly string _tridVersion;
        private readonly string _packagePath;

        public Dictionary<int, List<TrIDDefinition>> Block { get; }
        public Metadata CollectionMetadata { get; private set; } = new();
        public List<Definition> Definitions { get; private set; } = [];

        public PackageCompiler()
        {
            // Verify paths
            var errormessage = "Couldn't find the TrID - File Identifier or the data package in the Data Folder.";
            var scriptPath = Path.GetFullPath(Path.Combine(TrIDLocation, ScriptName));
            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException(errormessage, ScriptName);
            }
            _packagePath = Path.GetFullPath(Path.Combine(TrIDLocation, PackageName));
            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException(errormessage, PackageName);
            }

            // Configure metadata
            _tridVersion = GetTrIDVersion(scriptPath);

            // Parse TrID package
            Block = TridPackageParser.ParsePackage(_packagePath);

            Console.WriteLine("TrID Package Detected. Version: {0}", _tridVersion);
        }

        public void Compile(string? outputPath = null)
        {
            // Validate output path
            if (string.IsNullOrWhiteSpace(outputPath))
            {
                outputPath = Directory.GetCurrentDirectory();
            }
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            // Build
            BuildDefinitions(Block);

            // Compile
            ExportToJson(outputPath);
            ExportToBinary(outputPath);
        }

        private void BuildDefinitions(Dictionary<int, List<TrIDDefinition>> definitionsBlock)
        {
            // Flatten all definitions
            var allDefinitions = definitionsBlock
                .SelectMany(kvp => kvp.Value)
                .Where(d => !string.IsNullOrEmpty(d.MimeType))
                .ToList();

            // Build the definition collection
            Definitions = [.. allDefinitions
                .Select(trid => new Definition
                {
                    FileType = trid.FileType,
                    Extension = trid.Extension,
                    MimeType = trid.MimeType,
                    Remarks = trid.Remarks,
                    Signature = new Signature
                    {
                        Patterns = trid.Patterns,
                        Strings = trid.Strings,
                    },
                    PriorityLevel = CalculatePriority(trid)
                })
                .OrderByDescending(d => d.PriorityLevel)];

            var packageVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
            var categories = BuildCategories(Definitions);

            // Build package metadata
            CollectionMetadata = new Metadata
            {
                DefinitionsInfo = new TrIDInfo
                {
                    TotalRecords = allDefinitions.Count,
                    Version = _tridVersion
                },
                PackageInfo = new PackageInfo
                {
                    Version = packageVersion ?? "1.0",
                    CreatedAt = DateTime.UtcNow,
                    TotalDefinitions = Definitions.Count,
                },
                Categories = categories
            };
        }

        private static List<string> BuildCategories(List<Definition> definitions)
        {
            return [.. definitions
                .Select(d => d.MimeType.ToLower().Split('/')[0])
                .Distinct()];
        }

        private static int CalculatePriority(TrIDDefinition definition)
        {
            int priority = 0;

            // Higher priority for definitions with patterns at position 0
            if (definition.Patterns.Any(p => p.Position == 0))
                priority += 100;

            // Priority based on number of files used to create definition
            priority += Math.Min(definition.FileCount / 100, 50);

            // Priority based on pattern count
            priority += definition.Patterns.Count * 10;

            return priority;
        }

        private static string GetTrIDVersion(string trIdPath)
        {
            var fileContent = File.ReadAllText(trIdPath);
            // Parse PROGRAM_VER python variable
            var varName = "PROGRAM_VER";
            var searchPattern = $"{varName} = \"";

            var extractedValue = string.Empty;
            var startIndex = fileContent.IndexOf(searchPattern);

            if (startIndex > -1)
            {
                // Move past the variable name and opening quote
                startIndex += searchPattern.Length;
                // Find the closing quote
                var endIndex = fileContent.IndexOf('"', startIndex);

                if (endIndex > -1)
                {
                    extractedValue = fileContent[startIndex..endIndex];
                }
            }

            return extractedValue;
        }

        private void ExportToJson(string outputPath)
        {
            outputPath = Path.Combine(outputPath, OutputJson);

            var json = JsonSerializer.Serialize(CollectionMetadata, PackageMetadataJsonContext.Default.Metadata);
            File.WriteAllText(outputPath, json);

            Console.WriteLine("Package metadata has been created in {0}", OutputJson);
        }

        private void ExportToBinary(string outputPath)
        {
            outputPath = Path.Combine(outputPath, OutputPackage);

            var package = MessagePackSerializer.Serialize(Definitions);
            File.WriteAllBytes(outputPath, package);
            
            Console.WriteLine("Package has been exported to {0}", OutputPackage);
        }
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Metadata))]
    internal partial class PackageMetadataJsonContext : JsonSerializerContext
    {
    }
}
