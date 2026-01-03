namespace Rheo.Storage.Info
{
    /// <summary>
    /// Represents detailed information about a file or directory on a Windows file system.
    /// </summary>
    /// <remarks>This structure provides comprehensive file metadata obtained directly from Windows
    /// APIs, including attributes, size, timestamps, security information, and Shell-provided display information.
    /// Icon handles returned in this structure must be destroyed using DestroyIcon when no longer needed.</remarks>
    public struct WindowsStorageInfo
    {
        /// <summary>
        /// Specifies the file or directory attributes as a set of flags.
        /// </summary>
        public FileAttributes Attributes;

        /// <summary>
        /// The size of the file in bytes.
        /// </summary>
        public ulong Size;

        /// <summary>
        /// The creation time of the file or directory in UTC.
        /// </summary>
        public DateTime CreationTime;

        /// <summary>
        /// The last write (modification) time of the file or directory in UTC.
        /// </summary>
        public DateTime LastWriteTime;

        /// <summary>
        /// The last access time of the file or directory in UTC.
        /// </summary>
        public DateTime LastAccessTime;

        /// <summary>
        /// The display name for the file as provided by Windows Shell.
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// The type name (e.g., "Text Document") as provided by Windows Shell.
        /// </summary>
        public string TypeName;

        /// <summary>
        /// Handle to the icon representing this file. Must be destroyed with DestroyIcon when done.
        /// </summary>
        public nint IconHandle;

        /// <summary>
        /// The security identifier (SID) of the file owner.
        /// </summary>
        public string? OwnerSid;

        /// <summary>
        /// The number of hard links to the file.
        /// </summary>
        public uint HardLinkCount;

        /// <summary>
        /// The volume serial number of the volume containing the file.
        /// </summary>
        public uint VolumeSerialNumber;

        /// <summary>
        /// The file index (unique identifier on the volume).
        /// </summary>
        public ulong FileIndex;

        /// <summary>
        /// The target path if the file is a reparse point (symbolic link, junction, etc.); otherwise, null.
        /// </summary>
        public string? ReparseTarget;
    }
}
