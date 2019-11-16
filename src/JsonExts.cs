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
        public static bool IsValidJson(this string json)
        {
            json = json.Trim();
            if ((json.StartsWith("{") && json.EndsWith("}")) || (json.StartsWith("[") && json.EndsWith("]")))
            {
                try
                {
                    var obj = JToken.Parse(json);
                    return true;
                }
                catch (JsonReaderException) { }
                catch (Exception) { }
            }
            return false;
        }
    }
}