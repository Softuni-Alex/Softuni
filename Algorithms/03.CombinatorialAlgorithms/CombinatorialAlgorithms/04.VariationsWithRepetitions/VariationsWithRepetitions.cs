using System;

namespace _04.VariationsWithRepetitions
{
    class VariationsWithRepetitions
    {
        static int n = 4;
        static int k = 2;
        static int[] arr = new int[k];

        public static void Main(String[] args)
        {

            generateVariations(0);
        }

        private static void generateVariations(int index)
        {

            if (index >= arr.Length)
            {
                printArr();
            }
            else
            {

                for (int i = 0; i <= n; i++)
                {
                    arr[index] = i;
                    generateVariations(index + 1);
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
