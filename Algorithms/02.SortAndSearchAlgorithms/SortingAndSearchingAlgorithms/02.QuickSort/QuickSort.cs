using System;
using HelperMethods;

public class QuickSort
{
    public static void Sort<T>(T[] a) where T : IComparable<T>
    {
        //Todo: Shuffle to be sure that collection is not sorted
        Sort(a, 0, a.Length - 1);
    }

    private static void Sort<T>(T[] a, int lo, int hi) where T : IComparable<T>
    {
        if (lo >= hi)
        {
            return;
        }

        int p = Partition(a, lo, hi);
        Sort(a, lo, p - 1);
        Sort(a, p + 1, hi);
    }

    private static int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
    {
        if (lo >= hi)
        {
            return lo;
        }

        int i = lo;
        int j = hi + 1;

        while (true)
        {
            while (Helpers.IsLess(a[++i] as IComparable, a[lo] as IComparable))
            {
                if (i == hi)
                {
                    break;
                }
            }

            while (Helpers.IsLess(a[lo] as IComparable, a[--j] as IComparable))
            {
                if (j == lo)
                {
                    break;
                }
            }

            if (i >= j)
            {
                break;
            }

            Helpers.Swap(a, i, j);
        }

        Helpers.Swap(a, lo, j);

        return j;
    }
}
