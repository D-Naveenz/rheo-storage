using Rheo.Storage.DefinitionsBuilder;

// Analyze a file
//var results = TridFileAnalyzer.AnalyzeFile("test.pdf", definitionsBlock);

//foreach (var result in results.Take(5))
//{
//    Console.WriteLine($"{result.Percentage:F1}% ({result.Definition.Extension}) {result.Definition.FileType}");
//}

// Build Definitions Package
var packager = new PackageCompiler();
Console.WriteLine($"Loaded {packager.Block.Count} definitions");

packager.Compile();
Console.WriteLine($"\nGenerated {packager.CollectionMetadata.PackageInfo.TotalDefinitions} MIME entries");

Console.WriteLine("\nDatabase ready for Rheo.Storage!");
