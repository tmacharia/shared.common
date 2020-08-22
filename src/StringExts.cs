using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Common
{
    /// <summary>
    /// Contains extensions methods on <see cref="Type"/> <see cref="string"/>
    /// </summary>
    public static class StringExts
    {
        /// <summary>
        /// Checks if a <see cref="string"/> is valid by whether it's empty, null 
        /// or whitespace.
        /// </summary>
        /// <param name="s">Text to evaluate.</param>
        /// <returns>
        /// True or False
        /// </returns>
        public static bool IsValid(this string s) {
            if (!string.IsNullOrWhiteSpace(s)) {
                return s.Length > 0;
            }
            return false;
        }
        /// <summary>  
        /// Removes all accents from the input string.  
        /// </summary>  
        /// <param name="text">The input string.</param>  
        /// <returns></returns>  
        public static string RemoveAccents(this string text)
        {
            if (!text.IsValid())
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            char[] chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c)
                != UnicodeCategory.NonSpacingMark).ToArray();

            return new string(chars).Normalize(NormalizationForm.FormC);
        }
        /// <summary>
        /// Checks if a <see cref="string"/> contains the specified query text
        /// as a substring.
        /// </summary>
        /// <param name="s">String text to check</param>
        /// <param name="q">Substring to check.</param>
        /// <returns>
        ///     True if it contains or
        ///     False if it doesn't.
        /// </returns>
        public static bool Has(this string s, string q) {
            if (s.IsValid() && q.IsValid()) {
                return s.Contains(q);
            }
            return false;
        }
        /// <summary>
        /// Checks if a string contains/has any of the specified strings.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="args">Array of string items to check.</param>
        /// <returns>True or false.</returns>
        public static bool ContainsAnyOf(this string s, params string[] args) {
            if(s.IsValid() && args.Length > 0) 
                return args.Any(x => s.Contains(x));
            return false;
        }
        /// <summary>
        /// Checks if a string contains/has all of the strings specified.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="args">Array of string items to lookup.</param>
        /// <returns>True or false.</returns>
        public static bool ContainsAll(this string s, params string[] args) {
            if(s.IsValid() && args.Length > 0) 
                return args.All(x => s.Contains(x));
            return false;
        }
        /// <summary>
        /// Checks if a string equals any of the strings specified.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="args">Array of string items to lookup.</param>
        /// <returns>True or false.</returns>
        public static bool EqualsAnyOf(this string s, params string[] queries) {
            if (queries != null && queries.Length > 0) {
                return queries.Any(x => s.Equals(x));
            }
            return true;
        }
        /// <summary>
        /// Checks if a string a valid integer number.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValidNumber(this string s)
            => int.TryParse(s, out _);
        /// <summary>
        /// Checks if a <see cref="string"/> is all in uppercase
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsUpper(this string s)
        {
            if (s.IsValid())
            {
                int upperCount = 0;
                char[] vs = s.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray();
                vs.ForEach(c =>
                {
                    if (char.IsUpper(c))
                        upperCount++;
                });
                return upperCount == vs.Length;
            }
            return false;
        }
        public static string ToTitleCase(this string s) => s.Capitalize();
        public static string Capitalize(this string s)
        {
            if (s.IsValid())
            {
                return string.Join(" ", 
                    s.Split(' ')
                    .Select(x => 
                    $"{char.ToUpper(x[0])}" +
                    $"{x.Substring(1, x.Length - 1)}"))
                    .TrimEnd();
            }
            return string.Empty;
        }
        /// <summary>
        /// Converts/Decodes HTML string to human redable plaintext.
        /// </summary>
        /// <param name="html">Encoded html</param>
        /// <returns>Plaintext</returns>
        public static string DecodeHtml(this string html) {
            if (html.IsValid()) {
                html = HttpUtility.HtmlDecode(html);
            }
            return html;
        }
        /// <summary>
        /// Converts a text <see cref="string"/> to an <see cref="int"/>
        /// </summary>
        /// <param name="intAsString">Text to convert</param>
        /// <returns>
        /// An <see cref="int"/> number
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int ToInt(this string intAsString) {
            if (intAsString.IsValid()) {
                return Convert.ToInt32(intAsString, Constants.Culture);
            }
            throw new ArgumentNullException(nameof(intAsString));
        }
        /// <summary>
        /// Converts a text <see cref="string"/> to a <see cref="double"/>
        /// </summary>
        /// <param name="doubleAsString">Text to convert</param>
        /// <returns>
        /// A <see cref="double"/> number
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static double ToDouble(this string doubleAsString) {
            if (doubleAsString.IsValid()) {
                return Convert.ToDouble(doubleAsString, Constants.Culture);
            }
            throw new ArgumentNullException(nameof(doubleAsString));
        }
        /// <summary>
        /// Converts a text <see cref="string"/> to a <see cref="decimal"/>
        /// </summary>
        /// <param name="doubleAsString">Text to convert</param>
        /// <returns>
        /// A <see cref="decimal"/> number
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static decimal ToDecimal(this string doubleAsString) {
            if (doubleAsString.IsValid()) {
                return Convert.ToDecimal(doubleAsString, Constants.Culture);
            }
            throw new ArgumentNullException(nameof(doubleAsString));
        }
        /// <summary>
        /// Evaluates if the current <see cref="string"/> starts with any of 
        /// the passed string arguments.
        /// </summary>
        /// <param name="s"><see cref="string"/> to evaluates</param>
        /// <param name="args">Argument parameters to check.</param>
        /// <returns>True or False.</returns>
        public static bool StartsWithAnyOf(this string s, params string[] args) {
            if (s.IsValid()) {
                s = s.ToUpper();
                int index = 0;

                args.ForEach(x => {
                    if (s.StartsWith(x.ToUpper()))
                        index++;
                });
                return index > 0;
            }
            return false;
        }
        /// <summary>
        /// Compares and evaluates if a specific query <see cref="string"/> matches
        /// another one using Regular Expressions.
        /// </summary>
        /// <param name="s">The <see cref="string"/> to check</param>
        /// <param name="q">The query <see cref="string"/></param>
        /// <returns>true or false.</returns>
        public static bool Matches(this string s, string q) => Regex.IsMatch(s, $"({q})", RegexOptions.IgnoreCase);
        /// <summary>
        /// Compares and evaluates if a specific query <see cref="string"/> matches
        /// another one using Regular Expressions.
        /// </summary>
        /// <param name="s">The <see cref="string"/> to check</param>
        /// <param name="args">Collection/Array of strings to check if any of them matches.</param>
        /// <returns>true or false.</returns>
        public static bool MatchesAny(this string s, params string[] args) => args.Any(x => s.Matches(x));
        /// <summary>
        /// Checks if a string of text contains a digit or number.
        /// </summary>
        /// <param name="s">Text to check</param>
        /// <returns>True or False</returns>
        public static bool HasDigit(this string s) => s.IsValid() ? s.ToCharArray().Any(c => Char.IsDigit(c)) : false;
        /// <summary>
        /// Checks if two strings match.
        /// </summary>
        /// <param name="s">Original/base/string1 to match against.</param>
        /// <param name="query">Text to match.</param>
        /// <param name="ignoreCase">Whether to ignore case or not.</param>
        /// <returns>True or False</returns>
        public static bool Is(this string s, string query, bool ignoreCase = true) {
            if (s.IsValid()) {
                return s.Equals(query, ignoreCase ? Constants.StringComparisonIgnoreCase : Constants.StringComparison);
            }
            return false;
        }
        /// <summary>
        /// Shortens a <see cref="string"/> of text to a certain number of characters and
        /// appends trailing dots(...) at the end to show continuation.
        /// </summary>
        /// <param name="s">Text to shorten</param>
        /// <param name="maxCharactersLength">Number of characters to take from the first index/start/zero</param>
        /// <param name="trailingTextToAppend">Text to append to the tail of a truncated text</param>
        /// <returns>
        /// Shortened version of the supplied <see cref="string"/>
        /// </returns>
        public static string Shorten(this string s, int maxCharactersLength, string trailingTextToAppend = Constants.TrailingText)
            => Truncate(s, maxCharactersLength, trailingTextToAppend);
        /// <summary>
        /// Truncates a <see cref="string"/> of text to a certain number of characters and
        /// appends trailing text e.g(...) at the end to show continuation.
        /// </summary>
        /// <param name="s">Text to shorten</param>
        /// <param name="maxCharactersLength">Number of characters to take from the first index/start/zero</param>
        /// <param name="trailingText">Text to append to the tail of a truncated text</param>
        /// <returns>
        /// Shortened version of the supplied <see cref="string"/>
        /// </returns>
        public static string Truncate(this string s, int maxCharactersLength, string trailingText = Constants.TrailingText) {
            if (s.IsValid()) {
                if(maxCharactersLength > 0){
                    if(s.Length > maxCharactersLength) {
                        return s.Substring(0, maxCharactersLength).Trim() + trailingText;
                    }
                }
                return s;
            }
            return s;
        }
        /// <summary>
        /// Returns the total number of full words in the current <see cref="string"/> of text.
        /// </summary>
        /// <param name="s">Text to analyse.</param>
        /// <returns>Total number of full words.</returns>
        public static int WordCount(this string s)
        {
            int count = 0;
            if (s.IsValid())
            {
                string[] words = s.Split(' ');
                count = words.Length;
                if (!words.First().IsValid())
                    count--;
                if (!words.Last().IsValid())
                    count--;
            }
            return count;
        }
        /// <summary>
        /// Returns all full words from the current <see cref="string"/> of text as an array
        /// skipping whitespaces.
        /// </summary>
        /// <param name="s">Text to analyze.</param>
        /// <returns>Array of words.</returns>
        public static string[] GetFullWords(this string s) {
            if (s.IsValid()) {
                return s.Split(' ').Where(x => x.IsValid()).ToArray();
            }
            return new string[0];
        }
        /// <summary>
        /// Truncates a <see cref="string"/> of text to a certain number of words and
        /// appends trailing text e.g(...) at the end to show continuation.
        /// </summary>
        /// <param name="s">Text to shorten</param>
        /// <param name="maxWords">Number of characters to take from the first index/start/zero</param>
        /// <param name="trailingText">Text to append to the tail of a truncated text</param>
        /// <returns>
        /// Shortened version of the supplied <see cref="string"/>
        /// </returns>
        public static string TruncateWords(this string s, int maxWords, string trailingText = Constants.TrailingText)
            => TruncateByWords(s, maxWords, trailingText);
        /// <summary>
        /// Truncates a <see cref="string"/> of text to a certain number of words and
        /// appends trailing text e.g(...) at the end to show continuation.
        /// </summary>
        /// <param name="s">Text to shorten</param>
        /// <param name="maxWords">Number of characters to take from the first index/start/zero</param>
        /// <param name="trailingText">Text to append to the tail of a truncated text</param>
        /// <returns>
        /// Shortened version of the supplied <see cref="string"/>
        /// </returns>
        public static string TruncateByWords(this string s, int maxWords, string trailingText = Constants.TrailingText)
        {
            if (s.IsValid()) {
                if(maxWords > 0) {
                    string[] words = s.GetFullWords();
                    if(words.Length > maxWords) {
                        return string.Join(" ", words.Take(maxWords)).Trim() + trailingText;
                    }
                }
                return s;
            }
            return s;
        }
        
        /// <summary>
        /// Converts a <see cref="string"/> of text to a byte[]
        /// </summary>
        /// <param name="s">Text to convert</param>
        /// <returns>
        /// Byte Array.
        /// </returns>
        public static byte[] ToByteArray(this string s) => Constants.Encoding.GetBytes(s);
        /// <summary>
        /// Converts a <see cref="string"/> to a byte[] and returns
        /// the result as a Base64 encoded <see cref="string"/> of text.
        /// </summary>
        /// <param name="s">Text to convert</param>
        /// <returns>Base64 encoded <see cref="string"/></returns>
        public static string ToBase64String(this string s) => Convert.ToBase64String(Constants.Encoding.GetBytes(s));
        /// <summary>
        /// Converts a Base64 encoded string to an equivalent byte[]
        /// </summary>
        /// <param name="s">base64 encoded string</param>
        /// <returns>byte array</returns>
        public static byte[] FromBase64ToArray(this string s) => Convert.FromBase64String(s);
        /// <summary>
        /// Trims a piece of <see cref="string"/> text from the location/index of where start
        /// is and returns all text after that.
        /// </summary>
        /// <param name="text">
        /// <see cref="string"/> to truncate
        /// </param>
        /// <param name="start">
        /// Text to find in this block and begin from.
        /// </param>
        /// <returns>
        /// Truncated block <see cref="string"/> having removed all text that behind the start location.
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string GetStringAfter(this string text, string start)
        {
            if (text.IsValid())
            {
                int index = text.IndexOf(start, Constants.StringComparison);
                if (index > -1)
                {
                    return text.Substring(index, text.Length - index).Trim();
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(start));
                }
            }
            throw new ArgumentNullException(nameof(text));
        }
        /// <summary>
        /// Trims a piece of <see cref="string"/> text from the location/index of where end
        /// is and returns all text before that.
        /// </summary>
        /// <param name="text">
        /// <see cref="string"/> to truncate.
        /// </param>
        /// <param name="end">
        /// Text to find in this block and end at.
        /// </param>
        /// <returns>
        /// Truncated block <see cref="string"/> having removed all text after end location
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string GetStringBefore(this string text, string end)
        {
            if (text.IsValid())
            {
                int index = text.IndexOf(end, Constants.StringComparison);
                if (index > -1)
                {
                    return text.Substring(0, index).Trim();
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(end));
                }
            }
            throw new ArgumentNullException(nameof(text));
        }
        /// <summary>
        /// Converts a <see cref="string"/> of text to a <see cref="Stream"/>
        /// </summary>
        /// <param name="s">Text to convert</param>
        /// <returns>
        /// A <see cref="Stream"/> or <see cref="MemoryStream"/>
        /// </returns>
        public static Stream ToStream(this string s) => new MemoryStream(s.ToByteArray());
        /// <summary>
        /// Tries to parse a <see cref="string"/> to <see cref="Guid"/>
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Guid? ToGuid(this string s)
        {
            if (s.IsValid())
            {
                bool isValid = Guid.TryParse(s, out Guid uuid);
                if (isValid)
                    return uuid;
            }
            return null;
        }

        /// <summary>
        /// Verify that Strings Are in Valid Email Format.
        /// </summary>
        /// <param name="email">Email string</param>
        /// <returns>
        /// Returns True if the <see cref="string"/> contains a valid email address and 
        /// False if it does not
        /// </returns>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="RegexMatchTimeoutException"/>
        public static bool IsEmailValid(this string email)
        {
            if (!email.IsValid())
                return false;
            try
            {
                // Derived from Microsoft Documentation. Use the link to get further explanation.
                // https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = new IdnMapping().GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
                return Regex.IsMatch(email, Constants.EmailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}