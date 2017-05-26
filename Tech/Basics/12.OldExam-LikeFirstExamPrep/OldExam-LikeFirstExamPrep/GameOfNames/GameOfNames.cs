using System;

namespace GameOfNames
{
    class GameOfNames
    {
        static void Main(string[] args)
        {
            int numberOfPlayers = int.Parse(Console.ReadLine());

            string tempName = "";
            long maxSum = long.MinValue;

            for (int i = 0; i < numberOfPlayers; i++)
            {
                string name = Console.ReadLine();
                long points = long.Parse(Console.ReadLine());

                for (int j = 0; j < name.Length; j++)
                {
                    if ((int)name[j] % 2 == 0)
                    {
                        points += (int)name[j];
                    }
                    else
                    {
                        points -= (int)name[j];
                    }
                }
                if (maxSum < points)
                {
                    maxSum = points;
                    tempName = name;
                }
            }
            Console.WriteLine("The winner is {0} - {1} points", tempName, maxSum);
        }
    }
}
