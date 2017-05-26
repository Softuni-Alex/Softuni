using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            string line = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(line))
            {
                numbers = line.Split().Select(int.Parse).ToList();
            }
            else
            {
                numbers.Add(0);
            }
            Console.WriteLine("Sum: {0}", Sum(numbers));
            Console.WriteLine("Average: {0}", Average(numbers));
        }

        public static int Sum(List<int> numbers)
        {
            int result = 0;
            foreach (var number in numbers)
            {
                result += number;
            }
            return result;
        }

        public static double Average(List<int> numbers)
        {
            if (numbers.Count == 0)
            {
                return 0;
            }
            return (double)Sum(numbers) / (double)numbers.Count;
        }
    }
}