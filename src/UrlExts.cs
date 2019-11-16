using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    /// <summary>
    /// Contains extensions methods for http urls strings.
    /// </summary>
    public static class UrlExts
    {
        /// <summary>
        /// Evaluates if a <see cref="string"/> if a valid Url address.
        /// </summary>
        /// <param name="url">Text to analyze.</param>
        /// <returns>True of false</returns>
        public static bool IsValidUrl(string url)
        {
            if (url.IsValid())
            {
                bool valid_1 = Uri.IsWellFormedUriString(url, UriKind.Absolute);
                bool valid_2 = Regex.IsMatch(url, Constants.UrlRegex);

                return valid_1 || valid_2;
            }
            return false;
        }
        /// <summary>
        /// Evaluates if a <see cref="string"/> of text is a valid Sluggish text for
        /// url purposes usage.
        /// </summary>
        /// <param name="s">Text to analyze</param>
        /// <returns>True or False.</returns>
        public static bool IsValidUrlSlug(this string s)
        {
            if (s.IsValid())
            {
                // check dashes at the end.
                if (s.EndsWith("-") || s.EndsWith("_"))
                    return false;

                // check whitespaces
                if (Regex.IsMatch(s, @"\s"))
                    return false;

                // check for invalid chars
                if (Regex.IsMatch(s, @"[^\w\s\p{Pd}]"))
                    return false;

                return true;
            }
            return false;
        }
        /// <summary>
        /// Converts any text/string to a url slug that is safe for use
        /// on the web and 
        /// </summary>
        /// <param name="s">Text to slugify</param>
        /// <returns>Sluggified text</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string Sluggify(this string s) => GenerateUrlSlug(s);
        /// <summary>
        /// Converts any text/string to a url slug that is safe for use
        /// on the web and 
        /// </summary>
        /// <param name="s">Text to slugify</param>
        /// <returns>Sluggified text</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GenerateUrlSlug(this string s)
        {
            if (s.IsValid())
            {
                //First to lower case 
                s = s.ToLowerInvariant();
                byte[] bytes = null;
#if NET45 || NET451 || NET452
                bytes = Encoding.Default.GetBytes(s);
#else
                /*---------------------------------------------------------------+
                 | Before using/checking custom encodings, we must               |
                 | register CodePagesEncodingProvider for extended encodings     |
                 | otherwise this will throw an ArgumentException.               |
                 |                                                               |
                 | Github Issue: https://github.com/dotnet/corefx/issues/9158    |
                 | Stackoverflow: http://bit.ly/2KHnXK0                          |
                 |                                                               |
                 |                                                               |
                 +---------------------------------------------------------------+*/
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                //Remove all accents
                bytes = Encoding.GetEncoding("Cyrillic").GetBytes(s);
#endif
                s = Encoding.ASCII.GetString(bytes);

                //Replace spaces 
                s = Regex.Replace(s, @"\s", "-", RegexOptions.Compiled);

                //Remove invalid chars 
                s = Regex.Replace(s, @"[^\w\s\p{Pd}]", "", RegexOptions.Compiled);

                //Trim dashes from end 
                s = s.Trim('-', '_');

                //Replace double occurences of - or \_ 
                s = Regex.Replace(s, @"([-_]){2,}", "$1", RegexOptions.Compiled);

                return $"{s}";
            }
            return s;
        }
    }
}