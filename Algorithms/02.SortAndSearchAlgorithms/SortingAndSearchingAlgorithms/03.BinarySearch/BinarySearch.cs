public class BinarySearch
{
    public static int IndexOf(int[] array, int element)
    {
        int low = 0;
        int high = array.Length - 1;

        while (low <= high)
        {
            int middle = high / 2;

            if (element < array[middle])
            {
                high = middle - 1;
            }
            else if (element > array[middle])
            {
                low = middle + 1;
            }
            else
            {
                return middle;
            }
        }

        return -1;
    }
}