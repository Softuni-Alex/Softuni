using System;
using System.Linq;

public class GeneratingCombinations
{
    public static void Main()
    {
        var set = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        var k = int.Parse(Console.ReadLine());

        var vector = new int[k];

        Generator(set, vector, 0, 0);
    }

    private static void Generator(int[] set, int[] vector, int index, int border)
    {
        if (index > vector.Length - 1)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
        else
        {
            for (int i = border; i < set.Length; i++)
            {
                vector[index] = set[i];

                Generator(set, vector, index + 1, i + 1);
            }
        }
    }
}