using System;
using System.Linq;

namespace _01.PermutationsWithoutRepetition
{
    public class PermutationWithoutRepetition
    {
        private static int count = 0;

        public static void Main(string[] args)
        {
            int ammount = int.Parse(Console.ReadLine());
            int[] numbers = Enumerable.Range(1, ammount).ToArray();
            Permute(numbers, 0);
            Console.WriteLine("Total Permutations: {0}", count);
        }

        private static void Permute(int[] numbers, int currentIndex)
        {
            if (currentIndex == numbers.Length - 1)
            {
                Console.WriteLine(string.Join(", ", numbers));
                count++;
            }
            else
            {
                for (int i = currentIndex; i < numbers.Length; i++)
                {
                    Swap(ref numbers[currentIndex], ref numbers[i]);
                    Permute(numbers, currentIndex + 1);
                    Swap(ref numbers[currentIndex], ref numbers[i]);
                }
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            if (a == b)
            {
                return;
            }

            int temp = a;
            a = b;
            b = temp;
        }
    }
}
