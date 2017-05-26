using System;
using System.Linq;

namespace FoldAndSum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int k = arr.Length / 4;

            var rowLeft = arr.Take(k).Reverse();
            var rowRight = arr.Reverse().Take(k);

            int[] row1 = rowLeft.Concat(rowRight).ToArray();
            int[] row2 = arr.Skip(k).Take(2 * k).ToArray();

            var sum = row1.Select((x, index) => x + row2[index]);

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}