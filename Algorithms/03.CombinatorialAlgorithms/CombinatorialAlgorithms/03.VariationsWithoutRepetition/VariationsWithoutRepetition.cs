using System;

namespace _03.VariationsWithoutRepetition
{
    public class VariationsWithoutRepetition
    {
        private static string[] elements = new string[] { "A", "B", "C" };

        public static void Main()
        {
            var k = 2;

            int[] vector = new int[k];

            while (true)
            {
                Print(vector);
                var index = k - 1;

                while (index >= 0 && vector[index] == elements.Length - 1)
                {
                    index--;
                }

                if (index < 0)
                {
                    break;
                }

                vector[index]++;

                for (int i = index + 1; i < vector.Length; i++)
                {
                    vector[i] = 0;
                }
            }
        }

        private static void Print(int[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write(elements[vector[i]] + " ");
            }

            Console.WriteLine();
        }
    }
}
