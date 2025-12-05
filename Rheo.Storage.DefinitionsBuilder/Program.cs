using Rheo.Storage.DefinitionsBuilder;
using Rheo.Storage.DefinitionsBuilder.TrID;

// Parse TrID package
var definitionsBlock = TridPackageParser.ParsePackage(@".\Data\triddefs.trd");

Console.WriteLine($"Loaded {definitionsBlock.DefinitionCount} definitions");

// Analyze a file
var results = TridFileAnalyzer.AnalyzeFile("test.pdf", definitionsBlock);

foreach (var result in results.Take(5))
{
    Console.WriteLine($"{result.Percentage:F1}% ({result.Definition.Extension}) {result.Definition.FileType}");
}

// Build MIME database
var mimeEntries = TridMimeDatabase.BuildMimeDatabase(definitionsBlock);

Console.WriteLine($"\nGenerated {mimeEntries.Count} MIME entries");

// Export to various formats
TridMimeDatabase.ExportToJson(mimeEntries, "mime-database.json");
TridMimeDatabase.ExportToBinary(mimeEntries, "mime-database.bin");

// Example for Rheo.Storage integration
var storageEntries = mimeEntries.Select(e => new
{
    e.MimeType,
    e.Extensions,
    MagicNumbers = e.Patterns.Select(p => new
    {
        Offset = p.Position,
        Bytes = Convert.ToHexString(p.Data)
    }).ToList()
});

Console.WriteLine("\nDatabase ready for Rheo.Storage!");
