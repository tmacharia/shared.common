using Common;

namespace System.Formatting
{
    /// <summary>
    /// 
    /// </summary>
    public static class PrimitivesFormatting
    {
        /// <summary>
        /// Formats an <see cref="int"/> to a comma separated <see cref="string"/> using the current culture
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string ToHuman(this int n) => n.ToString("N0", Constants.Culture);
        /// <summary>
        /// Formats a <see cref="long"/> to a comma separated <see cref="string"/> using the current culture
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string ToHuman(this long n) => n.ToString("N0", Constants.Culture);
        /// <summary>
        /// Formats a <see cref="ulong"/> to a comma separated <see cref="string"/> using the current culture
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string ToHuman(this ulong n) => n.ToString("N0", Constants.Culture);
        /// <summary>
        /// Formats a <see cref="double"/> to a comma separated <see cref="string"/> using the current
        /// culture with 0 decimal places.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToHuman(this double d) => d.ToString("N0", Constants.Culture);
        /// <summary>
        /// Formats a <see cref="double"/> to a comma separated <see cref="string"/> using the current
        /// culture
        /// </summary>
        /// <param name="d"></param>
        /// <param name="precision">Number of decimal places</param>
        /// <returns></returns>
        public static string ToHuman(this double d, int precision = 2) => d.ToString($"N{precision}", Constants.Culture);
    }
}