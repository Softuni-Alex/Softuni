using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Knapsack
{
    public class Knapsack
    {
        public static void Main()
        {
            var knapsackCapacity = int.Parse(Console.ReadLine());

            var items = new List<Item>();

            var command = Console.ReadLine();
            while (command != "end")
            {
                var item = command.Split();

                string name = item[0];
                int weight = int.Parse(item[1]);
                int value = int.Parse(item[2]);

                items.Add(new Item
                {
                    Name = name,
                    Weight = weight,
                    Price = value
                });

                command = Console.ReadLine();
            }

            var itemsTaken = new Item[knapsackCapacity];
            if (items.Count != 0)
            {
                itemsTaken = FillKnapsack(items, knapsackCapacity);
            }

            Console.WriteLine("Total Weight: {0}", itemsTaken.Sum(i => i.Weight));
            Console.WriteLine("Total Value: {0}", itemsTaken.Sum(i => i.Price));

            foreach (var item in itemsTaken)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static Item[] FillKnapsack(List<Item> items, int capacity)
        {
            // capacity + 1 to account for the 0 capacity
            var maxPrice = new int[items.Count, capacity + 1];
            var itemsTaken = new bool[items.Count, capacity + 1];

            // initialize the values for item 0 as a starting point which we'll use to build upon
            for (int c = 0; c <= capacity; c++)
            {
                if (items[0].Weight <= c)
                {
                    maxPrice[0, c] = items[0].Price;
                    itemsTaken[0, c] = true;
                }

            }

            // main iteration to fill the knapsack
            for (int i = 1; i < items.Count; i++)
            {
                for (int c = 0; c <= capacity; c++)
                {
                    // price if we don't take the item
                    maxPrice[i, c] = maxPrice[i - 1, c];

                    int capacityLeft = c - items[i].Weight;
                    if (capacityLeft >= 0 && maxPrice[i - 1, capacityLeft] + items[i].Price > maxPrice[i - 1, c])
                    {
                        maxPrice[i, c] = maxPrice[i - 1, capacityLeft] + items[i].Price;
                        itemsTaken[i, c] = true;
                    }
                }
            }

            // retrieve the items
            var itemsUsed = new List<Item>();
            int itemIndex = items.Count - 1;

            while (itemIndex >= 0)
            {
                if (itemsTaken[itemIndex, capacity])
                {
                    itemsUsed.Add(items[itemIndex]);
                    capacity -= items[itemIndex].Weight;
                }

                itemIndex--;
            }

            itemsUsed.Reverse();
            return itemsUsed.ToArray();
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int Price { get; set; }
    }
}