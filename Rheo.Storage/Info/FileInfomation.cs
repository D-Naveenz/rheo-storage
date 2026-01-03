using Rheo.Storage.Contracts;
using Rheo.Storage.FileDefinition;
using Rheo.Storage.FileDefinition.Models.Result;

namespace Rheo.Storage.Info
{
    public class FileInfomation : IStorageInformation
    {
        private readonly string _filePath;
        private readonly FileStream _stream;

        private readonly TaskCompletionSource<AnalysisResult> _analysisTaskAwaiter;
        private readonly Lazy<AnalysisResult> _identificationReportLazy;
        private readonly TaskCompletionSource<IStorageInfoStruct> _storageInfoTaskAwaiter;
        private readonly Lazy<IStorageInfoStruct> _storageInfoLazy;

        public FileInfomation(FileStream stream)
        {
            _filePath = stream.Name;
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

            // Initialize the storage info task completion source
            _storageInfoTaskAwaiter = new TaskCompletionSource<IStorageInfoStruct>();
            // Start retrieving platform-specific storage info in a background task
            Task.Run(() =>
            {
                try
                {
                    var infoStruct = GetPlatformStorageInfo();
                    _storageInfoTaskAwaiter.SetResult(infoStruct);
                }
                catch (Exception ex)
                {
                    _storageInfoTaskAwaiter.SetException(ex);
                }
            });
            _storageInfoLazy = new Lazy<IStorageInfoStruct>(() => _storageInfoTaskAwaiter.Task.GetAwaiter().GetResult());
        }

        #region Properties: Core Identity
        /// <inheritdoc/>
        public string DisplayName
        {
            get
            {
                if (TryGetWindowsStorageInfo(out var winfo))
                {
                    return winfo.DisplayName;
                }

                return Path.GetFileNameWithoutExtension(_filePath);
            }
        }

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
        public string? Extension => Path.GetExtension(_filePath);

        /// <summary>
        /// The actual extension determined by file content analysis.
        /// </summary>
        public Confidence<string> ActualExtension => _identificationReportLazy.Value.Extensions.FirstOrDefault();

        /// <summary>
        /// The result of file type analysis, including detected definitions, extensions, and MIME types.
        /// </summary>
        public AnalysisResult IdentificationReport => _identificationReportLazy.Value;

        #endregion

        #region Properties: Attributes (FileAttributes enum)
        /// <inheritdoc/>
        public FileAttributes Attributes => _storageInfoLazy.Value.Attributes;

        /// <inheritdoc/>
        public bool IsReadOnly => Attributes.HasFlag(FileAttributes.ReadOnly);

        /// <inheritdoc/>
        public bool IsHidden => Attributes.HasFlag(FileAttributes.Hidden);

        /// <inheritdoc/>
        public bool IsSystem => Attributes.HasFlag(FileAttributes.System);

        /// <inheritdoc/>
        public bool IsTemporary => Attributes.HasFlag(FileAttributes.Temporary);

        #endregion

        #region Properties: Size
        /// <inheritdoc/>
        public ulong Size => _storageInfoLazy.Value.Size;

        /// <inheritdoc/>
        public string FormattedSize => GetSizeString();

        #endregion

        #region Properties: Timestamps
        /// <inheritdoc/>
        public DateTime CreationTime => _storageInfoLazy.Value.CreationTime;

        /// <inheritdoc/>
        public DateTime LastWriteTime => _storageInfoLazy.Value.LastWriteTime;

        /// <inheritdoc/>
        public DateTime LastAccessTime => _storageInfoLazy.Value.LastAccessTime;

        #endregion

        #region Properties: Links & Targets
        /// <inheritdoc/>
        public bool IsSymbolicLink => !string.IsNullOrEmpty(GetSymbolicLinkTarget());

        /// <inheritdoc/>
        public string? LinkTarget => GetSymbolicLinkTarget();

        #endregion

        #region Properties: Platform-Specific (optional/nullable)
        /// <inheritdoc/>
        public string? OwnerSid => TryGetWindowsStorageInfo(out var winfo) ? winfo.OwnerSid : null;

