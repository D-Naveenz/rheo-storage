namespace Rheo.Storage.DefinitionsBuilder.Models.Package
{
    public class TrIDInfo
    {
        public const string FileName = "triddefs.trd";
        public const string Author = "Marco Pontello";
        public const string Software = "TrID - File Identifier";
        public const string Website = "http://mark0.net/soft-trid-e.html";
        public string Version { get; set; } = string.Empty;
        public int TotalRecords { get; set; }
    }
}
