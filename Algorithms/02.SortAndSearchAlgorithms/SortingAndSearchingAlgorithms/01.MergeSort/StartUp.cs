using System;
using System.Linq;

namespace _01.MergeSort
{
    public class StartUp
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            MergeSort<int>.Sort(array);

            foreach (var i in array)
            {
                Console.Write(i + " ");
            }
        }
    }
}
