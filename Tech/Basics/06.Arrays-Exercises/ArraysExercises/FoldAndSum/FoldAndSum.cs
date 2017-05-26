using System;
using System.Linq;

namespace FoldAndSum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            FoldItAndSumIt(input);
        }
        static void FoldItAndSumIt(int[] arr)
        {
            int k = arr.Length / 4;
            int[] upper = new int[2 * k]; //upperRow
            for (int i = 0; i < k; i++) //fill it
            {
                upper[i] = arr[k - 1 - i];
                upper[k + i] = arr[4 * k - 1 - i]; //crazy math skill
            }
            int[] lower = new int[2 * k]; //lowerRow
            for (int i = 0; i < 2 * k; i++) // fill it
            {
                lower[i] = arr[k + i];
            }
            for (int i = 0; i < 2 * k; i++)
            {
                //print the sum of the integers on each position
                Console.Write((lower[i] + upper[i]) + " ");
            }
            Console.WriteLine();
        }
    }
}