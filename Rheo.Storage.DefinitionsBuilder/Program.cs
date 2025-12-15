using Rheo.Storage.DefinitionsBuilder;
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
Console.WriteLine("Compiling definitions package...");
var packager = new PackageCompiler();
packager.Compile();

Console.WriteLine("\nDatabase ready for Rheo Storage library!");
