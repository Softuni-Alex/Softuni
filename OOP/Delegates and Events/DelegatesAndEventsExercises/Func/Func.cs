using System;
using System.Collections.Generic;

namespace Func
{
    public static class Func
    {

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> collection, Func<T, bool> function)
        {

            List<T> items = new List<T>();

            foreach (var element in collection)
            {
                if (function(element))
                {
                    items.Add(element);
                }
            }

            return items;

        }

    }
}
