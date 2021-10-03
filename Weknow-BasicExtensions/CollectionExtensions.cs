using System.Collections.Generic;

namespace System.Collections
{
    public static class CollectionExtensions
    {
        #region AsYield

        /// <summary>
        /// Converts to yield (IEnumerable) with single item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public static IEnumerable<T> AsYield<T>(this T item)
        {
            yield return item;
        }

        #endregion // AsYield

        #region ToYield

        /// <summary>
        /// <![CDATA[ Concatenates non-sequential data with a sequences.
        /// Extend IEnumerable<T>.Concat which in this case has to allocate collection for the Concatenation.]]>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        /// <paramref name="item2" />
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
        ///  <![CDATA[Concatenates non-sequential data with a sequences.
        /// Extend IEnumerable<T>.Concat which in this case has to allocate collection for the Concatenation.]]>
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
        /// <![CDATA[Concatenates non-sequential data with a sequences.
        /// Extend IEnumerable<T>.Concat which in this case has to allocate collection for the Concatenation.]]>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        /// <paramref name="item2" />
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
        /// <![CDATA[Concatenates non-sequential data with a sequences.
        /// Extend IEnumerable<T>.Concat which in this case has to allocate collection for the Concatenation.]]>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="item3">The item3.</param>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        /// <paramref name="item2" />
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
        /// <![CDATA[Concatenates non-sequential data with a sequences.
        /// Extend IEnumerable<T>.Concat which in this case has to allocate collection for the Concatenation.]]>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="item3">The item3.</param>
        /// <param name="item4">The item4.</param>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        /// <paramref name="item2" />
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
