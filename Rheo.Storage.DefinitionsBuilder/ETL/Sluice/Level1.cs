namespace Rheo.Storage.DefinitionsBuilder.ETL.Sluice
{
    internal static partial class CommonExtensions
    {
        /// <summary>
        /// Returns a collection of common file extensions representing universally recognized and essential file
        /// formats. This collection is limited to approximately 150-200 extensions
        /// </summary>
        /// <remarks>The returned collection includes file extensions for widely used document, image,
        /// audio, video, archive, executable, script, web, database, e-book, and configuration formats. These
        /// extensions are considered essential for general-purpose file handling and interoperability across platforms
        /// and applications.</remarks>
        /// <returns>An <see cref="IEnumerable{String}"/> containing file extensions for universal and essential file formats.
        /// The collection includes, but is not limited to, extensions such as "docx", "pdf", "jpg", "mp3", "mp4",
        /// "zip", "exe", "html", and "json".</returns>
        private static IEnumerable<string> BuildLevel1()
        {
            #region Universal Documents & Office (28)
            // Microsoft Office & Universal formats
            yield return "doc";
            yield return "docx";
            yield return "xls";
            yield return "xlsx";
            yield return "ppt";
            yield return "pptx";
            yield return "pdf";
            yield return "rtf";
            yield return "txt";
            yield return "csv";
            yield return "tsv";
            yield return "odt";
            yield return "ods";
            yield return "odp";
            yield return "odg";
            yield return "odf";
            yield return "pages";
            yield return "numbers";
            yield return "key";
            yield return "vsd";
            yield return "vsdx";
            yield return "one";
            yield return "pub";
            yield return "xps";
            yield return "oxps";
            yield return "epub";
            yield return "mobi";
            yield return "azw";
            #endregion

            #region Universal Images (26)
            // Raster formats
            yield return "jpg";
            yield return "jpeg";
            yield return "png";
            yield return "gif";
            yield return "bmp";
            yield return "ico";
            yield return "cur";
            yield return "webp";
            yield return "heic";
            yield return "heif";
            yield return "tif";
            yield return "tiff";
            yield return "psd";
            yield return "psb";
            yield return "raw";
            yield return "arw";
            yield return "cr2";
            yield return "nef";
            yield return "orf";
            yield return "dng";
            // Vector formats
            yield return "svg";
            yield return "ai";
            yield return "eps";
            yield return "ps";
            yield return "emf";
            yield return "wmf";
            #endregion

            #region Universal Audio (24)
            // Lossy compressed
            yield return "mp3";
            yield return "m4a";
            yield return "aac";
            yield return "ogg";
            yield return "oga";
            yield return "opus";
            yield return "wma";
            yield return "ra";
            // Lossless
            yield return "wav";
            yield return "flac";
            yield return "alac";
            yield return "ape";
            // High-resolution
            yield return "dsf";
            yield return "dff";
            // Playlist & metadata
            yield return "m3u";
            yield return "m3u8";
            yield return "pls";
            yield return "cue";
            // Apple
            yield return "aiff";
            yield return "aif";
            yield return "caf";
            // MIDI & music
            yield return "mid";
            yield return "midi";
            yield return "kar";
            #endregion

            #region Universal Video (22)
            // Common containers
            yield return "mp4";
            yield return "avi";
            yield return "mkv";
            yield return "mov";
            yield return "wmv";
            yield return "flv";
            yield return "webm";
            yield return "m4v";
            yield return "mpg";
            yield return "mpeg";
            yield return "vob";
            yield return "ts";
            yield return "mts";
            yield return "m2ts";
            yield return "3gp";
            yield return "3g2";
            // Apple
            yield return "qt";
            // Flash
            yield return "swf";
            // DVD
            yield return "ifo";
            // High efficiency
            yield return "hevc";
            yield return "h265";
            #endregion

            #region Universal Archives & Compression (18)
            // Universal archives
            yield return "zip";
            yield return "rar";
            yield return "7z";
            yield return "tar";
            // Compressed archives
            yield return "gz";
            yield return "gzip";
            yield return "bz2";
            yield return "bzip2";
            yield return "xz";
            yield return "lz";
            yield return "lzma";
            // Self-extracting
            yield return "exe"; // SFX
                                // Disk images
            yield return "iso";
            yield return "img";
            yield return "dmg";
            yield return "vhd";
            yield return "vhdx";
            yield return "vmdk";
            #endregion

            #region Executables & System Files (20)
            // Windows
            yield return "exe";
            yield return "dll";
            yield return "sys";
            yield return "drv";
            yield return "ocx";
            yield return "msi";
            yield return "msix";
            yield return "msixbundle";
            yield return "appx";
            yield return "appxbundle";
            // Linux/Unix
            yield return "so";
            yield return "ko";
            // Scripts
            yield return "bat";
            yield return "cmd";
            yield return "ps1";
            yield return "sh";
            yield return "bash";
            yield return "csh";
            yield return "zsh";
            yield return "fish";
            #endregion

            #region Web & Programming (24)
            // Web files
            yield return "html";
            yield return "htm";
            yield return "xhtml";
            yield return "css";
            yield return "js";
            yield return "mjs";
            yield return "cjs";
            yield return "json";
            yield return "xml";
            yield return "yaml";
            yield return "yml";
            yield return "toml";
            // Programming source
            yield return "c";
            yield return "cpp";
            yield return "h";
            yield return "hpp";
            yield return "cs";
            yield return "java";
            yield return "py";
            yield return "php";
            yield return "rb";
            yield return "go";
            yield return "rs";
            yield return "swift";
            #endregion

            #region Databases (12)
            // Common databases
            yield return "db";
            yield return "sqlite";
            yield return "sqlite3";
            yield return "mdb";
            yield return "accdb";
            yield return "fdb";
            // Dumps & exports
            yield return "sql";
            yield return "dump";
            // NoSQL
            yield return "bson";
            // Configuration
            yield return "ini";
            yield return "cfg";
            yield return "conf";
            #endregion

            #region Email & Messaging (10)
            yield return "eml";
            yield return "msg";
            yield return "pst";
            yield return "ost";
            yield return "mbox";
            yield return "vcf";
            yield return "vcard";
            yield return "ics";
            yield return "ical";
            yield return "mbox";
            #endregion

            #region Fonts (8)
            yield return "ttf";
            yield return "otf";
            yield return "woff";
            yield return "woff2";
            yield return "eot";
            yield return "fon";
            yield return "fnt";
            yield return "dfont";
            #endregion

            #region Configuration & Data (12)
            yield return "log";
            yield return "bak";
            yield return "tmp";
            yield return "temp";
            yield return "dat";
            yield return "data";
            yield return "bin";
            yield return "reg";
            yield return "inf";
            yield return "plist";
            yield return "config";
            yield return "properties";
            #endregion

            #region Security & Certificates (8)
            yield return "pem";
            yield return "crt";
            yield return "cer";
            yield return "der";
            yield return "p12";
            yield return "pfx";
            yield return "key";
            yield return "csr";
            #endregion

            #region Virtualization & Containers (6)
            yield return "ova";
            yield return "ovf";
            yield return "vbox";
            yield return "vagrant";
            yield return "dockerfile";
            yield return "yaml"; // Kubernetes/Compose
            #endregion
        }
    }
}
