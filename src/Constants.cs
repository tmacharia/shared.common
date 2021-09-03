using System;
using System.Globalization;
using System.Text;

namespace Common
{
    /// <summary>
    /// Collection of variables and resources available to any project and supplied immediately
    /// the application starts.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Represents a pseudo-random number generator.
        /// </summary>
        [ContextStatic]
        public static Random random = new Random();
        /// <summary>
        /// Trailing text to append to shortened text.
        /// </summary>
        public const string TrailingText = "...";
        /// <summary>
        /// String Comparison Ordinal.
        /// </summary>
        public static StringComparison StringComparison { get; set; } = StringComparison.Ordinal;
        /// <summary>
        /// String Comparison IgnoreCase.
        /// </summary>
        public static StringComparison StringComparisonIgnoreCase { get; } = StringComparison.OrdinalIgnoreCase;
        /// <summary>
        /// Current UI Thread <see cref="CultureInfo"/>
        /// </summary>
        public static CultureInfo Culture => Properties.Resources.Culture;
        
        /// <summary>
        /// Base UTF8 Encoding to re-use.
        /// </summary>
        public static Encoding Encoding { get; } = new UTF8Encoding();
        /// <summary>
        /// Regex expression to verify valid email addresses.
        /// </summary>
        public const string EmailRegex =
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))"
          + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        /// <summary>
        /// Regex expression to verify valid url addresses.
        /// </summary>
        public const string UrlRegex = @"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})";
    }
}