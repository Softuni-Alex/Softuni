using System;
using System.Linq;

namespace InsertionSort
{
    public class InsertionSort
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

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
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}