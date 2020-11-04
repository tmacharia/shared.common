using Common.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Common
{
    /// <summary>
    /// Contains general extension methods and utilities.
    /// </summary>
    public static class GeneralUtils
    {
        /// <summary>
        /// Checks if an object is not null
        /// </summary>
        /// <param name="value">Object to check</param>
        /// <returns>true or false</returns>
        [Obsolete]
        public static bool IsNotNull(this object value) => value != null;
        /// <summary>
        /// Checks if an object is null
        /// </summary>
        /// <param name="value"><see cref="object"/> to check</param>
        /// <returns></returns>
        [Obsolete]
        public static bool IsNull(this object value) => value == null;
        
        /// <summary>
        /// Converts a decimal number to an integer
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <returns>Integral equivalent</returns>
        [Obsolete]
        public static int? ToInt(this object value) =>
            value.IsNotNull() ? Convert.ToInt32(value, Constants.Culture) : 0;

        /// <summary>
        /// Checks if an object is of the specified <see cref="Type"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsOfType<T>(this object obj) where T : class
            => obj.GetType() == typeof(T);

        /// <summary>
        /// Formats an <see cref="int"/> to a comma separated <see cref="string"/> using the current culture
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string ToHuman(this int n) => n.ToString("N0", Resources.Culture);
        /// <summary>
        /// Formats a <see cref="long"/> to a comma separated <see cref="string"/> using the current culture
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string ToHuman(this long n) => n.ToString("N0", Resources.Culture);
        /// <summary>
        /// Formats a <see cref="ulong"/> to a comma separated <see cref="string"/> using the current culture
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string ToHuman(this ulong n) => n.ToString("N0", Resources.Culture);
        /// <summary>
        /// Formats a <see cref="double"/> to a comma separated <see cref="string"/> using the current
        /// culture with 0 decimal places.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToHuman(this double d) => d.ToString("N0", Resources.Culture);
        /// <summary>
        /// Formats a <see cref="double"/> to a comma separated <see cref="string"/> using the current
        /// culture
        /// </summary>
        /// <param name="d"></param>
        /// <param name="precision">Number of decimal places</param>
        /// <returns></returns>
        public static string ToHuman(this double d, int precision = 2) => d.ToString($"N{precision}", Resources.Culture);
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
        public static string PadInt(this int n, bool padded = true) => padded ? n > 9 ? n.ToString("N0", Resources.Culture) : $"0{n}" : n.ToString(Resources.Culture);
        
    }
}