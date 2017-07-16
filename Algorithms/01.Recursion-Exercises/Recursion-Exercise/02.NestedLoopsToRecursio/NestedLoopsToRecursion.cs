using System;

public class NestedLoopsToRecursion
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] array = new int[n];
        int index = 0;

        GenerateValues(array, index);

    }

    private static void GenerateValues(int[] array, int index)
    {
        if (index > array.Length - 1)
        {
            Console.WriteLine(string.Join(" ", array));

            return;
        }

        for (int i = 1; i <= array.Length; i++)
        {
            array[index] = i;
            GenerateValues(array, index + 1);
        }
    }
}
