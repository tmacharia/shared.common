namespace Common.IO
{
    /// <summary>
    /// Extension methods for file related jobs.
    /// </summary>
    public static class FileExts
    {
        /// <summary>
        /// Re-formats a filename to one that is valid and considered safe and 
        /// won't fail when trying to save.
        /// </summary>
        /// <param name="filepath">File path</param>
        /// <returns>Safe file path.</returns>
        public static string ToSafeFileName(string filepath)
        {
            return filepath
            .Replace("\\", "")
            .Replace("/", "")
            .Replace("\"", "")
            .Replace("*", "")
            .Replace(":", "")
            .Replace("?", "")
            .Replace("<", "")
            .Replace(">", "")
            .Replace("|", "");
        }
    }
}