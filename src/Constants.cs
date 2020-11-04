using Common.Enums;
using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    /// <summary>
    /// Event handler delegate with no parameters and returns void.
    /// </summary>
    public delegate void EmptyEventHandler();
    /// <summary>
    /// Event handler delegate that receives an <see cref="int"/> parameter
    /// and returns void.
    /// </summary>
    /// <param name="n"></param>
    public delegate void IntEventHandler(int n);
    /// <summary>
    /// Event handler delegate that receives a <see cref="bool"/> parameter
    /// and returns void.
    /// </summary>
    /// <param name="b"></param>
    public delegate void BoolEventHandler(bool b);
    /// <summary>
    /// Event handler delegate that receives a <see cref="string"/> parameter
    /// and returns void.
    /// </summary>
    /// <param name="s"></param>
    public delegate void StringEventHandler(string s);
    /// <summary>
    /// Event handler delegate that receives a <see cref="decimal"/> parameter
    /// and returns void.
    /// </summary>
    /// <param name="d"></param>
    public delegate void DecimalEventHandler(decimal d);
    /// <summary>
    /// Event handler delegate that receives a <see cref="double"/> parameter
    /// and returns void.
    /// </summary>
    /// <param name="d"></param>
    public delegate void DoubleEventHandler(double d);
    /// <summary>
    /// Event handler delegate that receives a <see cref="byte"/> array parameter
    /// and returns void.
    /// </summary>
    /// <param name="bytes"></param>
    public delegate void BytesEventHandler(byte[] bytes);
    /// <summary>
    /// Event handler delegate that receives a <see cref="Stream"/> parameter
    /// and returns void.
    /// </summary>
    /// <param name="stream"></param>
    public delegate void StreamEventHandler(Stream stream);
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
        /// Instance of MD5 Hash Algorithm.
        /// </summary>
        public static MD5 md5 { get; } = MD5.Create();
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
        /// Gets the current <see cref="RegionInfo"/>
        /// </summary>
        [Obsolete("Consider migrating to 'ZoneExts.Region' as this properties will be removed from here soon")]
        public static RegionInfo Region => ZoneExts.Region;
        /// <summary>
        /// Current Country
        /// </summary>
        [Obsolete("Consider migrating to 'ZoneExts.CurrentCountry' as this properties will be removed from here soon")]
        public static Country CurrentCountry => ZoneExts.CurrentCountry;
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