using System;
using System.Collections.Generic;

namespace Action
{
    public static class Action
    {

        public static void MyForEach<T>(this IEnumerable<T> collection, Action<T> act)
        {
            foreach (var element in collection)
            {

                act(element);

            }

        }

    }
}
