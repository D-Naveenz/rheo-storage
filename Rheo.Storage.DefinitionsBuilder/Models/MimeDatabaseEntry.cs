using Rheo.Storage.DefinitionsBuilder.Models.Definition;

namespace Rheo.Storage.DefinitionsBuilder.Models
{
    public class MimeDatabaseEntry
    {
        public string MimeType { get; set; } = "";
        public string FileType { get; set; } = "";
        public List<string> Extensions { get; set; } = new();
        public List<Pattern> Patterns { get; set; } = new();
        public int Priority { get; set; }
    }
}
