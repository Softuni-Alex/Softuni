using System;
using System.Linq;

namespace RotateAndSum
{
    class RotateAndSum
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());
            int[] sum = new int[array.Length];

            for (int i = 0; i < k; i++)
            {
                int lastIndex = array[array.Length - 1];

                for (int j = array.Length - 1; j > 0; j--)
                {
                    array[j] = array[j - 1];
                }
                array[0] = lastIndex;

                for (int j = 0; j < sum.Length; j++)
                {
                    sum[j] = sum[j] + array[j];
                }
            }
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}