namespace Rheo.Storage.Info
{
    /// <summary>
    /// Specifies file attribute flags for Unix file system objects, including special permission bits and file types.
    /// </summary>
    /// <remarks>This enumeration supports bitwise combination of its member values. It represents a subset of
    /// Unix file mode bits, such as set-user-ID, set-group-ID, sticky bit, and file type indicators (e.g., symbolic
    /// link, socket, device files). These attributes are commonly used when working with Unix file permissions and
    /// metadata.</remarks>
    [Flags]
    public enum UnixFileAttributes
    {
        /// <summary>
        /// The set-user-ID bit is set. On execution, the process will have the privileges of the file's owner.
        /// </summary>
        SetUserId = 0x00020000,

        /// <summary>
        /// The set-group-ID bit is set. On execution, the process will have the privileges of the file's group.
        /// </summary>
        SetGroupId = 0x00040000,

        /// <summary>
        /// The sticky bit is set. Used on directories to restrict file deletion.
        /// </summary>
        StickyBit = 0x00080000,

        /// <summary>
        /// The file is a symbolic link.
        /// </summary>
        SymbolicLink = 0x00100000,

        /// <summary>
        /// The file is a socket.
        /// </summary>
        Socket = 0x00200000,

        /// <summary>
        /// The file is a named pipe (FIFO).
        /// </summary>
        NamedPipe = 0x00400000,

        /// <summary>
        /// The file is a character device.
        /// </summary>
        CharacterDevice = 0x00800000,

        /// <summary>
        /// The file is a block device.
        /// </summary>
        BlockDevice = 0x01000000
    }
}
