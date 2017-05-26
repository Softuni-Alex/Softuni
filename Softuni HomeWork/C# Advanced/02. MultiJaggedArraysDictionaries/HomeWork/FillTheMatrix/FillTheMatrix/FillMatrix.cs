using System;

namespace FillTheMatrix
{
    public class FillMatrix
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix1 = new int[n, n];
            int[,] matrix2 = new int[n, n];

            int index1 = 1;
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    matrix1[col, row] = index1;
                    index1++;
                }
            }
            int leftColumn = 0;
            int upperRow = 0;
            int bottomRow = n - 1;
            int count = 1; // from 1 to N*N
            int index2 = 1;
            do
            {
                // down
                for (int i = upperRow; i <= bottomRow; i++)
                {
                    matrix2[i, leftColumn] = index2;
                    count++;
                    index2++;
                }
                leftColumn++; // we go to the next column

                // up
                for (int i = bottomRow; i >= upperRow; i--)
                {
                    matrix2[i, leftColumn] = index2;
                    count++;
                    index2++;
                }
                leftColumn++; ; // we go one column to the right

                // down
                for (int i = upperRow; i <= bottomRow; i++)
                {
                    matrix2[i, leftColumn] = index2;
                    count++;
                    index2++;
                }
                leftColumn++; // we go to the next column

                // up
                for (int i = bottomRow; i >= upperRow; i--)
                {
                    matrix2[i, leftColumn] = index2;
                    count++;
                    index2++;
                }
                leftColumn++; ; // we go one column to the right
            } while (count <= n * n); // and continuing the spiral until count = n*n

            // printing
            PrintMatrix(matrix1);
            PrintMatrix(matrix2);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,4}", matrix[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
