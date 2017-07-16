using System;
using HelperMethods;

public class MergeSort<T> where T : IComparable
{
    private static T[] auxiliary;

    public static void Sort(T[] array)
    {
        auxiliary = new T[array.Length];

        Sort(array, 0, array.Length - 1);
    }

    private static void Merge(T[] arr, int low, int mid, int hi)
    {
        if (Helpers.IsLess(arr[mid], arr[mid + 1]))
        {
            return;
        }

        for (int index = low; index < hi + 1; index++)
        {
            auxiliary[index] = arr[index];
        }

        int i = low;
        int j = mid + 1;

        for (int k = low; k <= hi; k++)
        {
            if (i > mid)
            {
                arr[k] = auxiliary[j++];
            }
            else if (j > hi)
            {
                arr[k] = auxiliary[i++];
            }
            else if (Helpers.IsLess(auxiliary[i], auxiliary[j]))
            {
                arr[k] = auxiliary[i++];
            }
            else
            {
                arr[k] = auxiliary[j++];
            }
        }
    }

    private static void Sort(T[] array, int lo, int hi)
    {
        if (lo >= hi)
        {
            return;
        }

        int mid = lo + (hi - lo) / 2;
        Sort(array, lo, mid);
        Sort(array, mid + 1, hi);
        Merge(array, lo, mid, hi);
    }
}
