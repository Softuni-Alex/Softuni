﻿using System;

namespace ExactSumofRealNumbers
{
    class ExactSumofRealNumbers
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            decimal sum = 0;

            for (int i = 0; i < numbers; i++)
            {
                decimal num = decimal.Parse(Console.ReadLine());
                sum += num;
            }

            Console.WriteLine(sum);
        }
    }
}