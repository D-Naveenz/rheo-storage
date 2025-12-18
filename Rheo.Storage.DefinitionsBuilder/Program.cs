using Rheo.Storage.DefinitionsBuilder;
using Rheo.Storage.DefinitionsBuilder.ETL.Packaging;
using Spectre.Console;

// Analyze a file
//var results = TridFileAnalyzer.AnalyzeFile("test.pdf", definitionsBlock);

//foreach (var result in results.Take(5))
//{
//    Console.WriteLine($"{result.Percentage:F1}% ({result.Definition.Extension}) {result.Definition.FileType}");
//}

// Display Banner
var font = FigletFont.Load("Assets/Fonts/Basic.flf");
AnsiConsole.Write(new FigletText(font, "Rheo").Centered().Color(Color.Green));
AnsiConsole.Write(new Align(new Text(Configuration.ProductName, new Style(Color.Yellow)), HorizontalAlignment.Center));
var rule = new Rule($"[yellow]v{Configuration.Version}[/]");
AnsiConsole.Write(rule);

// Build Definitions Package
var package = PackageBuilder.Build();
// Export Package
Exporter.ExportPackage(package, "Output");
// Save Package Log
Exporter.SavePackageLogs("Logs", package.Logs);

Console.WriteLine("\nDatabase ready for Rheo Storage library!");
