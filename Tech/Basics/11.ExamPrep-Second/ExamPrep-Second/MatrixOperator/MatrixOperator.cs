using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixOperator
{
    class MatrixOperator
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            List<List<int>> matrix = new List<List<int>>();

            //reading the matrix
            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<int>());
                matrix[row] = Console.ReadLine().Split().Select(int.Parse).ToList();
            }

            //parsing the commands
            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];

                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    //remove with removetype at the position
                    case "remove":

                        int position = int.Parse(tokens[3]);

                        ExecuteRemoveCommand(tokens, matrix);

                        break;

                    //swap 2 given rows
                    case "swap":
                        int firstRow = int.Parse(tokens[1]);
                        int secondRow = int.Parse(tokens[2]);

                        Swap(firstRow, secondRow, matrix);

                        break;

                    //insert a number in a row
                    case "insert":
                        int row = int.Parse(tokens[1]);
                        int element = int.Parse(tokens[2]);

                        Insert(row, element, matrix);

                        break;
                }
            }
            PrintMatrix(matrix);
        }

        private static void Insert(int row, int element, List<List<int>> matrix)
        {
            matrix[row].Insert(0, element);
        }

        private static void Swap(int firstRow, int secondRow, List<List<int>> matrix)
        {
            var firstRowElements = matrix[firstRow];

            matrix[firstRow] = matrix[secondRow];
            matrix[secondRow] = firstRowElements;
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
        private static void ExecuteRemoveCommand(string[] tokens, List<List<int>> matrix)
        {
            string type = tokens[1];
            int startRow = tokens[2].Equals("row") ? int.Parse(tokens[3]) : 0;
            int startCol = tokens[2].Equals("col") ? int.Parse(tokens[3]) : 0;

            switch (type)
            {
                case "odd":
                    ExecuteRemoveCommandForType(matrix, tokens[2], startRow, startCol, "odd");
                    break;
                case "even":
                    ExecuteRemoveCommandForType(matrix, tokens[2], startRow, startCol, "even");
                    break;
                case "positive":
                    ExecuteRemoveCommandForType(matrix, tokens[2], startRow, startCol, "positive");
                    break;
                case "negative":
                    ExecuteRemoveCommandForType(matrix, tokens[2], startRow, startCol, "negative");
                    break;
            }
        }

        private static void ExecuteRemoveCommandForType(List<List<int>> matrix, string rowOrCol, int startRow, int startCol, string type)
        {
            if (rowOrCol.Equals("row"))
            {
                for (int col = 0; col < matrix[startRow].Count; col++)
                {
                    if (CheckCondition(matrix, startRow, col, type))
                    {
                        matrix[startRow].RemoveAt(col);
                        col--;
                    }
                }
            }
            else
            {
                for (int row = 0; row < matrix.Count; row++)
                {
                    if (startCol >= matrix[row].Count)
                    {
                        continue;
                    }

                    if (CheckCondition(matrix, row, startCol, type))
                    {
                        matrix[row].RemoveAt(startCol);
                    }
                }
            }
        }

        private static bool CheckCondition(List<List<int>> matrix, int row, int col, string type)
        {
            switch (type)
            {
                case "odd":
                    return Math.Abs(matrix[row][col]) % 2 == 1;
                case "even":
                    return Math.Abs(matrix[row][col]) % 2 == 0;
                case "positive":
                    return matrix[row][col] >= 0;
                case "negative":
                    return matrix[row][col] < 0;
                default:
                    throw new ArgumentException();
            }
        }
    }
}