using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoffeeSupplies
{
    public class SoftUniCoffeSupplies
    {
        public static void Main(string[] args)
        {
            string[] delimiters = Console.ReadLine().Split(' ');
            var personCoffeeType = new Dictionary<string, string>();
            var coffeeTypeCount = new Dictionary<string, long>();

            string commandLine = Console.ReadLine();
            while (!commandLine.Equals("end of info"))
            {
                var tokens = commandLine
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();

                string coffeeType;
                if (char.IsDigit(tokens[1][0]))
                {
                    coffeeType = tokens[0];
                    long coffeeQuantity = long.Parse(tokens[1]);

                    if (!coffeeTypeCount.ContainsKey(coffeeType))
                    {
                        coffeeTypeCount.Add(coffeeType, 0);
                    }

                    coffeeTypeCount[coffeeType] += coffeeQuantity;
                }
                else
                {
                    string personName = tokens[0];
                    coffeeType = tokens[1];

                    if (!personCoffeeType.ContainsKey(personName))
                    {
                        personCoffeeType.Add(personName, coffeeType);
                    }

                    personCoffeeType[personName] = coffeeType;

                    if (!coffeeTypeCount.ContainsKey(coffeeType))
                    {
                        coffeeTypeCount.Add(coffeeType, 0);
                    }
                }
                commandLine = Console.ReadLine();
            }

            if (coffeeTypeCount.Any(p => p.Value == 0))
            {
                var empty = coffeeTypeCount.Where(p => p.Value == 0);
                foreach (var item in empty)
                {
                    Console.WriteLine("Out of {0}", item.Key);
                }
            }

            commandLine = Console.ReadLine();
            while (!commandLine.Equals("end of week"))
            {
                var tokens = commandLine.Split();

                string personName = tokens[0];
                long coffeCount = long.Parse(tokens[1]);
                string coffeType = personCoffeeType[personName];
                coffeeTypeCount[coffeType] -= coffeCount;

                if (coffeeTypeCount[coffeType] <= 0)
                {
                    coffeeTypeCount[coffeType] = 0;
                    Console.WriteLine("Out of {0}", coffeType);
                }

                commandLine = Console.ReadLine();
            }

            Console.WriteLine("Coffee Left:");
            foreach (var pair in coffeeTypeCount
                .Where(p => p.Value > 0)
                .OrderByDescending(p => p.Value))
            {
                Console.WriteLine("{0} {1}", pair.Key, pair.Value);
            }

            Console.WriteLine("For:");
            foreach (var pair in personCoffeeType
                .Where(p => coffeeTypeCount[p.Value] > 0)
                .OrderBy(p => p.Value)
                .ThenByDescending(p => p.Key))
            {
                Console.WriteLine("{0} {1}", pair.Key, pair.Value);
            }
        }
    }
}