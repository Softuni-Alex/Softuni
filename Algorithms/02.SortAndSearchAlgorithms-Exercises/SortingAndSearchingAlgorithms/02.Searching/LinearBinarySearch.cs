using System;
using System.Linq;

public class LinearBinarySearch
{
    public static void Main()
    {
        var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int element = int.Parse(Console.ReadLine());

        //linear search
        //int index = LinearIndexOf(element, array);
        //binary search
        int index = BinaryIndexOf(element, array);

        Console.WriteLine(index);
    }

    private static int LinearIndexOf(int element, int[] array)
    {
        int result = -1;
        for (int i = 0; i < array.Length; i++)
        {
            if (element == array[i])
            {
                result = i;
            }
        }

        return result;
    }

    private static int BinaryIndexOf(int element, int[] array)
    {
        //define boundries
        int low = 0;
        int high = array.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (element < array[mid])
            {
                high = mid - 1;
            }
            else if (element > array[mid])
            {
                low = mid + 1;
            }
            else
            {
                return mid;
            }
        }

        return -1;
    }
}
