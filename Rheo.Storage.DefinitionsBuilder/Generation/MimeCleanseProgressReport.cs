namespace Rheo.Storage.DefinitionsBuilder.Generation
{
    internal class MimeCleanseProgressReport
    {
        public string CurrentMimeType { get; set; } = string.Empty;
        public int ValidCount { get; set; }
        public int InvalidCount { get; set; }
        public int ProcessedCount { get; set; }
        public int TotalCount { get; set; }
        public double Percentage => TotalCount > 0 ? (double)ProcessedCount / TotalCount * 100 : 0;

        // For displaying in console
        public override string ToString()
        {
            return $"Type: {CurrentMimeType}\n" +
                   $"Valid: {ValidCount} | Invalid: {InvalidCount}\n" +
                   $"Progress: {ProcessedCount}/{TotalCount} ({Percentage:F1}%)";
        }
    }
}
