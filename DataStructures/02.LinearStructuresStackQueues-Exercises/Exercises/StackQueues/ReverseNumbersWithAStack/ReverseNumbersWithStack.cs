using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbersWithAStack
{
    public class ReverseNumbersWithStack
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
            }

            foreach (var num in stack)
            {
                Console.Write(num + " ");
            }
        }
    }
}