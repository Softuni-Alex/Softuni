using System;
using System.Linq;

namespace MultiplyTargetedCell
{
    class MultiplyTargetedCell
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            long[,] matrix = new long[input[0], input[1]];
            for (int row = 0; row < input[0]; row++)
            {
                int[] cells = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row, col] = cells[col];
                }
            }
            int[] target = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            long sum = 0;
            long min = Math.Max(target[0], 1);
            long max = Math.Min(target[1], input[1] - 2);

            sum += matrix[min - 1, max - 1];
            matrix[min - 1, max - 1] *= matrix[target[0], target[1]];
            sum += matrix[min - 1, max];
            matrix[min - 1, max] *= matrix[target[0], target[1]];
            sum += matrix[min - 1, max + 1];
            matrix[min - 1, max + 1] *= matrix[target[0], target[1]];
            sum += matrix[min, max - 1];
            matrix[min, max - 1] *= matrix[target[0], target[1]];
            sum += matrix[min, max + 1];
            matrix[min, max + 1] *= matrix[target[0], target[1]];
            sum += matrix[min + 1, max - 1];
            matrix[min + 1, max - 1] *= matrix[target[0], target[1]];
            sum += matrix[min + 1, max];
            matrix[min + 1, max] *= matrix[target[0], target[1]];
            sum += matrix[min + 1, max + 1];
            matrix[min + 1, max + 1] *= matrix[target[0], target[1]];
            matrix[target[0], target[1]] *= sum;

            for (int row = 0; row < input[0]; row++)
            {
                for (int col = 0; col < input[1]; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}