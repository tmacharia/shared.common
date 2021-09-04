using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.Linq
{
    /// <summary>
    /// Represents extension methods for elements that are considered as collections and 
    /// mostly inherit from <see cref="IEnumerable"/>
    /// </summary>
    public static class CollectionExts
    {
        /// <summary>
        /// Determines whether any item exists in the sequence that satisfies 
        /// the specified predicate condition.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the collection.</typeparam>
        /// <param name="enumerable">Collection</param>
        /// <param name="predicate">Predicate function for evaluation.</param>
        /// <returns>
        /// true if any elements in the source sequence pass the test in the specified predicate; otherwise, false.
        /// </returns>
        public static bool Contains<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
                => enumerable != null && enumerable.Any(predicate);
        /// <summary>
        /// Steps through the collection subjecting each item to the <see cref="Action"/>
        /// specified.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the collection.</typeparam>
        /// <param name="enumerable"></param>
        /// <param name="action">Function/method to execute on each item in the collection.</param>
        /// <exception cref="InvalidOperationException"/>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null)
                return;

            IEnumerator<T> enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                action(enumerator.Current);
            }
        }
        /// <summary>
        /// Steps through the collection subjecting each item to the <see cref="Action"/>
        /// specified.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the collection.</typeparam>
        /// <param name="enumerable"></param>
        /// <param name="action">Delegate method that receives both the index and current item in the collection.</param>
        /// <exception cref="InvalidOperationException"/>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<int,T> action)
        {
            if (enumerable == null)
                return;

            int n = 0;
            IEnumerator<T> enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                action(n, enumerator.Current);
                n++;
            }
        }
        /// <summary>
        /// Remove all items in a collection that matches a specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the collection.</typeparam>
        /// <param name="enumerable">Collection to filter</param>
        /// <param name="predicate">Predicate of items to remove.</param>
        /// <returns>Filtered collection</returns>
        public static IEnumerable<T> RemoveWherePredicate<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
        {
            int index = enumerable.GetIndexOf(predicate);
            if (index > -1)
                return enumerable.Where((item, i) => i != index);
            return enumerable;
        }
        /// <summary>
        /// Searches for an element matchind the specified predicate and returns a zero based
        /// index of the first occurence within the collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the collection.</typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate">Condition predicate</param>
        /// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by match, 
        /// if found; otherwise, -1.
        /// </returns>
        public static int GetIndexOf<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
            => enumerable.GetIndexOf(new Predicate<T>(predicate));
        /// <summary>
        /// Searches for an element matchind the specified predicate and returns a zero based
        /// index of the first occurence within the collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the collection.</typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate">The <see cref="Predicate{T}"/> that defines the conditions of the element to search for.
        /// </param>
        /// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by match, 
        /// if found; otherwise, -1.
        /// </returns>
        /// <exception cref="ArgumentNullException"/>
        public static int GetIndexOf<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
            => Array.FindIndex(enumerable.ToArray(), predicate);
        /// <summary>
        /// Remove all items in a collection that matches a specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the collection.</typeparam>
        /// <param name="enumerable">Collection to filter</param>
        /// <param name="predicate">Predicate of items to remove.</param>
        /// <returns>Filtered collection</returns>
        public static IEnumerable<T> RemoveWhere<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
                => enumerable != null ? enumerable.Any(predicate) ?
                   enumerable.SkipWhile(predicate) : enumerable : null;
        /// <summary>
        /// Converts any collection that inherits <see cref="IEnumerable"/> to an <see cref="ObservableCollection{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements of the collection.</typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
            => new ObservableCollection<T>(enumerable);
    }
}