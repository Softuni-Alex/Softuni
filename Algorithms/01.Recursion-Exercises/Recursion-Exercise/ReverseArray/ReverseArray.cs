using System;
using System.Linq;

public class ReverseArray
{
    public static void Main(string[] args)
    {
        var array = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Reverse(array, 0, array.Length - 1);

        Console.WriteLine(string.Join(" ", array));
    }

    private static void Reverse(int[] array, int startIndex, int endIndex)
    {
        if (startIndex > endIndex)
        {
            return;
        }

        var first = array[startIndex];
        var last = array[endIndex];

        array[startIndex] = last;
        array[endIndex] = first;

        Reverse(array, startIndex + 1, endIndex - 1);
    }
}