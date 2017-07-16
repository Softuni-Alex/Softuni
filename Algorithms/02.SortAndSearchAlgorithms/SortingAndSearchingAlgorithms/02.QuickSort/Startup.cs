using System;
using System.Linq;

namespace _02.QuickSort
{
    public class Startup
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            global::QuickSort.Sort(array);

            foreach (var i in array)
            {
                Console.Write(i + " ");
            }
        }
    }
}