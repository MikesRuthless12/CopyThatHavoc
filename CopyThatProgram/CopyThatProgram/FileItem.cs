namespace CopyThatProgram.Models
{
    public class FileItem
    {
        /// <summary>
        /// Full path to the file or directory.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// True if this item is a directory, false if it is a file.
        /// </summary>
        public bool IsDirectory { get; set; }

        /// <summary>
        /// Total file size in bytes (0 for directories).
        /// </summary>
        public long FileSize { get; set; }

        /// <summary>
        /// Bytes copied so far (for tracking progress).
        /// </summary>
        public long BytesCopied { get; set; }
    }
}
