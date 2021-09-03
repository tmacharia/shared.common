using Common;

namespace System.Extensions
{
    /// <summary>
    /// Contains general extension methods and utilities.
    /// </summary>
    public static class GeneralUtils
    {
        /// <summary>
        /// Checks if an object is of the specified <see cref="Type"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsOfType<T>(this object obj) where T : class
            => obj.GetType() == typeof(T);

        /// <summary>
        /// Formats a nullable <see cref="long"/> based by adding a zero before it if it's less than 10.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static string PadInt(this long? l) => l.HasValue ? PadInt((int)l.Value) : PadInt(0);
        /// <summary>
        /// Formats a <see cref="long"/> based by adding a zero before it if it's less than 10.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static string PadInt(this long l) => PadInt((int)l);
        /// <summary>
        /// Formats a number based on whether it's less than 10 by adding a padded zero
        /// at the front of the number.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="padded">Whether to pad or not.</param>
        /// <returns></returns>
        public static string PadInt(this int n, bool padded = true) => padded ? n > 9 ? n.ToString("N0", Constants.Culture) : $"0{n}" : n.ToString(Constants.Culture);
    }
}