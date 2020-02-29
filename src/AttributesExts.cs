using Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Common
{
    /// <summary>
    /// Collection of extension methods for class property attributes.
    /// </summary>
    public static class AttributesExts
    {
        private static readonly Dictionary<string, FieldInfo> _fieldsCache = new Dictionary<string, FieldInfo>();
        /// <summary>
        /// Gets the value of <see cref="SymbolAttribute"/> for the specified property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Property</param>
        /// <returns>Value of symbol.</returns>
        public static string GetSymbolAttribute<T>(this T source) where T : Enum
        {
            FieldInfo fi = null;
#if NETSTANDARD1_5 || NETSTANDARD1_6
            fi = source.GetType().GetRuntimeField(source.ToString());
#else
            fi = source.GetType().GetField(source.ToString());
#endif
            
            SymbolAttribute[] attributes = (SymbolAttribute[])fi.GetCustomAttributes(
                typeof(SymbolAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Symbol;
            else return source.ToString();
        }
        /// <summary>
        /// Gets the description text of <see cref="DescriptionAttribute"/> for the specified property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Property</param>
        /// <returns>Value of Description</returns>
        public static string DescriptionAttr<T>(this T source) where T : Enum
            => DescriptionAttr(typeof(T), source.ToString());
        /// <summary>
        /// Gets the description text of <see cref="DescriptionAttribute"/> for the specified property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Property</param>
        /// <returns>Value of Description</returns>
        public static string DescriptionAttr(Type enumType,string propName)
        {
            FieldInfo fi = null;
            string fieldName = $"{enumType.Name}-{propName}";
            if (_fieldsCache.ContainsKey(fieldName))
                fi = _fieldsCache[fieldName];
            else
            {
#if NETSTANDARD1_5 || NETSTANDARD1_6
                fi = typeof(T).GetRuntimeField(source.ToString());
#else
                fi = enumType.GetField(propName);
#endif
                if (fi != null)
                    _fieldsCache.Add(fieldName, fi);
            }
            if (fi != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                    return attributes[0].Description;
            }
            return propName;
        }
    }
}