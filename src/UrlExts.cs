using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace Common
{
    /// <summary>
    /// Contains extensions methods for http urls strings.
    /// </summary>
    public static class UrlExts
    {
        public static string UrlEncode(this string url)
        {
            return WebUtility.UrlEncode(url);
        }

        public static string UrlDecode(this string url)
        {
            return WebUtility.UrlDecode(url);
        }
        public static Dictionary<string, string> GetQueryStrings(Uri uri)
        {
            var dic = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (uri == null)
                return dic;
            string query = uri.OriginalString;
            var paramsEncoded = query.TrimStart('?').Split('&');
            foreach (var paramEncoded in paramsEncoded)
            {
                var param = paramEncoded.UrlDecode();

                // Look for the equals sign
                var equalsPos = param.IndexOf('=');
                if (equalsPos <= 0)
                    continue;

                // Get the key and value
                var key = param.Substring(0, equalsPos);
                var value = equalsPos < param.Length
                    ? param.Substring(equalsPos + 1)
                    : string.Empty;

                // Add to dictionary
                dic[key] = value;
            }

            return dic;
        }
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
        /// <param name="value">Text to slugify</param>
        /// <returns>Sluggified text</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GenerateUrlSlug(this string value)
        {
            if (value.IsValid())
            {
                //First to lower case 
                value = value.ToLowerInvariant();

                //Remove all accents
                value = value.RemoveAccents();
                //var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);

                //value = Encoding.ASCII.GetString(bytes);

                //Replace spaces 
                value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

                //Remove invalid chars 
                value = Regex.Replace(value, @"[^\w\s\p{Pd}]", "", RegexOptions.Compiled);

                //Trim dashes from end 
                value = value.Trim('-', '_');

                //Replace double occurences of - or \_ 
                value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);
            }
            return value;
        }
    }
}