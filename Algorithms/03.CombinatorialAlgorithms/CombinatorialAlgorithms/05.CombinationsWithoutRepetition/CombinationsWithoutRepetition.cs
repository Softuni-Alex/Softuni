using System;

namespace _05.CombinationsWithoutRepetition
{
    class CombinationsWithoutRepetition
    {

        static int k = 2;
        static int n = 3;
        static int[] arr = new int[k];

        public static void Main()
        {
            combinationsWithoutRepetition(0, 0);
        }

        private static void combinationsWithoutRepetition(int index, int start)
        {

            if (index >= k)
            {
                printArr();
            }
            else
            {

                for (int i = start; i < n; i++)
                {
                    arr[index] = i;
                    combinationsWithoutRepetition(index + 1, i + 1);
                }
            }

        }

        private static void printArr()
        {

            for (int i = 0; i < arr.Length - 1; i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.Write(arr[arr.Length - 1] + " }");
        }
    }
}
