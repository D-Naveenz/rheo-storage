namespace Rheo.Storage.DefinitionsBuilder.TrID.Models
{
    public class TrIDResult
    {
        public double Percentage { get; set; }
        public int Points { get; set; }
        public int PatternCount { get; set; }
        public int StringCount { get; set; }
        public TrIDDefinition Definition { get; set; } = new();
    }
}
