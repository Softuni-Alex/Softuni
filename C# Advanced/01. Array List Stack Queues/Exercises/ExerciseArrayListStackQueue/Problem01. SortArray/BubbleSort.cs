namespace Problem01.SortArray
{
    using System;
    using System.Linq;

    public class BubbleSort
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            bool swapped;

            do
            {
                swapped = false;
                for (int i = 1; i < input.Length; i++)
                {
                    if (input[i - 1] > input[i])
                    {
                        Swap(input, i - 1, i);
                        swapped = true;
                    }
                }
            }
            while (swapped);
            {
                string sortedArray = string.Join(", ", input);
                Console.WriteLine(sortedArray);
            }

        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }
    }
}