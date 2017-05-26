namespace ConsoleApplication1
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            double[,] row = new double[,]
            {
                { 1, 3 }, { 5, 7 }
            };

            double[,] col = new double[,]
            {
                { 4, 2 }, { 1, 5 }
            };

            double[,] square = mm(row, col);

            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    Console.Write(square[i, j] + " ");
                }
                Console.WriteLine();
            }

        }

        public static double[,] mm(double[,] row, double[,] col)
        {
            if (row.GetLength(1) != col.GetLength(0))
            {
                throw new Exception("Error!");
            }

            int rect = row.GetLength(1);
            var newDouble = new double[row.GetLength(0), col.GetLength(1)];
            for (int i = 0; i < newDouble.GetLength(0); i++)
                for (int j = 0; j < newDouble.GetLength(1); j++)
                    for (int k = 0; k < rect; k++)
                        newDouble[i, j] += row[i, k] * col[k, j];
            return newDouble;
        }
    }
}