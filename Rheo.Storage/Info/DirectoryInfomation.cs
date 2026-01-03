using Rheo.Storage.Contracts;
using System.Security;

namespace Rheo.Storage.Info
{
    public class DirectoryInfomation : IStorageInformation
    {
        private const string CONTENT_TYPE = "inode/directory";

        private readonly string _directoryPath;
        private readonly DirectoryInfo _systemDirInfo;

        public DirectoryInfomation(string fullPath)
        {
            if (!Directory.Exists(fullPath))
            {
                throw new DirectoryNotFoundException($"The Directory {fullPath} does not exist.");
            }

            _directoryPath = fullPath;
            _systemDirInfo = new(fullPath);
        }

        public override string MimeType => CONTENT_TYPE;

        /// <summary>
        /// Gets the total number of files in the directory and its subdirectories.
        /// </summary>
        /// <remarks>This property attempts to retrieve the file count recursively. If the application
        /// does not have the necessary permissions  to access the directory or its subdirectories, the property returns
        /// -1 to indicate that the operation could not be completed.</remarks>
        public int NoOfFiles
        {
            get
            {
                try
                {
                    // Attempt to get the number of files in the directory recursively
                    return _systemDirInfo.GetFiles("*", SearchOption.AllDirectories).Length;
                }
                catch (SecurityException)
                {
                    // Handle the case where access is denied
                    return -1; // or any other value indicating access is denied
                }
            }
        }

        /// <summary>
        /// Gets the total number of directories within the current directory and its subdirectories.
        /// </summary>
        /// <remarks>This property attempts to retrieve the count of all directories recursively. If a
        /// security exception occurs  (e.g., insufficient permissions to access the directory), the property returns
        /// -1.</remarks>
        public int NoOfDirectories
        {
            get
            {
                try
                {
                    // Attempt to get the number of folder in the directory recursively
                    return _systemDirInfo.GetDirectories("*", SearchOption.AllDirectories).Length;
                }
                catch (SecurityException)
                {
                    return -1;
                }
            }
        }
    }
}
