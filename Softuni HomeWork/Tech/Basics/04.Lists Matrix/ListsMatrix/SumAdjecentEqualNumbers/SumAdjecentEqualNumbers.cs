using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAdjecentEqualNumbers
{
    class SumAdjecentEqualNumbers
    {
        static void Main(string[] args)
        {
            List<decimal> nums = Console.ReadLine().Split().Select(decimal.Parse).ToList();

            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i - 1] == nums[i])
                {
                    nums[i - 1] += nums[i];
                    nums.RemoveAt(i);
                    i = 0;//vrushtame se ot nachalo i sled tova to si pravi i++
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}