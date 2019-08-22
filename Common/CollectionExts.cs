using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    /// <summary>
    /// Represents extension methods for elements that are considered as collections and 
    /// mostly inherit from <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class CollectionExts
    {
        /// <summary>
        /// Checks if the current collection has an item that matches the specified predicate.
        /// </summary>
        /// <typeparam name="T">Type of collection</typeparam>
        /// <param name="enumerable">Collection</param>
        /// <param name="predicate">Predicate function for evaluation.</param>
        /// <returns>true or false.</returns>
        public static bool Contains<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
                => enumerable.IsNotNull() ? enumerable.Any(predicate) : false;
        /// <summary>
        /// Steps through the collection subjecting each item to the <see cref="Action"/>
        /// specified.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="action">Function/method to execute on each item in the collection.</param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            int total = enumerable.Count();
            for (int i = 0; i < total; i++) {
                action(enumerable.ElementAt(i));
            }
        }
        /// <summary>
        /// Steps through the collection subjecting each item to the <see cref="Action"/>
        /// specified.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="action">Delegate method that receives both the index and current item in the collection.</param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<int,T> action)
        {
            int total = enumerable.Count();
            for (int i = 0; i < total; i++) {
                action(i,enumerable.ElementAt(i));
            }
        }
        /// <summary>
        /// Remove all items in a collection that matches a specified predicate.
        /// </summary>
        /// <typeparam name="T">Item <see cref="Type"/></typeparam>
        /// <param name="enumerable">Collection to filter</param>
        /// <param name="predicate">Predicate of items to remove.</param>
        /// <returns>Filtered collection</returns>
        public static IEnumerable<T> RemoveWhere<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
                => enumerable.IsNotNull() ? enumerable.Any(predicate) ?
                   enumerable.SkipWhile(predicate) : enumerable : null;
    }
}