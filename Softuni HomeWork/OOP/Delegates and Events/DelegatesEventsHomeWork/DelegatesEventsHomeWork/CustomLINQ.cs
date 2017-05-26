using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesEventsHomeWork
{
    public static class CustomLINQ
    {
        /// <summary>
        /// WhereNot method
        /// </summary>

        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> func)
        {
            List<T> item = new List<T>();

            foreach (var elements in collection)
            {
                if (!func(elements))
                {
                    item.Add(elements);
                }
            }
            return item;
        }

        //

        public static TSelector Max<TSource, TSelector>(
             this IEnumerable<TSource> collection,
             Func<TSource, TSelector> criterion) where TSelector : IComparable<TSelector>
        {
            TSelector max = criterion(collection.First());

            foreach (var item in collection.Where(item => max.CompareTo(criterion(item)) < 0))
            {
                max = criterion(item);
            }

            return max;
        }



    }
}