using System;

public class GeneratingVectors
{
    public static void Main()
    {
        var number = int.Parse(Console.ReadLine());

        var vector = new int[number];

        Generator(vector, 0);
    }

    private static void Generator(int[] vector, int index)
    {
        if (index > vector.Length - 1)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
        else
        {
            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Generator(vector, index + 1);
            }
        }
    }
}