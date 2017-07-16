using System;

public class Helpers
{
    public static bool IsLess(IComparable first, IComparable second)
    {
        return first.CompareTo(second) < 0;
    }

    public static void Swap<T>(T[] arr, int firstIndex, int secondIndex)
    {
        T temp = arr[firstIndex];
        arr[firstIndex] = arr[secondIndex];
        arr[secondIndex] = temp;
    }
}