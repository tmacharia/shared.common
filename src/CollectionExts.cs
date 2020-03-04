using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Common
{
    /// <summary>
    /// Represents extension methods for elements that are considered as collections and 
    /// mostly inherit from <see cref="IEnumerable"/>
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
        public static IEnumerable<T> RemoveWherePredicate<T>(this IEnumerable<T> ts, Predicate<T> predicate)
        {
            int index = ts.GetIndexOf(predicate);
            if (index > -1)
                return ts.Where((item, i) => i != index);
            return ts;
        }
        /// <summary>
        /// Searches for an element matchind the specified predicate and returns a zero based
        /// index of the first occurence within the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ts"></param>
        /// <param name="predicate">Condition predicate</param>
        /// <returns></returns>
        public static int GetIndexOf<T>(this IEnumerable<T> ts, Func<T, bool> predicate)
            => ts.GetIndexOf(new Predicate<T>(predicate));
        /// <summary>
        /// Searches for an element matchind the specified predicate and returns a zero based
        /// index of the first occurence within the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ts"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int GetIndexOf<T>(this IEnumerable<T> ts, Predicate<T> predicate)
            => Array.FindIndex(ts.ToArray(), predicate);
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
        /// <summary>
        /// Converts any collection that inherits <see cref="IEnumerable"/> to an <see cref="ObservableCollection{T}"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> ts)
            => new ObservableCollection<T>(ts);
    }
}