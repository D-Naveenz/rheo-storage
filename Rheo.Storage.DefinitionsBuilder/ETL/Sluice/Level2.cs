namespace Rheo.Storage.DefinitionsBuilder.ETL.Sluice
{
    internal static partial class CommonExtensions
    {
        /// <summary>
        /// Returns a collection of file extensions that are commonly used in professional and creative work across
        /// various domains. This collection is limited to approximately 300-400 extensions.
        /// </summary>
        /// <remarks>The returned set includes extensions for creative and design applications, audio and
        /// video production, photography, software development, data science, specialized documents, virtualization,
        /// and game asset formats. This list is intended to represent widely recognized file types in professional
        /// workflows and may be useful for applications that need to identify or filter such files.</remarks>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="string"/> values, where each string is a file extension
        /// (without the leading period) representing a professional or creative file type.</returns>
        private static IEnumerable<string> BuildLevel2()
        {
            #region Creative & Design
            // Adobe Creative Suite
            yield return "psd";
            yield return "ai";
            yield return "indd";
            yield return "eps";
            yield return "ps";
            yield return "prproj";  // Premiere
            yield return "aep";      // After Effects

            // 3D & CAD
            yield return "dwg";
            yield return "dxf";
            yield return "stl";
            yield return "obj";
            yield return "blend";

            // Vector graphics
            yield return "cdr";      // CorelDRAW
            yield return "svgz";
            #endregion

            #region Audio/Video Production
            // Professional audio
            yield return "flac";
            yield return "aiff";
            yield return "ogg";
            yield return "opus";
            yield return "wma";
            yield return "mid";
            yield return "midi";

            // Video production
            yield return "m2ts";
            yield return "mts";
            yield return "vob";
            yield return "ts";
            yield return "mxf";
            yield return "mov";      // ProRes, etc.
            #endregion

            #region Photography
            // Raw formats (major brands)
            yield return "raw";
            yield return "cr2";      // Canon
            yield return "nef";      // Nikon
            yield return "arw";      // Sony
            yield return "dng";      // Adobe
            yield return "orf";      // Olympus
            yield return "rw2";      // Panasonic
            #endregion

            #region Development & Programming
            // Source code
            yield return "py";
            yield return "java";
            yield return "cpp";
            yield return "c";
            yield return "h";
            yield return "cs";
            yield return "php";
            yield return "rb";
            yield return "go";
            yield return "rs";
            yield return "swift";
            yield return "kt";

            // Build & project files
            yield return "sln";
            yield return "csproj";
            yield return "vbproj";
            yield return "vcxproj";
            yield return "xcodeproj";
            yield return "makefile";
            yield return "cmake";
            #endregion

            #region Data & Science
            yield return "mat";      // MATLAB
            yield return "r";
            yield return "rdata";
            yield return "sav";      // SPSS
            yield return "sas7bdat";
            yield return "feather";
            yield return "parquet";
            yield return "hdf5";
            yield return "nc";       // NetCDF
            #endregion

            #region Specialized Documents
            yield return "md";
            yield return "markdown";
            yield return "tex";
            yield return "latex";
            yield return "yaml";
            yield return "yml";
            yield return "toml";
            #endregion

            #region Virtualization & Disk
            yield return "iso";
            yield return "vmdk";
            yield return "vdi";
            yield return "vhd";
            yield return "vhdx";
            yield return "dmg";
            yield return "img";
            #endregion

            #region Game Assets
            yield return "unity";
            yield return "unitypackage";
            yield return "uasset";
            yield return "upk";
            yield return "blend";
            yield return "fbx";
            #endregion
        }
    }
}
