using System;
using System.Linq;

namespace CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main(string[] args)
        {
            char[] first = Console.ReadLine().Split().Select(char.Parse).ToArray();
            char[] second = Console.ReadLine().Split().Select(char.Parse).ToArray();

            string[] arrays = { new string(first), new string(second) };

            Console.WriteLine(string.Join("\n", arrays.OrderBy(str => str)));

            //            int smallerArrayLenth = Math.Min(first.Length, second.Length);
            //            bool areEqual = false;
            //
            //            for (int i = 0; i < smallerArrayLenth; i++)
            //            {
            //                if (first[i] == second[i])
            //                {
            //                    continue;
            //                }
            //                else
            //                {
            //                    if (first[i] < second[i])
            //                    {
            //                        Console.WriteLine(first);
            //                        Console.WriteLine(second);
            //                    }
            //                    else
            //                    {
            //                        Console.WriteLine(second);
            //                        Console.WriteLine(first);
            //                    }
            //                    areEqual = true;
            //                    break;
            //                }
            //            }
            //            if (!areEqual)
            //            {
            //                if (first.Length <= second.Length)
            //                {
            //                    Console.WriteLine(first);
            //                    Console.WriteLine(second);
            //                }
            //                else
            //                {
            //                    Console.WriteLine(second);
            //                    Console.WriteLine(first);
            //                }
            //            }
        }
    }
}