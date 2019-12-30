using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    /// <summary>
    /// Contains general extension methods and utilities.
    /// </summary>
    public static class GeneralUtils
    {
        /// <summary>
        /// Instance of MD5 Hash Algorithm.
        /// </summary>
        public static MD5 md5 = MD5.Create();
        /// <summary>
        /// Checks if an object is not null
        /// </summary>
        /// <param name="value">Object to check</param>
        /// <returns>true or false</returns>
        public static bool IsNotNull(this object value) => value != null;
        /// <summary>
        /// Checks if an object is null
        /// </summary>
        /// <param name="value"><see cref="object"/> to check</param>
        /// <returns></returns>
        public static bool IsNull(this object value) => value == null;
        /// <summary>
        /// Serializes an object of generic type to JSON <see cref="string"/>
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="value">Object/Model/Item to serialize</param>
        /// <returns>JSON text</returns>
        public static string ToJson<T>(this T value) where T : class
                => JsonConvert.SerializeObject(value, Formatting.Indented);
        /// <summary>
        /// Deserializes JSON formatted <see cref="string"/> of text to a strongly typed
        /// generic of 
        /// </summary>
        /// <typeparam name="T">Type to deserialize to</typeparam>
        /// <param name="json">JSON text</param>
        /// <returns></returns>
        public static T DeserializeTo<T>(this string json)
                => JsonConvert.DeserializeObject<T>(json,
                    new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        /// <summary>
        /// Converts a decimal number to an integer
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <returns>Integral equivalent</returns>
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
        /// Formats an <see cref="int"/> to a comma separated string.
        /// </summary>
        /// <param name="i">Integer value to format</param>
        /// <returns>Formatted <see cref="string"/></returns>
        public static string ToCommaSeparated(this int i)
            => ToCommaSeparated(i);

        /// <summary>
        /// Formats an <see cref="long"/> to a comma separated string.
        /// </summary>
        /// <param name="l">Long value to format</param>
        /// <returns>Formatted <see cref="string"/></returns>
        public static string ToCommaSeparated(this long l)
            => l.ToString("N0", Constants.Culture);

        /// <summary>
        /// Formats an <see cref="double"/> to a comma separated string.
        /// </summary>
        /// <param name="d">Double value to format</param>
        /// <param name="precision">Number of decimal places to keep</param>
        /// <returns>Formatted <see cref="string"/></returns>
        public static string ToCommaSeparated(this double d, int precision = 2)
            => d.ToString($"N{precision}", Constants.Culture);

        /// <summary>
        /// Formats an <see cref="decimal"/> to a comma separated string.
        /// </summary>
        /// <param name="d">Decimal value to format</param>
        /// <param name="precision">Number of decimal places to keep</param>
        /// <returns>Formatted <see cref="string"/></returns>
        public static string ToCommaSeparated(this decimal d, int precision = 2)
            => d.ToString($"N{precision}", Constants.Culture);

        /// <summary>
        /// Reflects all the properties in a model of generic <see cref="Type"/> that must be
        /// a class and returns a <see cref="IDictionary{TKey, TValue}"/> pairs 
        /// collection mapped in the following way:
        /// 
        /// Key: PropertyName,
        /// Value: PropertyValue
        /// </summary>
        /// <typeparam name="T">Type of model</typeparam>
        /// <param name="model">Model to reflect</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IDictionary<string, string> ToDictionary<T>(this T model)
            where T : class
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            Dictionary<string, string> pairs = new Dictionary<string, string>();
            PropertyDescriptor[] props = typeof(T).GetPropertyDescriptors();
            for (int i = 0; i < props.Length; i++)
            {
                string name = props[i].Name;
                pairs.Add(name, model.GetPropertyValue<T, string>(name));
            }
            return pairs;
        }
        /// <summary>
        /// Converts a series of bytes to human readable notation. e.g 45KB, 3.5GB
        /// </summary>
        /// <param name="byteCount"></param>
        /// <returns></returns>
        [Obsolete("Use the data formatting methods in Common.Primitives; .ConvertData() or .HumanizeData()")]
        public static string BytesToString(this long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        public static string ToHuman(this int n) => n.ToString("N0", Properties.Resources.Culture);
        public static string ToHuman(this long n) => n.ToString("N0", Properties.Resources.Culture);
        public static string ToHuman(this ulong n) => n.ToString("N0", Properties.Resources.Culture);
        public static string ToHuman(this double d) => d.ToString("N0", Properties.Resources.Culture);
        public static string ToHuman(this double d, int precision = 2) => d.ToString($"N{precision}", Properties.Resources.Culture);
        public static string PadInt(this long? l) => l.HasValue ? PadInt((int)l.Value) : PadInt(0);
        public static string PadInt(this long l) => PadInt((int)l);
        public static string PadInt(this int n, bool padded = true) => padded ? n > 9 ? n.ToString("N0", Properties.Resources.Culture) : $"0{n}" : n.ToString(Properties.Resources.Culture);
        public static string SecondsToMoment(this double d)
        {
            int hrs = (int)(d / (60 * 60));
            if (hrs > 0)
            {
                return hrs == 1 ? "1 hr" : $"{hrs} hrs";
            }
            int mins = (int)(d / 60);
            if (mins > 0)
            {
                return mins == 1 ? "1 min" : $"{mins} mins";
            }
            int secs = (int)d;
            if (secs > 0)
            {
                return secs == 1 ? "1 sec" : $"{secs} secs";
            }
            return string.Empty;
        }
        public static string TimespanMoment(this TimeSpan span)
        {
            StringBuilder sb = new StringBuilder();
            if (span.Hours > 0)
            {
                sb.Append(span.Hours);
                sb.Append(" ");
                sb.Append(span.Hours == 1 ? "hr" : "hrs");
                sb.Append(" ");
                sb.Append(span.Minutes);
                sb.Append(" ");
                sb.Append(span.Minutes == 1 ? "min" : "mins");
            }
            else if (span.Minutes > 0)
            {
                sb.Append(span.Minutes);
                sb.Append(" ");
                sb.Append(span.Minutes == 1 ? "min" : "mins");
                sb.Append(" ");
                sb.Append(span.Seconds);
                sb.Append(" ");
                sb.Append(span.Seconds == 1 ? "sec" : "secs");
            }
            else if (span.Seconds > 0)
            {
                sb.Append(span.Seconds);
                sb.Append(" ");
                sb.Append(span.Seconds == 1 ? "sec" : "secs");
            }
            return sb.ToString();
        }
        public static ObservableCollection<T> RemoveWherePredicate<T>(this ObservableCollection<T> ts, Func<T, bool> predicate)
        {
            int index = ts.GetIndexOf(predicate);
            if (index > -1)
            {
                ts.RemoveAt(index);
            }
            return ts;
        }
        public static List<T> RemoveWherePredicate<T>(this List<T> ts, Func<T, bool> predicate)
        {
            int index = ts.GetIndexOf(predicate);
            if (index > -1)
            {
                ts.RemoveAt(index);
            }
            return ts;
        }
        public static int GetIndexOf<T>(this IEnumerable<T> ts, Func<T, bool> predicate)
        {
            int total = ts.Count();
            for (int i = 0; i < total - 1; i++)
            {
                var item = ts.ElementAt(i);
                if (predicate(item))
                {
                    return i;
                }
            }
            return -1;
        }
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> ts)
            => new ObservableCollection<T>(ts);
    }
}