using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.DividingPresents
{
    public class DividingPresents
    {
        public static void Main(string[] args)
        {
            int[] nums =
                Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int totalSum = nums.Sum();
            int targetSum = totalSum / 2;
            var possibleSums = CalculaterPossibleSums(nums, targetSum);
            var alansSum = possibleSums.OrderByDescending(s => s.Key).First().Key;
            var bobsSum = totalSum - alansSum;
            var difference = bobsSum - alansSum;
            var targetSubset = FindTargetSubset(nums, possibleSums);
            Console.WriteLine("Difference: {0}", difference);
            Console.WriteLine("Alan:{0} Bob:{1}", alansSum, bobsSum);
            Console.WriteLine("Alan takes: {0}", string.Join(" ", targetSubset));
            Console.WriteLine("Bob takes the rest.");
        }

        private static IDictionary<int, int> CalculaterPossibleSums(int[] nums, int targetSum)
        {
            var possibleSums = new Dictionary<int, int>();
            possibleSums.Add(0, 0);
            for (int i = 0; i < nums.Length; i++)
            {
                var newSums = new Dictionary<int, int>();
                foreach (var sum in possibleSums.Keys)
                {
                    int newSum = sum + nums[i];
                    if (!possibleSums.ContainsKey(newSum) && newSum <= targetSum)
                    {
                        newSums.Add(newSum, nums[i]);
                    }
                }

                foreach (var sum in newSums)
                {
                    possibleSums.Add(sum.Key, sum.Value);
                }
            }
            return possibleSums;
        }

        private static IEnumerable<int> FindTargetSubset(int[] nums, IDictionary<int, int> possibleSums)
        {
            var subset = new List<int>();
            var targetSum = possibleSums.OrderByDescending(s => s.Key).First().Key;
            while (targetSum > 0)
            {
                var lastNum = possibleSums[targetSum];
                subset.Add(lastNum);
                targetSum = targetSum - lastNum;
            }
            subset.Reverse();
            return subset;
        }
    }
}