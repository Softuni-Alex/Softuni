using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MoveDownRight
{
    public class MoveDownRight
    {
        private static int rows = int.Parse(Console.ReadLine());
        private static int cols = int.Parse(Console.ReadLine());

        private static int[,] matrix = new int[rows, cols];

        private static int[,] memo = new int[rows, cols];

        public static void Main()
        {
            //read matrix

            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            memo[0, 0] = matrix[0, 0];

            for (int row = 1; row < rows; row++)
            {
                memo[row, 0] = memo[row - 1, 0] + matrix[row, 0];
            }

            for (int col = 1; col < cols; col++)
            {
                memo[0, col] = memo[0, col - 1] + matrix[0, col];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    memo[row, col] = Math.Max(memo[row - 1, col], memo[row, col - 1]) + matrix[row, col];
                }
            }

            Console.WriteLine(string.Join(" ", PrintPath(rows - 1, cols - 1)));
        }

        private static Stack<string> PrintPath(int row, int col)
        {
            var stack = new Stack<string>();
            while (!(row == 0 && col == 0))
            {
                stack.Push($"[{row}, {col}]");

                if (row == 0)
                {
                    col--;
                }
                else if (col == 0)
                {
                    row--;
                }

                else if (memo[row - 1, col] > memo[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            stack.Push($"[{row}, {col}]");

            return stack;
        }
    }
}
