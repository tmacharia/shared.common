using System.Collections;
using System.Collections.Generic;
using System.Reflection.Extensions;

namespace System.Extensions
{
    /// <summary>
    /// Represents extension methods on Enum objects
    /// </summary>
    public static class EnumExts
    {
        /// <summary>
        /// Returns the name of Current/Selected enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum">Current/Selected enum</param>
        /// <returns>Name of enum</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetName<TEnum>(this TEnum @enum)
            where TEnum : Enum 
            => GetName(typeof(TEnum), @enum);
        /// <summary>
        /// Returns the name of Current/Selected enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum">Current/Selected enum</param>
        /// <param name="propName"></param>
        /// <returns>Name of enum</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetFullName<TEnum>(this TEnum @enum, string propName)
            where TEnum : Enum
            => GetFullName(typeof(TEnum), propName);

        /// <summary>
        /// Returns the enum name with the specified corresponding <paramref name="valueToCheck"/>
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="valueToCheck">Value to check.</param>
        /// <returns>Enum Value Name.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetName<TEnum>(int valueToCheck)
            where TEnum : Enum 
            => GetName(typeof(TEnum), valueToCheck);

        /// <summary>
        /// Returns the enum name with the specified corresponding <paramref name="valueToCheck"/>
        /// </summary>
        /// <param name="enumType"><see cref="Type"/> of <see cref="Enum"/></param>
        /// <param name="valueToCheck">Value to check.</param>
        /// <returns>Enum Value Name.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetName(Type enumType, object valueToCheck) {
            if (enumType == null)
                throw new ArgumentNullException(nameof(enumType));
            if (!enumType.IsEnum)
                throw new ArgumentException("Not a valid enumeration type.");
            
            return Enum.GetName(enumType, valueToCheck);
        }
        /// <summary>
        /// Returns the enum name with the specified corresponding <paramref name="propName"/>
        /// </summary>
        /// <param name="enumType"><see cref="Type"/> of <see cref="Enum"/></param>
        /// <param name="propName">Value to check.</param>
        /// <returns>Enum Value Name.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetFullName(Type enumType, string propName)
        {
            if (enumType == null)
                throw new ArgumentNullException(nameof(enumType));
            if (!enumType.IsEnum)
                throw new ArgumentException("Not a valid enumeration type.");

            return AttributesExts.DescriptionAttr(enumType, propName);
        }

        /// <summary>
        /// Returns all the items defined in an <see cref="Enum"/> as a 
        /// dictionary collection of key value pairs.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum">Current enum value</param>
        /// <returns>Dictionary of enumeration.</returns>
        public static Dictionary<string, int> GetEnumPairs<TEnum>(this TEnum @enum)
            where TEnum : Enum 
            => GetEnumPairs<TEnum>();
        /// <summary>
        /// Returns all the items defined in an <see cref="Enum"/> as a 
        /// dictionary collection of key value pairs.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum">Current enum value</param>
        /// <returns>Dictionary of enumeration.</returns>
        public static Dictionary<int, string> GetEnumPairs2<TEnum>(this TEnum @enum)
            where TEnum : Enum
            => GetEnumPairs2<TEnum>();

        /// <summary>
        /// Returns all the items defined in an <see cref="Enum"/> as a 
        /// dictionary collection of key value pairs.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns>Dictionary of enumeration.</returns>
        public static Dictionary<string, int> GetEnumPairs<TEnum>()
            where TEnum : Enum 
            => GetEnumPairs(typeof(TEnum));
        /// <summary>
        /// Returns all the items defined in an <see cref="Enum"/> as a 
        /// dictionary collection of key value pairs.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns>Dictionary of enumeration.</returns>
        public static Dictionary<int, string> GetEnumPairs2<TEnum>()
            where TEnum : Enum
            => GetEnumPairs2(typeof(TEnum));

        /// <summary>
        /// Returns all the items defined in an <see cref="Enum"/> as a 
        /// dictionary collection of key value pairs.
        /// </summary>
        /// <param name="enumType">Enumeration <see cref="Type"/></param>
        /// <returns>Dictionary of enumeration.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="enumType"/> if null.</exception>
        /// <exception cref="ArgumentException">If <paramref name="enumType"/> is not of type enumeration.
        /// </exception>
        public static Dictionary<string,int> GetEnumPairs(Type enumType) {
            if (enumType == null)
                throw new ArgumentNullException(nameof(enumType));

            if (!enumType.IsEnum)
                throw new ArgumentException("The specified Type is not of type enumeration.", nameof(enumType));

            Dictionary<string, int> pairs = new Dictionary<string, int>();
            string[] names = Enum.GetNames(enumType);
            Array array = Enum.GetValues(enumType);

            for (int i = 0; i < names.Length; i++) {
                pairs.Add(names[i], (int)array.GetValue(i));
            }
            return pairs;
        }
        /// <summary>
        /// Returns all the items defined in an <see cref="Enum"/> as a 
        /// dictionary collection of key value pairs.
        /// </summary>
        /// <param name="enumType">Enumeration <see cref="Type"/></param>
        /// <returns>Dictionary of enumeration.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="enumType"/> if null.</exception>
        /// <exception cref="ArgumentException">If <paramref name="enumType"/> is not of type enumeration.
        /// </exception>
        public static Dictionary<int, string> GetEnumPairs2(Type enumType)
        {
            if (enumType == null)
                throw new ArgumentNullException(nameof(enumType));

            if (!enumType.IsEnum)
                throw new ArgumentException("The specified Type is not of type enumeration.", nameof(enumType));

            Dictionary<int, string> pairs = new Dictionary<int, string>();
            Array vals = Enum.GetValues(enumType);
            IEnumerator iter = vals.GetEnumerator();
            while (iter.MoveNext())
            {
                object obj = iter.Current;
                pairs.Add((int)obj, Enum.GetName(enumType, obj));
            }
            return pairs;
        }
    }
}