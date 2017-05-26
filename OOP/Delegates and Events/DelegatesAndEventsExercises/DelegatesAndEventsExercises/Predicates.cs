using System;
using System.Collections.Generic;

namespace DelegatesAndEventsExercises
{
    static class Predicates
    {

        public static T MyFirstOrDefault<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            foreach (var element in collection)
            {
                if (condition(element))
                {
                    T item = element;
                    return item;
                }
            }
            return default(T);
        }

    }
}
