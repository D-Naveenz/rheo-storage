namespace Rheo.Storage.DefinitionsBuilder.Models.Package
{
    public class TrIDInfo
    {
        private const string PROGRAM = "TrID - File Identifier";

        public const string SCRIPT_NAME = "trid.py";
        public const string PACKAGE_NAME = "triddefs.trd";

        // Constants representing as properties for easier serialization
        public string Program => PROGRAM;
        public string Version { get; set; } = string.Empty;
        public int TotalRecords { get; set; }
    }
}
