using System;
using System.Collections.Generic;
using System.Linq;

public class PathsInLabyrinth
{
    static List<char> path = new List<char>();
    static char[,] lab;

    public static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        lab = new char[rows, cols];
        ReadLab(rows, cols);
        FindPaths(0, 0, 'S');
    }

    private static void ReadLab(int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            char[] row = Console.ReadLine().ToCharArray();
            for (int y = 0; y < cols; y++)
            {
                lab[i, y] = row[y];
            }
        }
    }

    private static void FindPaths(int row, int col, char direction)
    {
        if (!IsValidCell(row, col))
        {
            return;
        }

        path.Add(direction);

        if (lab[row, col] == 'e')
        {
            PrintPath();
        }
        else if (lab[row, col] != 'v')
        {
            lab[row, col] = 'v';

            FindPaths(row, col + 1, 'R'); // Right
            FindPaths(row + 1, col, 'D'); // Down
            FindPaths(row, col - 1, 'L'); // Left
            FindPaths(row - 1, col, 'U'); // Up

            lab[row, col] = '-';
        }

        path.RemoveAt(path.Count - 1);
    }

    private static void PrintPath()
    {
        Console.WriteLine(string.Join("", path.Skip(1)));
    }

    private static bool IsValidCell(int row, int col)
    {
        return row >= 0 && row < lab.GetLength(0)
        && col >= 0 && col < lab.GetLength(1) &&
        lab[row, col] != '*';
    }
}