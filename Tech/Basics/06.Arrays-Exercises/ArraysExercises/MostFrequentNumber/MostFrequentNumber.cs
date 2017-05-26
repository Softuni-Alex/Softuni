using System;
using System.Linq;

namespace MostFrequentNumber
{
    class MostFrequentNumber
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int resultNumber = 0;
            int counter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int tempCounter = 0;
                foreach (var number in numbers)
                {
                    if (numbers[i] == number)
                    {
                        tempCounter++;
                    }
                }
                if (tempCounter > counter)
                {
                    counter = tempCounter;
                    resultNumber = numbers[i];
                }
            }
            Console.WriteLine(resultNumber);
        }
    }
}
//
//int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//int[] distinctNumbers = numbers.Distinct().OrderBy(x => x).ToArray();
//int[] repeats = new int[distinctNumbers.Length];
//
//            for (int i = 0; i<distinctNumbers.Length; i++)
//            {
//                repeats[i] = numbers.Count(n => n == distinctNumbers[i]);
//            }
//            Console.WriteLine(distinctNumbers[repeats.ToList().IndexOf(repeats.Max())]);