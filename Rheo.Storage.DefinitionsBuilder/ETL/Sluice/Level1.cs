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
            #region Universal Documents & Office
            // Microsoft Office (Worldwide standard)
            yield return "doc";
            yield return "docx";
            yield return "xls";
            yield return "xlsx";
            yield return "ppt";
            yield return "pptx";
            yield return "pdf";  // Universal document format

            // Universal text formats
            yield return "txt";
            yield return "rtf";
            yield return "csv";

            // Open Document Format (ISO standard)
            yield return "odt";
            yield return "ods";
            yield return "odp";
            #endregion

            #region Universal Images
            // Web & display images
            yield return "jpg";
            yield return "jpeg";
            yield return "png";
            yield return "gif";
            yield return "bmp";
            yield return "ico";
            yield return "webp";
            yield return "svg";
            #endregion

            #region Universal Audio
            // Playback on any device
            yield return "mp3";
            yield return "wav";
            yield return "mp4";  // For audio too
            yield return "m4a";
            yield return "aac";
            #endregion

            #region Universal Video
            // Play anywhere formats
            yield return "mp4";
            yield return "avi";
            yield return "mkv";
            yield return "mov";
            yield return "wmv";
            yield return "flv";
            yield return "webm";
            #endregion

            #region Universal Archives
            // Every OS can open
            yield return "zip";
            yield return "rar";
            yield return "7z";
            yield return "tar";
            yield return "gz";
            #endregion

            #region Executables & System
            // Windows
            yield return "exe";
            yield return "dll";
            yield return "msi";

            // Scripts
            yield return "bat";
            yield return "cmd";
            yield return "sh";

            // Web & programming
            yield return "html";
            yield return "htm";
            yield return "css";
            yield return "js";
            yield return "json";
            yield return "xml";
            #endregion

            #region Databases (Common)
            yield return "db";
            yield return "sqlite";
            yield return "mdb";
            #endregion

            #region E-books & Reading
            yield return "epub";
            yield return "pdf";  // Already included
            yield return "mobi";
            yield return "azw";
            #endregion

            #region Configuration & Data
            yield return "ini";
            yield return "cfg";
            yield return "conf";
            yield return "log";
            #endregion
        }
    }
}
