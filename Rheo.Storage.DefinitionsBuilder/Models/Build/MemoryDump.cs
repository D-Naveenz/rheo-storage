namespace Rheo.Storage.DefinitionsBuilder.Models.Build
{
    public class MemoryDump
    {
        public int MimeCount { get; set; }
        public int DefinitionsCount { get; set; }
        public Dictionary<string, List<string>> MimeTypes { get; set; } = [];
    }
}
