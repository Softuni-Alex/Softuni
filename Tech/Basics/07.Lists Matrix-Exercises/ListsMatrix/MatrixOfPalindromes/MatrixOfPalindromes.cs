using System;

namespace MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            //string[][] matrix = new string[rows][];

            char sideLetter = 'a';

            for (int row = 0; row < rows; row++)
            {
                char middleLetter = sideLetter;
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("" + sideLetter + middleLetter + sideLetter + " ");
                    middleLetter++;
                }
                sideLetter++;
                Console.WriteLine();
            }
        }
    }
}