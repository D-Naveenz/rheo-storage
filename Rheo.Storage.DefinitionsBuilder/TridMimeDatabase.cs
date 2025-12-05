using Rheo.Storage.DefinitionsBuilder.Models;
using Rheo.Storage.DefinitionsBuilder.TrID.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rheo.Storage.DefinitionsBuilder
{
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(List<MimeDatabaseEntry>))]
    internal partial class MimeDatabaseJsonContext : JsonSerializerContext
    {
    }

    public static class TridMimeDatabase
    {
        public static List<MimeDatabaseEntry> BuildMimeDatabase(TrIDDefinitionsBlock definitionsBlock)
        {
            // var mimeEntries = new List<MimeDatabaseEntry>();

            // Flatten all definitions
            var allDefinitions = definitionsBlock.DefinitionsByFirstByte
                .SelectMany(kvp => kvp.Value)
                .Where(d => !string.IsNullOrEmpty(d.MimeType))
                .ToList();

            // Group by MIME type
            var groupedByMime = allDefinitions
                .GroupBy(d => d.MimeType)
                .Select(g => new MimeDatabaseEntry
                {
                    MimeType = g.Key,
                    FileType = g.First().FileType,
                    Extensions = g.SelectMany(d => d.Extension.Split('/')).Distinct().ToList(),
                    Patterns = g.SelectMany(d => d.Patterns).ToList(),
                    Priority = CalculatePriority(g.First())
                })
                .OrderByDescending(e => e.Priority)
                .ToList();

            return groupedByMime;
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

        public static void ExportToJson(List<MimeDatabaseEntry> entries, string outputPath)
        {
            var json = JsonSerializer.Serialize(entries, MimeDatabaseJsonContext.Default.ListMimeDatabaseEntry);
            File.WriteAllText(outputPath, json);
        }

        public static void ExportToBinary(List<MimeDatabaseEntry> entries, string outputPath)
        {
            using var writer = new BinaryWriter(File.Create(outputPath));

            writer.Write(entries.Count);

            foreach (var entry in entries)
            {
                writer.Write(entry.MimeType);
                writer.Write(entry.FileType);
                writer.Write(entry.Priority);

                writer.Write(entry.Extensions.Count);
                foreach (var ext in entry.Extensions)
                {
                    writer.Write(ext);
                }

                writer.Write(entry.Patterns.Count);
                foreach (var pattern in entry.Patterns)
                {
                    writer.Write(pattern.Position);
                    writer.Write(pattern.Data.Length);
                    writer.Write(pattern.Data);
                }
            }
        }
    }
}
