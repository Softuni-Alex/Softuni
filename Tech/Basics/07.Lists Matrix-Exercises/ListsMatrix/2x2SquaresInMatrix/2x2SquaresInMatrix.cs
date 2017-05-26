using System;
using System.Linq;

namespace _2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaring the matrix
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = tokens[0];
            int cols = tokens[1];

            string[][] matrix = new string[rows][];

            //Read the matrix

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split();
            }

            long count = 0;

            //Itterate over the matrix
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row][col] == matrix[row][col + 1] &&
                        matrix[row][col] == matrix[row + 1][col] &&
                        matrix[row][col] == matrix[row + 1][col + 1])
                    {
                        count++;
                    }
                }
            }

            //Print the result
            Console.WriteLine(count);
        }
    }
}