        /// <inheritdoc/>
        public nint? IconHandle => TryGetWindowsStorageInfo(out var winfo) ? winfo.IconHandle : null;

        /// <inheritdoc/>
        public uint? OwnerId => TryGetUnixStorageInfo(out var uinfo) ? uinfo.OwnerId : null;

        /// <inheritdoc/>
        public uint? GroupId => TryGetUnixStorageInfo(out var uinfo) ? uinfo.GroupId : null;

        /// <inheritdoc/>
        public uint? Mode => TryGetUnixStorageInfo(out var uinfo) ? uinfo.Mode : null;

        #endregion

        /// <summary>
        /// Returns a string representation of the size, optionally formatted using the specified unit of measurement
        /// (UOM).
        /// </summary>
        /// <remarks>When the <paramref name="uom"/> parameter is provided, the size is formatted using
        /// the specified unit of measurement. If <paramref name="uom"/> is <see langword="null"/>, the method
        /// determines the most appropriate unit (bytes, kilobytes, megabytes, or gigabytes) based on the size in
        /// bytes.</remarks>
        /// <param name="uom">The unit of measurement to use for formatting the size. If <see langword="null"/>, the method automatically
        /// selects an appropriate unit based on the size in bytes.</param>
        /// <returns>A string representing the size, including the unit of measurement. If the size is unknown, the string
        /// "Unknown size" is returned.</returns>
        public string GetSizeString(UOM? uom = null)
        {
            if (uom.HasValue)
            {
                var size = Size;
                return Size < 0 ? "Unknown size" : $"{size} {uom.Value}";
            }
            else
            {
                // Auto-select UOM
                var size = Size;
                if (size < 0)
                {
                    return "Unknown size";
                }

                return size switch
                {
                    < 1024 => $"{size} B",
                    < 1024 * 1024 => $"{size / 1024.0:F2} KB",
                    < 1024 * 1024 * 1024 => $"{size / (1024.0 * 1024):F2} MB",
                    _ => $"{size / (1024.0 * 1024 * 1024):F2} GB",
                };
            }
        }

        private IStorageInfoStruct GetPlatformStorageInfo()
        {
            try
            {
                IStorageInfoStruct infoStruct;

                if (OperatingSystem.IsWindows())
                {
                    infoStruct = InformationProvider.GetWindowsFileInfo(_filePath);
                }
                else if (OperatingSystem.IsLinux())
                {
                    infoStruct = InformationProvider.GetLinuxFileInfo(_filePath);
                }
                else if (OperatingSystem.IsMacOS())
                {
                    infoStruct = InformationProvider.GetMacFileInfo(_filePath);
                }
                else
                {
                    throw new PlatformNotSupportedException("The current operating system is not supported.");
                }

                return infoStruct;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to retrieve platform-specific storage information.", ex);
            }
        }

        private bool TryGetWindowsStorageInfo(out WindowsStorageInfo winfo)
        {
            winfo = default;
            try
            {
                var storageInfo = _storageInfoLazy.Value;
                if (storageInfo is WindowsStorageInfo windowsInfo)
                {
                    winfo = windowsInfo;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private bool TryGetUnixStorageInfo(out UnixStorageInfo uinfo)
        {
            uinfo = default;
            try
            {
                var storageInfo = _storageInfoLazy.Value;
                if (storageInfo is UnixStorageInfo unixInfo)
                {
                    uinfo = unixInfo;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private string? GetSymbolicLinkTarget()
        {
            // Platform-specific implementation to get symbolic link target
            if (OperatingSystem.IsWindows())
            {
                // Windows-specific logic
                return TryGetWindowsStorageInfo(out var winfo)? winfo.ReparseTarget : null;
            }
            else if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
            {
                // Unix-like systems logic
                return TryGetUnixStorageInfo(out var uinfo)? uinfo.SymlinkTarget : null;
            }
            else
            {
                throw new PlatformNotSupportedException("The current operating system is not supported for symbolic link retrieval.");
            }
        }
    }
}
