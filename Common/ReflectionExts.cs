using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Common
{
    /// <summary>
    /// Collection of extension methods that require Reflection to access class
    /// properties dynamically at runtime.
    /// </summary>
    public static class ReflectionExts
    {
        private static IDictionary<Type, List<PropertyDescriptor>> _cache =
            new ConcurrentDictionary<Type, List<PropertyDescriptor>>();

        /// <summary>
        /// Gets all <see cref="PropertyDescriptor"/> of a certain model class for 
        /// all its properties.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="class">Model class</param>
        /// <returns>Array</returns>
        public static PropertyDescriptor[] GetPropertyDescriptors<TClass>(this TClass @class)
            where TClass : class
        {
            PropertyDescriptorCollection collection = null;
            if (_cache.ContainsKey(typeof(TClass)))
                return _cache[typeof(TClass)].ToArray();
            else
                collection = TypeDescriptor.GetProperties(typeof(TClass));

            List<PropertyDescriptor> properties = new List<PropertyDescriptor>();
            for (int i = 0; i < collection.Count; i++)
            {
                properties.Add(collection[i]);
            }
            _cache.Add(typeof(TClass), properties);
            return _cache[typeof(TClass)].ToArray();
        }
        /// <summary>
        /// Returns the value of a specific class property using a delegate
        /// to access class properties by Reflection.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="class">Object value of type TClass</param>
        /// <param name="propertyName">Property name to return value of.</param>
        /// <returns></returns>
        public static TProperty GetPropertyValue<TClass, TProperty>(this TClass @class, string propertyName)
            where TClass : class
        {
            PropertyDescriptor prop = GetDescriptor(@class, propertyName);
            if (prop != null)
            {
                object obj = prop.GetValue(@class);
                if (obj != null)
                {
                    return (TProperty)obj;
                }
            }
            return default(TProperty);
        }

        /// <summary>
        /// Sets the value of a specific class property using an <see cref="Action"/> to access
        /// and assign class properties by Reflection.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="class"></param>
        /// <param name="propertyName">Property name to assign value to.</param>
        /// <param name="newValue">Value to assign the specified property.</param>
        public static void SetPropertyValue<TClass, TValue>(this TClass @class, string propertyName, TValue newValue)
            where TClass : class
        {
            SetPropertyValue(@class, propertyName, typeof(TValue), newValue);
        }
        /// <summary>
        /// Sets the value of a specific class property using an <see cref="Action"/> to access
        /// and assign class properties by Reflection.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="class"></param>
        /// <param name="propertyName">Property name to assign value to.</param>
        /// <param name="propType"><see cref="Type"/> of target property</param>
        /// <param name="newValue">Value to assign the specified property.</param>
        /// <exception cref="InvalidCastException"></exception>
        /// <exception cref="Exception"></exception>
        public static void SetPropertyValue<TClass>(this TClass @class, string propertyName, Type propType, object newValue)
            where TClass : class
        {
            PropertyDescriptor prop = GetDescriptor(@class, propertyName);
            try
            {
                if (prop != null)
                {
                    prop.SetValue(@class, Convert.ChangeType(newValue, Nullable.GetUnderlyingType(propType) ?? propType));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Gets the <see cref="PropertyDescriptor"/> of a specified property in a class.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="class">Model class</param>
        /// <param name="prop">Property Name</param>
        /// <returns><see cref="PropertyDescriptor"/></returns>
        public static PropertyDescriptor GetDescriptor<TClass>(this TClass @class, string prop)
            where TClass : class
        {
            return GetPropertyDescriptors(@class).FirstOrDefault(x => x.Name == prop);
        }
        /// <summary>
        /// Gets all attributes of a certain class property.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="class"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static IEnumerable<TAttribute> GetAttributes<TClass, TAttribute>(this TClass @class, string prop)
            where TClass : class
            where TAttribute : Attribute
        {
            List<TAttribute> attributes = new List<TAttribute>();
            var enumerator = @class.GetDescriptor(prop).Attributes.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Current.GetType() == typeof(TAttribute))
                    attributes.Add((TAttribute)enumerator.Current);
            }
            return attributes;
        }
    }
}