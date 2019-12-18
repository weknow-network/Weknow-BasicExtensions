using System;
using System.Collections.Generic;
using System.Linq;

namespace System.Collections
{
    public static class CollectionExtensions
    {
        #region ToYield

        /// <summary>
        /// Concatenates non-sequential data with a sequences.
        /// Extend IEnumerable<T>.Concat which in this case has to allocate collection for the Concatenation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1"/>
        /// <paramref name="item2"/>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        /// <example>
        /// Instead of :
        /// new [] {1}.Concat(new[]{2, 3}))
        /// Use:
        /// 1.ToYield(2, 3))
        /// </example>
        public static IEnumerable<T> ToYield<T>(this T item1, T item2, params T[] items)
        {
            yield return item1;
            yield return item2;
            foreach (var element in items)
            {
                yield return element;
            }
        }

        /// <summary>
        /// Concatenates non-sequential data with a sequences.
        /// Extend IEnumerable<T>.Concat which in this case has to allocate collection for the Concatenation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        /// <example>
        /// Instead of :
        /// new [] {1}.Concat(Enumerable.Range(2,4))
        /// Use:
        /// 1.ToYield(Enumerable.Range(2,4))
        /// </example>
        public static IEnumerable<T> ToYield<T>(this T item, IEnumerable<T> items)
        {
            yield return item;
            foreach (var element in items)
            {
                yield return element;
            }
        }

        /// <summary>
        /// Concatenates non-sequential data with a sequences.
        /// Extend IEnumerable<T>.Concat which in this case has to allocate collection for the Concatenation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1"/>
        /// <paramref name="item2"/>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        /// <example>
        /// Instead of :
        /// new [] {1, 2}.Concat(Enumerable.Range(3,10))
        /// Use:
        /// 1.ToYield(2,Enumerable.Range(3, 10))
        /// </example>
        public static IEnumerable<T> ToYield<T>(this T item1, T item2, IEnumerable<T> items)
        {
            yield return item1;
            yield return item2;
            foreach (var element in items)
            {
                yield return element;
            }
        }

        /// <summary>
        /// Concatenates non-sequential data with a sequences.
        /// Extend IEnumerable<T>.Concat which in this case has to allocate collection for the Concatenation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1"/>
        /// <paramref name="item2"/>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        /// <example>
        /// Instead of :
        /// new [] {1, 2, 3}.Concat(Enumerable.Range(4,10))
        /// Use:
        /// 1.ToYield(2, 3, Enumerable.Range(4, 10))
        /// </example>
        public static IEnumerable<T> ToYield<T>(this T item1, T item2, T item3, IEnumerable<T> items)
        {
            yield return item1;
            yield return item2;
            yield return item3;
            foreach (var element in items)
            {
                yield return element;
            }
        }

        /// <summary>
        /// Concatenates non-sequential data with a sequences.
        /// Extend IEnumerable<T>.Concat which in this case has to allocate collection for the Concatenation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1"/>
        /// <paramref name="item2"/>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        /// <example>
        /// Instead of :
        /// new [] {1, 2, 3, 4}.Concat(Enumerable.Range(5,10))
        /// Use:
        /// 1.ToYield(2, 3, 4, Enumerable.Range(5, 10))
        /// </example>
        public static IEnumerable<T> ToYield<T>(this T item1, T item2, T item3, T item4, IEnumerable<T> items)
        {
            yield return item1;
            yield return item2;
            yield return item3;
            yield return item4;
            foreach (var element in items)
            {
                yield return element;
            }
        }

        #endregion // ToYield
    }
}
