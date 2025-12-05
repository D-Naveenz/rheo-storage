namespace Rheo.Storage.DefinitionsBuilder.TrID.Models
{
    public class TrIDDefinitionsBlock
    {
        public int Version { get; set; }
        public int DefinitionCount { get; set; }
        public Dictionary<int, List<TrIDDefinition>> DefinitionsByFirstByte { get; set; } = [];
    }
}
