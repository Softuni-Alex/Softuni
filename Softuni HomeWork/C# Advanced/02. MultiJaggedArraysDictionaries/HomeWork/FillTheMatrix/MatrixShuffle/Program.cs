using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixShuffle
{
    class Program
    {
        static void Main()
        {
            // input
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());

            string[,] matrix = new string[N, M];
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < M; col++)
                {
                    matrix[row, col] = Console.ReadLine();
                }
            }
            //PrintMatrix(matrix);

            // reading commands
            while (true)
            {
                string input = Console.ReadLine();
                string[] command;

                if (input != "END")
                {
                    command = input
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (command[0] == "swap" && command.Length == 5)
                    {
                        // get coordinates
                        int x1 = int.Parse(command[1]);
                        int y1 = int.Parse(command[2]);
                        int x2 = int.Parse(command[3]);
                        int y2 = int.Parse(command[4]);

                        if (ValidateCoordinates(x1, N, x2, y1, M, y2))
                        {
                            // swap
                            string temp = matrix[x1, y1];
                            matrix[x1, y1] = matrix[x2, y2];
                            matrix[x2, y2] = temp;

                            // print
                            PrintMatrix(matrix);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!"); // in case of wrong coordinates
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!"); // in case of no swap command, or wrong number of coordinates
                    }
                }
                else
                {
                    break; // break if command = "END"
                }
            }
        }

        private static bool ValidateCoordinates(int x1, int N, int x2, int y1, int M, int y2)
        {
            bool validX1 = x1 >= 0 && x1 < N;
            bool validX2 = x2 >= 0 && x2 < N;
            bool validY1 = y1 >= 0 && y1 < M;
            bool validY2 = y2 >= 0 && y1 < M;

            return validX1 && validX2 && validY1 && validY2;
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
