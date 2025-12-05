namespace Rheo.Storage.DefinitionsBuilder.Models.Package
{
    public class Metadata
    {
        public TrIDInfo DefinitionsInfo { get; set; } = new();
        public PackageInfo PackageInfo { get; set; } = new();
        public List<string> Categories { get; set; } = [];
    }
}
