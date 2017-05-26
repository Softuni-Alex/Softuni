using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendLists
{
    class AppendLists
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split('|').ToList();
            input.Reverse();
            List<string> result = new List<string>();

            foreach (var i in input)
            {
                List<string> nums = i.Split(new char[' '], StringSplitOptions.RemoveEmptyEntries).ToList();
                result.AddRange(nums);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}