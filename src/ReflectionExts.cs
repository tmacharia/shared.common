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
            where TClass : class {
            PropertyDescriptorCollection props;
            if (_cache.ContainsKey(typeof(TClass)))
                return _cache[typeof(TClass)].ToArray();
            else
                props = TypeDescriptor.GetProperties(typeof(TClass));

            List<PropertyDescriptor> properties = new List<PropertyDescriptor>();
            for (int i = 0; i < props.Count; i++) {
                Type prop = props[i].PropertyType;
                if (prop.IsPublic && prop.IsSerializable) {
                    properties.Add(props[i]);
                }
            }
            _cache.Add(typeof(TClass), properties);
            return _cache[typeof(TClass)].ToArray();
        }
        /// <summary>
        /// Returns the <see cref="Type"/> of the specified <paramref name="propertyName"/> 
        /// on this model.
        /// </summary>
        /// <typeparam name="TClass">Type of current model.</typeparam>
        /// <param name="class">Current model.</param>
        /// <param name="propertyName">Name of the property to check.</param>
        /// <returns>Property Type.</returns>
        public static Type GetPropertyType<TClass>(this TClass @class, string propertyName)
            where TClass : class {
            PropertyDescriptor prop = GetDescriptor(@class, propertyName);
            if(prop == null)
                throw new Exception($"Property '{propertyName}' was not found on model '{typeof(TClass).FullName}'");

            return prop.PropertyType;
        }
        /// <summary>
        /// Returns the value of a specific class property using a delegate
        /// to access class properties by Reflection.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="class">Object value of type TClass</param>
        /// <param name="propertyName">Property name to return value of.</param>
        /// <returns>Value of specified property.</returns>
        public static TProperty GetPropertyValue<TClass, TProperty>(this TClass @class, string propertyName)
            where TClass : class {
            object obj = @class.GetPropertyValue(propertyName);
            if (obj != null) {
                return (TProperty)obj;
            }
            return default(TProperty);
        }
        /// <summary>
        /// Returns the value of a specific class property using a delegate
        /// to access class properties by Reflection.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="class">Object value of type TClass</param>
        /// <param name="propertyName">Property name to return value of.</param>
        /// <returns><see cref="object"/> value of specified property.</returns>
        public static object GetPropertyValue<TClass>(this TClass @class, string propertyName)
            where TClass : class {
            PropertyDescriptor prop = GetDescriptor(@class, propertyName);
            if(prop != null) {
                return prop.GetValue(@class);
            }
            return null;
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
        /// <exception cref="InvalidCastException"></exception>
        /// <exception cref="Exception"></exception>
        public static void SetPropertyValue<TClass, TValue>(this TClass @class, string propertyName, TValue newValue)
            where TClass : class => SetPropertyValue(@class, propertyName, typeof(TValue), newValue);

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
        public static void SetPropertyValue<TClass>(this TClass @class, string propertyName, Type propType, object newValue) where TClass : class {
            PropertyDescriptor prop = GetDescriptor(@class, propertyName);
            try {
                if (prop != null) {
                    prop.SetValue(@class, ChangeType(newValue, propType));
                }
            }
            catch (Exception e) {
                throw e;
            }
        }
        /// <summary>
        /// Sets the value of a specific class property using an <see cref="Action"/> to access
        /// and assign class properties by Reflection.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="class"></param>
        /// <param name="propertyName">Property name to assign value to.</param>
        /// <param name="newValue">Value to assign the specified property.</param>
        /// <exception cref="InvalidCastException"></exception>
        /// <exception cref="Exception"></exception>
        public static void SetPropertyValue<TClass>(this TClass @class, string propertyName, object newValue)
            where TClass : class {
            PropertyDescriptor prop = GetDescriptor(@class, propertyName);
            try {
                if(prop != null) {
                    Type propType = prop.PropertyType;
                    prop.SetValue(@class, ChangeType(newValue,propType));
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        private static object ChangeType(object value, Type type)
        {
            if (value == null && type.IsGenericType) return Activator.CreateInstance(type);
            if (value == null) return null;
            if (type == value.GetType()) return value;
            if (type.IsEnum)
            {
                if (value is string)
                    return Enum.Parse(type, value as string);
                else
                    return Enum.ToObject(type, value);
            }
            if (!type.IsInterface && type.IsGenericType)
            {
                Type innerType = type.GetGenericArguments()[0];
                object innerValue = ChangeType(value, innerType);
                return Activator.CreateInstance(type, new object[] { innerValue });
            }
            if (value is string && type == typeof(Guid)) return new Guid(value as string);
            if (value is string && type == typeof(Version)) return new Version(value as string);
            if (!(value is IConvertible)) return value;
            
            return Convert.ChangeType(value, Nullable.GetUnderlyingType(type) ?? type);
        }
        /// <summary>
        /// Gets the <see cref="PropertyDescriptor"/> of a specified property in a class.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="class">Model class</param>
        /// <param name="prop">Property Name</param>
        /// <returns><see cref="PropertyDescriptor"/></returns>
        private static PropertyDescriptor GetDescriptor<TClass>(this TClass @class, string prop)
            where TClass : class => GetPropertyDescriptors(@class).FirstOrDefault(x => x.Name == prop);

        /// <summary>
        /// Gets all attributes of a certain class property.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="class"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        private static IEnumerable<TAttribute> GetAttributes<TClass, TAttribute>(this TClass @class, string prop)
            where TClass : class
            where TAttribute : Attribute {
            List<TAttribute> attributes = new List<TAttribute>();
            var enumerator = @class.GetDescriptor(prop).Attributes.GetEnumerator();

            while (enumerator.MoveNext()) {
                if (enumerator.Current.GetType() == typeof(TAttribute))
                    attributes.Add((TAttribute)enumerator.Current);
            }
            return attributes;
        }
    }
}