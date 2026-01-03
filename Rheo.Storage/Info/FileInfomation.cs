using MimeDetective;
using MimeDetective.Engine;
using Rheo.Storage.Contracts;
using System.Collections.Immutable;
using System.Diagnostics;

namespace Rheo.Storage.Info
{
    public class FileInfomation : IStorageInformation
    {
        private static readonly IContentInspector _inspector;

        private readonly string _filePath;
        private readonly FileInfo _systemFileInfo;

        static FileInfomation()
        {
            _inspector = new ContentInspectorBuilder()
            {
                Definitions = new MimeDetective.Definitions.CondensedBuilder()
                {
                    UsageType = MimeDetective.Definitions.Licensing.UsageType.PersonalNonCommercial
                }.Build()
            }.Build();
        }

        public FileInfomation(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"The file '{fullPath}' does not exist.");
            }

            _filePath = fullPath;
            _systemFileInfo = new FileInfo(fullPath);

            if (string.IsNullOrWhiteSpace(TypeName))
            {
                // Create file description from the MIME type
                var context = MimeType.Split('/').FirstOrDefault();
                TypeName = context switch
                {
                    "text" => "Text File",
                    "image" => "Image File",
                    "video" => "Video File",
                    "audio" => "Audio File",
                    "application" => GetApplicationDescription(),
                    _ => "Unknown File" // Placeholder to avoid unnecessary assignment warning.
                };
            }
        }

        /// <summary>
        /// Gets the file extension, including the leading period (e.g., ".txt").
        /// </summary>
        public string Extension
        {
            get
            {
                if (TryGetTrueExtention(out string ext))
                {
                    return '.' + ext;
                }

                return _systemFileInfo.Extension;
            }
        }

        public override string MimeType
        {
            get
            {
                ImmutableArray<MimeTypeMatch> results;
                results = _inspector.Inspect(_filePath).ByMimeType();
                return results.FirstOrDefault()?.MimeType.ToLower() ?? "application/octet-stream"; // Default MIME type
            }
        }

        public bool IsBinaryFile(int sampleSize = 4096)
        {
            var buffer = new byte[sampleSize];

            try
            {
                using var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
                int bytesRead = stream.Read(buffer, 0, sampleSize);
                for (int i = 0; i < bytesRead; i++)
                {
                    // Check for non-printable ASCII characters (excluding common control characters like \n, \r, \t)
                    if (buffer[i] > 0 && buffer[i] < 32 && buffer[i] != 9 && buffer[i] != 10 && buffer[i] != 13)
                    {
                        return true;
                    }
                }
            }
            catch (IOException)
            {
                return false; // Assume text if we can't read the file
            }

            return false; // Likely text (based on sample)
        }

        /// <summary>
        /// Attempts to retrieve the true file extension of the file specified by the current file path.
        /// </summary>
        /// <remarks>This method checks if the file exists at the current file path and inspects its
        /// metadata to determine the true file extension. If the file does not exist or the extension cannot be
        /// determined, the method returns <see langword="false"/>.</remarks>
        /// <param name="extention">When this method returns, contains the true file extension in lowercase and without the leading dot '.' if the operation succeeds;
        /// otherwise, an empty string. This parameter is passed uninitialized.</param>
        /// <returns><see langword="true"/> if the true file extension is successfully retrieved; otherwise, <see
        /// langword="false"/>.</returns>
        public bool TryGetTrueExtention(out string extention)
        {
            extention = string.Empty;

            var results = _inspector.Inspect(_filePath).ByFileExtension();
            var ext = results.FirstOrDefault()?.Extension;
            if (!string.IsNullOrEmpty(ext))
            {
                extention = ext.ToLower();
                return true;
            }

            return false;
        }

        private string GetApplicationDescription()
        {
            // Attempt to get a more specific description of the specific application
            try
            {
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(_filePath);
                if (!string.IsNullOrWhiteSpace(versionInfo.FileDescription))
                {
                    return versionInfo.FileDescription;
                }
            }
            catch (FileNotFoundException)
            {
                return "Unknown File";
            }
            
            return "Application File";
        }
    }
}
