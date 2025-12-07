namespace Rheo.Storage.DefinitionsBuilder.Models.Package
{
    public class PackageInfo
    {
        public string Version { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int TotalDefinitions { get; set; }
        public int TotalMimeTypes { get; set; }
    }
}
