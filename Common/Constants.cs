using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Common
{
    /// <summary>
    /// Collection of variables and resources available to any project and supplied immediately
    /// the application starts.
    /// </summary>
    public static class Constants
    {
        public static StringComparison StringComparison { get; set; } = StringComparison.Ordinal;
        public static StringComparison StringComparisonIgnoreCase { get; } = StringComparison.OrdinalIgnoreCase;
        public static CultureInfo Culture { get; } = Thread.CurrentThread.CurrentUICulture;
        public static Encoding Encoding { get; } = new UTF8Encoding();

        public static string EmailRegex = 
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))"
          + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
    }
}