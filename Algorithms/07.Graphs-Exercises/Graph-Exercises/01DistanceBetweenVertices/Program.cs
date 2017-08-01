using System;
using System.Collections.Generic;
using System.Linq;

namespace _01DistanceBetweenVertices
{
    public class Program
    {
        private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        public static void Main()
        {
            int numberOfVerticles = int.Parse(Console.ReadLine());
            int numberOfPairs = int.Parse(Console.ReadLine());
            int path = 0;

            for (int i = 0; i < numberOfVerticles; i++)
            {
                string[] input = Console.ReadLine().Split(':').ToArray();

                var from = int.Parse(input[0]);

                var to = 0;
                if (input.Length == 2)
                {
                    to = int.Parse(input[1]);
                }

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, to);
                }
            }

            for (int i = 0; i < numberOfPairs; i++)
            {
                string[] input = Console.ReadLine().Split('-').ToArray();

                var from = int.Parse(input[0]);
                var to = int.Parse(input[1]);
            }
        }
    }
}
