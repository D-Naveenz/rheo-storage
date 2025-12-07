using MessagePack;
using Rheo.Storage.DefinitionsBuilder.Generation;
using Rheo.Storage.DefinitionsBuilder.Models.Definition;
using Rheo.Storage.DefinitionsBuilder.Models.Package;
using Rheo.Storage.DefinitionsBuilder.RIFF;
using Rheo.Storage.DefinitionsBuilder.RIFF.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rheo.Storage.DefinitionsBuilder
{
    public class PackageCompiler
    {
        private readonly string _tridVersion;
        private readonly string _packagePath;

        public Dictionary<int, List<TrIDDefinition>> Block { get; }

        public PackageCompiler()
        {
            // Verify paths
            var errormessage = "Couldn't find the TrID - File Identifier or the data package in the Data Folder.";
            var scriptPath = Path.GetFullPath(Path.Combine(Configuration.TridLocation, Configuration.TRID_SCRIPT_NAME));
            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException(errormessage, Configuration.TRID_SCRIPT_NAME);
            }
            _packagePath = Path.GetFullPath(Path.Combine(Configuration.TridLocation, Configuration.TRID_PACKAGE_NAME));
            if (!File.Exists(_packagePath))
            {
                throw new FileNotFoundException(errormessage, Configuration.TRID_PACKAGE_NAME);
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
            var definitions = BuildDefinitions(Block, outputPath);

            // Build package metadata
            var metadata = new Metadata
            {
                Source = new TrIDInfo
                {
                    TotalRecords = Block.Sum(kvp => kvp.Value.Count),
                    Version = _tridVersion
                },
                Package = new PackageInfo
                {
                    Version = Configuration.Version,
                    CreatedAt = DateTime.UtcNow,
                    TotalDefinitions = definitions.Count,
                }
            };

            // Compile
            ExportToJson(metadata, outputPath);
            ExportToBinary(definitions, outputPath);
        }

        private static List<Definition> BuildDefinitions(Dictionary<int, List<TrIDDefinition>> definitionsBlock, string outputPath)
        {
            // Build the definition collection
            var definitions = definitionsBlock
                .SelectMany(kvp => kvp.Value)
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
                .OrderByDescending(d => d.PriorityLevel)
                .ToList();

            var definitionDictionary = definitions.GroupByMimeType().Cleanse();
            definitionDictionary.CreateMemoryDump(Configuration.GetDumpPath(outputPath));
            definitions = definitionDictionary.Flatten();

            return definitions;
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

        private static void ExportToJson(Metadata metadata, string outputPath)
        {
            outputPath = Path.Combine(outputPath, Configuration.FILEDEF_METADATA_NAME);

            var json = JsonSerializer.Serialize(metadata, PackageMetadataJsonContext.Default.Metadata);
            File.WriteAllText(outputPath, json);

            Console.WriteLine("Package metadata has been exported to {0}", Configuration.FILEDEF_METADATA_NAME);
        }

        private static void ExportToBinary(List<Definition> definitions, string outputPath)
        {
            outputPath = Path.Combine(outputPath, Configuration.FILEDEF_PACKAGE_NAME);

            var package = MessagePackSerializer.Serialize(definitions);
            File.WriteAllBytes(outputPath, package);
            
            Console.WriteLine("Package has been exported to {0}", Configuration.FILEDEF_PACKAGE_NAME);
        }
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Metadata))]
    internal partial class PackageMetadataJsonContext : JsonSerializerContext
    {
    }
}
