using System;
using System.Collections.Generic;

public class QueensPuzzle
{
    private static readonly bool[,] board = new bool[8, 8];

    private static readonly HashSet<int> attackedRow = new HashSet<int>();
    private static readonly HashSet<int> attackedCols = new HashSet<int>();
    private static readonly HashSet<int> attackedLeftDiagonal = new HashSet<int>();
    private static readonly HashSet<int> attackedRightDiagonal = new HashSet<int>();

    public static void Main()
    {
        PlaceQueen(0);
    }

    private static void PlaceQueen(int row)
    {
        if (row == 8)
        {
            Print(board);
        }
        else
        {
            for (int col = 0; col < 8; col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    Mark(row, col);

                    PlaceQueen(row + 1);

                    UnMark(row, col);
                }
            }
        }
    }

    private static void UnMark(int row, int col)
    {
        board[row, col] = false;

        attackedRow.Remove(row);
        attackedCols.Remove(col);
        attackedLeftDiagonal.Remove(row + col);
        attackedRightDiagonal.Remove(row - col);
    }

    private static void Mark(int row, int col)
    {
        board[row, col] = true;

        attackedRow.Add(row);
        attackedCols.Add(col);
        attackedLeftDiagonal.Add(row + col);
        attackedRightDiagonal.Add(row - col);
    }

    private static bool CanPlaceQueen(int row, int col)
    {
        return !attackedRow.Contains(row) &&
            !attackedCols.Contains(col) &&
            !attackedLeftDiagonal.Contains(row + col) &&
               !attackedRightDiagonal.Contains(row - col);
    }

    private static void Print(bool[,] bools)
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if (bools[row, col])
                {
                    Console.Write("* ");
                }
                else
                {
                    Console.Write("- ");
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
