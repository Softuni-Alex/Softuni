using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        RadixSort.Sort(input);

        Console.WriteLine(string.Join(" ", input));
    }
}

partial class InsertionSort
{
    public static void Sort<T>(int[] arr) where T : IComparable
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int value = arr[i];
            int index = i;

            while (index > 0 && arr[index - 1] >= value)
            {
                arr[index] = arr[index - 1];
                index--;
            }

            arr[index] = value;
        }
    }
}

partial class RadixSort
{
    public static void Sort(int[] arr)
    {
        int i = 0;
        int j = 0;

        //31 ( number of bits of a c# int)
        int[] tmp = new int[arr.Length];
        for (int shift = 31; shift > -1; --shift)
        {
            j = 0;
            for (i = 0; i < arr.Length; ++i)
            {
                bool move = (arr[i] << shift) >= 0;
                if (shift == 0 ? !move : move)
                    arr[i - j] = arr[i];
                else
                    tmp[j++] = arr[i];
            }
            Array.Copy(tmp, 0, arr, arr.Length - j, j);
        }
    }
}