using System;
using System.Linq;

namespace _04.SumWithUnlimitedCoins
{
    class UnlimtedCoins
    {
        private static int combinationsCount = 0;

        static void Main(string[] args)
        {
            var coins = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var s = int.Parse(Console.ReadLine());

            GetAllCombinations(coins, s);
            Console.WriteLine(combinationsCount);
        }

        private static void GetAllCombinations(int[] coins, int desiredSum, int sum = 0, int startNum = 0)
        {
            if (sum == desiredSum)
            {
                combinationsCount++;
                return;
            }

            if (sum > desiredSum)
            {
                return;
            }

            for (int i = startNum; i < coins.Length; i++)
            {
                sum += coins[i];
                GetAllCombinations(coins, desiredSum, sum, i);
                sum -= coins[i];
            }
        }
    }
}