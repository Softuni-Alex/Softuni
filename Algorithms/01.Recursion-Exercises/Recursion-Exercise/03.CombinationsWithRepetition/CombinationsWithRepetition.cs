using System;

public class CombinationsWithRepetition
{
    public static void Main()
    {
        int numberOfRepeat = int.Parse(Console.ReadLine());
        int elements = int.Parse(Console.ReadLine());

        int[] array = new int[elements];

        Generate(numberOfRepeat, elements, array, 0, 1);
    }

    private static void Generate(int n, int m, int[] array, int idx, int startNum)
    {
        if (idx == array.Length)
        {
            Console.WriteLine(String.Join(" ", array));
            return;
        }


        for (int i = startNum; i <= n; i++)
        {
            array[idx] = i;
            Generate(n, m, array, idx + 1, i);
        }
    }
}