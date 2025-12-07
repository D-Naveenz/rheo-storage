using Rheo.Storage.DefinitionsBuilder;

// Analyze a file
//var results = TridFileAnalyzer.AnalyzeFile("test.pdf", definitionsBlock);

//foreach (var result in results.Take(5))
//{
//    Console.WriteLine($"{result.Percentage:F1}% ({result.Definition.Extension}) {result.Definition.FileType}");
//}

Console.WriteLine("Rheo.Storage Definitions Builder v{0}", Configuration.Version);
Console.WriteLine("=====================================\n");

// Build Definitions Package
Console.WriteLine("Compiling definitions package...");
var packager = new PackageCompiler();
packager.Compile();

Console.WriteLine("\nDatabase ready for Rheo.Storage!");
