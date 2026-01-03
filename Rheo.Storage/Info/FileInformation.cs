using Rheo.Storage.FileDefinition;
using Rheo.Storage.FileDefinition.Models.Result;

namespace Rheo.Storage.Info
{
    /// <summary>
    /// Provides detailed information about a file, including its type, MIME type, extension, and analysis results,
    /// based on both file metadata and content analysis.
    /// </summary>
    /// <remarks>Use this class to access file-specific information and analysis results, such as the detected
    /// file type, MIME type, and extensions. FileInformation performs content-based analysis in addition to using file
    /// metadata, which can provide more accurate identification than relying on file name or extension alone. This
    /// class is typically used when you need to determine the true nature of a file, regardless of its name or
    /// extension.</remarks>
    public class FileInformation : StorageInformation
    {
        private readonly FileStream _stream;

        private readonly TaskCompletionSource<AnalysisResult> _analysisTaskAwaiter;
        private readonly Lazy<AnalysisResult> _identificationReportLazy;

        /// <summary>
        /// Initializes a new instance of the FileInformation class using the specified file stream.
        /// </summary>
        /// <remarks>The analysis of the file stream begins immediately in a background task upon
        /// construction. The provided stream must remain open and readable for the duration of the analysis.</remarks>
        /// <param name="stream">The file stream to analyze. The stream must be readable.</param>
        /// <exception cref="ArgumentException">Thrown if the provided stream is not readable.</exception>
        public FileInformation(FileStream stream) : base(stream.Name)
        {
            _stream = stream;

            // Validate the stream
            if (!stream.CanRead)
            {
                throw new ArgumentException("The provided stream must be readable.", nameof(stream));
            }

            // Initialize the task completion source
            _analysisTaskAwaiter = new TaskCompletionSource<AnalysisResult>();
            // Start the analysis in a background task
            Task.Run(() =>
            {
                try
                {
                    var report = FileAnalyzer.AnalyzeStream(_stream);
                    _analysisTaskAwaiter.SetResult(report);
                }
                catch (Exception ex)
                {
                    _analysisTaskAwaiter.SetException(ex);
                }
            });
            _identificationReportLazy = new Lazy<AnalysisResult>(() => _analysisTaskAwaiter.Task.GetAwaiter().GetResult());
        }

        #region Properties: Core Identity
        /// <summary>
        /// The user-friendly description of the type. This is typically a description of the storage type (e.g., "Text Document").
        /// </summary>
        public string TypeName
        {
            get
            {
                string? typeNameByInfo = null;
                if (TryGetWindowsStorageInfo(out var winfo))
                {
                    return winfo.DisplayName;
                }

                var definition = _identificationReportLazy.Value.Definitions.FirstOrDefault().Subject;
                string? typeNameByDefinition = definition?.FileType;

                // Prefer the longer, more descriptive type name
                if (!string.IsNullOrEmpty(typeNameByInfo) && !string.IsNullOrEmpty(typeNameByDefinition))
                {
                    return typeNameByInfo.Length >= typeNameByDefinition.Length ? typeNameByInfo : typeNameByDefinition;
                }
                else if (!string.IsNullOrEmpty(typeNameByInfo))
                {
                    return typeNameByInfo;
                }
                else if (!string.IsNullOrEmpty(typeNameByDefinition))
                {
                    return typeNameByDefinition;
                }
                else
                {
                    return "Unknown";
                }
            }
        }

        /// <summary>
        /// The MIME (Multipurpose Internet Mail Extensions) type of the storage. For example, a music file might have the "audio/mpeg" MIME type.
        /// </summary>
        public Confidence<string> MimeType => _identificationReportLazy.Value.MimeTypes.FirstOrDefault();

        /// <summary>
        /// The file extension (including the dot), if available, as determined by the file name or path.
        /// </summary>
        public string? Extension => Path.GetExtension(_absPath);

        /// <summary>
        /// The actual extension determined by file content analysis.
        /// </summary>
        public Confidence<string> ActualExtension => _identificationReportLazy.Value.Extensions.FirstOrDefault();

        /// <summary>
        /// The result of file type analysis, including detected definitions, extensions, and MIME types.
        /// </summary>
        public AnalysisResult IdentificationReport => _identificationReportLazy.Value;

        #endregion

        #region Properties: Size
        /// <inheritdoc/>
        public override ulong Size => _storageInfoLazy.Value.Size;

        #endregion
    }
}
