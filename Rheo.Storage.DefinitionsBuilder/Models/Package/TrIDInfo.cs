namespace Rheo.Storage.DefinitionsBuilder.Models.Package
{
    public class TrIDInfo
    {
        public const string FILE_NAME = "triddefs.trd";
        public const string AUTHOR = "Marco Pontello";
        public const string SOFTWARE = "TrID - File Identifier";
        public const string WEBSITE = "http://mark0.net/soft-trid-e.html";

        // Constants representing as properties for easier serialization
        public string FileName => FILE_NAME;
        public string Author => AUTHOR;
        public string Software => SOFTWARE;
        public string Website => WEBSITE;
        public string Version { get; set; } = string.Empty;
        public int TotalRecords { get; set; }
    }
}
