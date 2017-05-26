using System;
using System.Linq;

namespace SumMinMaxFirstLastAv
{
    class SumMinMaxFirstLastAv
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[] numbers = new int[num];

            for (int i = 0; i < num; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Sum = " + numbers.Sum());
            Console.WriteLine("Min = " + numbers.Min());
            Console.WriteLine("Max = " + numbers.Max());
            Console.WriteLine("First = " + numbers.First());
            Console.WriteLine("Last= " + numbers.Last());
            Console.WriteLine("Average = {0:F2}", (double)numbers.Sum() / num);
        }
    }
}