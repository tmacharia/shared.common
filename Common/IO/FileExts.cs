namespace Common.IO
{
    /// <summary>
    /// Extension methods for file related jobs.
    /// </summary>
    public static class FileExts
    {
        /// <summary>
        /// Invalid FileName Values/Characters
        /// </summary>
        public static string[] InvalidFileNameChars = @"\\,/,\,*,:,?,<,>,|".Split(',');
        /// <summary>
        /// Checks if the specified <paramref name="fileName"/> is a valid windows filename.
        /// </summary>
        /// <param name="fileName">Filename to check.</param>
        /// <returns>True of False.</returns>
        public static bool IsFileNameValid(string fileName) {
            if(fileName.IsValid())
                return !fileName.ContainsAnyOf(InvalidFileNameChars);
            return false;
        }
        /// <summary>
        /// Re-formats a filename to one that is valid and considered safe and 
        /// won't fail when trying to save.
        /// </summary>
        /// <param name="filepath">File path</param>
        /// <returns>Safe file path.</returns>
        public static string ToSafeFileName(string filepath) {
            InvalidFileNameChars.ForEach(s => {
                filepath = filepath.Replace(s, "");
            });
            return filepath;
        }
    }
}