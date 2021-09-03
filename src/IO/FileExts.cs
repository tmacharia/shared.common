﻿using System.Extensions;
using System.Text.RegularExpressions;

namespace System.IO
{
    /// <summary>
    /// Extension methods for file related jobs.
    /// </summary>
    public static class FileExts
    {
        /// <summary>
        /// Invalid FileName Values/Characters
        /// </summary>
        private const string InvalidCharsRg = "[<>:|/\\?*\'\"]";
        private static readonly Regex FilenameRegex = new Regex(InvalidCharsRg, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);

        /// <summary>
        /// Checks if the specified <paramref name="fileName"/> is a valid windows filename.
        /// </summary>
        /// <param name="fileName">Filename to check.</param>
        /// <returns>True of False.</returns>
        public static bool IsFileNameValid(string fileName) => fileName.IsValid() ? !FilenameRegex.IsMatch(fileName) : false;
        /// <summary>
        /// Re-formats a filename to one that is valid and considered safe and 
        /// won't fail when trying to save.
        /// </summary>
        /// <param name="filepath">File path</param>
        /// <returns>Safe file path.</returns>
        public static string ToSafeFileName(string filepath) => FilenameRegex.Replace(filepath, "");
        /// <summary>
        /// Re-formats a filename to one that is valid and considered safe and 
        /// won't fail when trying to save.
        /// </summary>
        /// <param name="s">File name</param>
        /// <returns>Safe file name.</returns>
        public static string CleanFileName(this string s) => FilenameRegex.Replace(s, "");
    }
}