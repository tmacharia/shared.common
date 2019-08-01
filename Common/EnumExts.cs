using System;

namespace Common
{
    /// <summary>
    /// Represents extension methods on Enum objects
    /// </summary>
    public static class EnumExts
    {
        /// <summary>
        /// Returns the name of current/selected enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum">Current/Selected enum</param>
        /// <returns>Name of enum</returns>
        public static string GetName<TEnum>(this TEnum @enum) where TEnum : Enum
        {
            if (@enum == null)
                throw new ArgumentNullException(nameof(@enum));
            
            return Enum.GetName(typeof(TEnum), @enum);
        }
    }
}