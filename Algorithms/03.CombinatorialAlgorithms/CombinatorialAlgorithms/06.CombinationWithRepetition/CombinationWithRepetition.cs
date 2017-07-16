using System;

namespace _06.CombinationWithRepetition
{
    class CombinationWithRepetition
    {
        private static string k = "A B C";
        private static int n = 2;
        private static int[] arr = new int[n];

        public static void Main(string[] args)
        {
            CombinationsWithoutRepetition(0, 0);
        }

        private static void CombinationsWithoutRepetition(int index, int start)
        {
            if (index >= n)
            {
                printArr();
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i;
                    CombinationsWithoutRepetition(index + 1, i);
                }
            }
        }

        private static void printArr()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.Write(arr[arr.Length - 1]);
            Console.WriteLine();
        }
    }
}
