using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Common
{
    /// <summary>
    /// Contains extensions methods for any json related strings.
    /// </summary>
    public static class JsonExts
    {
        /// <summary>
        /// Checks if a <see cref="string"/> or text is valid json in terms of formatting.
        /// </summary>
        /// <param name="json">Text <see cref="string"/> to validate.</param>
        /// <returns>True if valid and False if invalid.</returns>
        /// <exception cref="JsonReaderException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool IsValidJson(this string json) {
            json = json.Trim();
            if ((json.StartsWith("{") && json.EndsWith("}")) || (json.StartsWith("[") && json.EndsWith("]"))) {
                try {
                    var obj = JToken.Parse(json);
                    return true;
                }
                catch (JsonReaderException) { }
                catch (Exception) { }
            }
            return false;
        }
        /// <summary>
        /// Serializes an object of generic type to JSON <see cref="string"/>
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="value">Object/Model/Item to serialize</param>
        /// <returns>JSON text</returns>
        public static string ToJson<T>(this T value) where T : class
                => value.ToJson(Formatting.Indented);
        /// <summary>
        /// Serializes an object of generic type to JSON <see cref="string"/>
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="value">Object/Model/Item to serialize</param>
        /// <returns>JSON text</returns>
        public static string ToJson<T>(this T value, Formatting formatting) where T : class
                => JsonConvert.SerializeObject(value, formatting);
        /// <summary>
        /// Serializes an object of generic type to JSON <see cref="string"/>
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="value">Object/Model/Item to serialize</param>
        /// <returns>JSON text</returns>
        public static string ToJson<T>(this T value, JsonSerializerSettings settings) where T : class
                => JsonConvert.SerializeObject(value, settings);
        public static string ToJsonUnIndented<T>(this T model) where T : class
                => JsonConvert.SerializeObject(model, Formatting.None);
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
    }
}