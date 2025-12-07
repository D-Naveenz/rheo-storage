using Rheo.Storage.DefinitionsBuilder.Models.Build;
using Rheo.Storage.DefinitionsBuilder.Models.Definition;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rheo.Storage.DefinitionsBuilder.Generation
{
    internal static class DefinitionExtentions
    {
        private readonly static Dictionary<string, List<Definition>> _invalidGroupedDefinitions = [];

        /// <summary>
        /// Groups a list of <see cref="Definition"/> objects by their MIME type.
        /// </summary>
        /// <remarks>Definitions with a null, empty, or whitespace-only MIME type are excluded from the
        /// returned dictionary.</remarks>
        /// <param name="definitions">The list of <see cref="Definition"/> objects to group. Each object should have a valid MIME type.</param>
        /// <returns>A dictionary where the keys are MIME types (case-insensitive) and the values are lists of <see
        /// cref="Definition"/> objects associated with each MIME type.</returns>
        public static Dictionary<string, List<Definition>> GroupByMimeType(this List<Definition> definitions)
        {
            var groupedDefinitions = new Dictionary<string, List<Definition>>(StringComparer.OrdinalIgnoreCase);
            foreach (var definition in definitions)
            {
                if (string.IsNullOrWhiteSpace(definition.MimeType))
                {
                    _invalidGroupedDefinitions.TryAdd(definition.MimeType, []);
                    _invalidGroupedDefinitions[definition.MimeType].Add(definition);
                    continue;
                }

                groupedDefinitions.TryAdd(definition.MimeType, []);
                groupedDefinitions[definition.MimeType].Add(definition);
            }
            return groupedDefinitions;
        }

        /// <summary>
        /// Cleanses the MIME type keys in the provided dictionary and groups the associated definitions by their
        /// cleaned MIME types.
        /// </summary>
        /// <remarks>This method processes the MIME type keys in a case-insensitive manner. Invalid MIME
        /// types are excluded from the returned dictionary and handled separately. The <see
        /// cref="Definition.MimeType"/> property of each definition is updated to reflect the cleaned MIME
        /// type.</remarks>
        /// <param name="definitions">A dictionary where the keys represent MIME types and the values are lists of <see cref="Definition"/>
        /// objects associated with those MIME types.</param>
        /// <returns>A new dictionary where the keys are the cleaned MIME types and the values are lists of <see
        /// cref="Definition"/> objects updated with the cleaned MIME types.</returns>
        public static Dictionary<string, List<Definition>> Cleanse(this Dictionary<string, List<Definition>> definitions)
        {
            var grouped = new Dictionary<string, List<Definition>>(StringComparer.OrdinalIgnoreCase);
            var cleaner = new MimeTypeCleaner(MimeTypes.Load());

            foreach (var mime in definitions.Keys)
            {
                var cleanedMime = cleaner.CleanMimeType(mime);

                if (cleanedMime == null)
                {
                    // Handle invalid MIME types separately
                    _invalidGroupedDefinitions.TryAdd(mime, []);
                    _invalidGroupedDefinitions[mime].AddRange(definitions[mime]);
                    continue;
                }

                // Add the updated definitions with cleaned MIME type to the dictionary 
                grouped.TryAdd(cleanedMime, []);
                grouped[cleanedMime].AddRange([.. definitions[mime]
                    .Select(d => {
                        d.MimeType = cleanedMime; return d;
                    })]);
            }

            return grouped;
        }

        public static void CreateMemoryDump(this Dictionary<string, List<Definition>> definitions, string? dumpPath = null)
        {
            var validDefCount = 0;
            var invalidDefCount = 0;

            // Process valid definitions
            var validMimeTypes = new Dictionary<string,List<string>>(StringComparer.OrdinalIgnoreCase);
            foreach (var def in definitions)
            {
                validMimeTypes[def.Key] = [.. def.Value.Select(d => d.Extension).Distinct(StringComparer.OrdinalIgnoreCase)];
                validDefCount += def.Value.Count;
            }
            var validMemoryDump = new MemoryDump
            {
                DefinitionsCount = validDefCount,
                MimeCount = validMimeTypes.Keys.Count,
                MimeTypes = validMimeTypes
            };

            // Process invalid definitions
            var invalidMimeTypes = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            foreach (var def in _invalidGroupedDefinitions)
            {
                invalidMimeTypes[def.Key ?? "null"] = [.. def.Value.Select(d => d.Extension).Distinct(StringComparer.OrdinalIgnoreCase)];
                invalidDefCount += def.Value.Count;
            }
            var invalidMemoryDump = new MemoryDump
            {
                DefinitionsCount = invalidDefCount,
                MimeCount = invalidMimeTypes.Keys.Count,
                MimeTypes = invalidMimeTypes
            };

            // Export memory dumps
            ExportMemoryDump(validMemoryDump, "ValidMimeTypes.dump.json", dumpPath);
            ExportMemoryDump(invalidMemoryDump, "InvalidMimeTypes.dump.json", dumpPath);
        }

        /// <summary>
        /// Flattens a dictionary of definitions into a single list of definitions.
        /// </summary>
        /// <remarks>This method combines all the lists of definitions from the dictionary values into a
        /// single list. The order of elements in the resulting list corresponds to the order of the dictionary's values
        /// and the order of items within each value.</remarks>
        /// <param name="definitions">A dictionary where the key is an integer and the value is a list of <see cref="Definition"/> objects.</param>
        /// <returns>A list containing all <see cref="Definition"/> objects from the input dictionary, preserving their original
        /// order within each list.</returns>
        public static List<Definition> Flatten(this Dictionary<string, List<Definition>> definitions)
        {
            return [.. definitions.SelectMany(kvp => kvp.Value)];
        }

        private static void ExportMemoryDump(MemoryDump memoryDump, string fileName,string? outputPath = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(outputPath))
                {
                    outputPath = Path.Combine(Directory.GetCurrentDirectory(), "MemoryDumps");
                }

                outputPath = Path.GetFullPath(outputPath!);
                if (!Directory.Exists(outputPath))
                {
                    Directory.CreateDirectory(outputPath);
                }

                var filePath = Path.Combine(outputPath, fileName);
                var json = JsonSerializer.Serialize(memoryDump, MemoryDumpJsonContext.Default.MemoryDump);
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Memory dump exported to: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to export memory dump: {ex.Message}");
            }
        }
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(MemoryDump))]
    internal partial class MemoryDumpJsonContext : JsonSerializerContext
    {
    }
}
