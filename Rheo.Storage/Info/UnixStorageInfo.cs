namespace Rheo.Storage.Info
{
    /// <summary>
    /// Represents detailed information about a file or directory on a Unix-based file system.
    /// </summary>
    /// <remarks>This structure provides file metadata commonly retrieved from Unix file system
    /// queries, including attributes, size, timestamps, ownership, permissions, and symbolic link information. Some
    /// fields may have platform-specific interpretations; for example, OwnerId and GroupId correspond to user and
    /// group IDs on Unix systems, while Mode reflects Unix file permissions and type. Not all fields may be
    /// meaningful or populated on non-Unix platforms.</remarks>
    public struct UnixStorageInfo
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
        /// The creation time of the file or directory.
        /// </summary>
        public DateTime CreationTime;

        /// <summary>
        /// The last write (modification) time of the file or directory.
        /// </summary>
        public DateTime LastWriteTime;

        /// <summary>
        /// The last access time of the file or directory.
        /// </summary>
        public DateTime LastAccessTime;

        /// <summary>
        /// The owner identifier. On Unix, this is the user ID (UID); on Windows, this may be a partial SID.
        /// </summary>
        public uint OwnerId;

        /// <summary>
        /// The group identifier. On Unix, this is the group ID (GID).
        /// </summary>
        public uint GroupId;

        /// <summary>
        /// The file mode (permissions and type). On Unix, this is the st_mode field.
        /// </summary>
        public uint Mode;

        /// <summary>
        /// The target path if the file is a symbolic link; otherwise, null.
        /// </summary>
        public string? SymlinkTarget;
    }
}
