using System;

namespace _02.PermutationsWithRepetition
{
    public class PermutationsWithRepetition
    {
        static string[] arr = { "A", "B", "C" };

        private static void printArr()
        {

            for (int i = 0; i < arr.Length - 1; i++)
            {
                Console.WriteLine(arr[i] + ", ");
            }
        }

        private static void swap(int i, int j)
        {

            string temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void Main(String[] args)
        {
            Array.Sort(arr);
            generatingPermutationsWithRepetition(0, arr.Length - 1);
        }

        private static int counter = 0;

        private static void generatingPermutationsWithRepetition(int startIndex, int endIndex)
        {

            printArr();
            counter++;
            for (int leftIndex = endIndex - 1; leftIndex >= startIndex; leftIndex--)
            {
                for (int rightIndex = leftIndex + 1; rightIndex <= endIndex; rightIndex++)
                {

                    if (arr[leftIndex] != arr[rightIndex])
                    {

                        swap(leftIndex, rightIndex);
                        generatingPermutationsWithRepetition(leftIndex + 1, endIndex);
                    }

                    string firstIndex = arr[leftIndex];
                    for (int i = leftIndex; i <= endIndex - 1; i++)
                    {
                        arr[i] = arr[i + 1];
                    }
                    arr[endIndex] = firstIndex;
                }

            }
        }
    }
}