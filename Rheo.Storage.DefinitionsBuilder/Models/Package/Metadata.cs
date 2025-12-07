namespace Rheo.Storage.DefinitionsBuilder.Models.Package
{
    public class Metadata
    {
        public TrIDInfo Source { get; set; } = new();
        public PackageInfo Package { get; set; } = new();
    }
}
