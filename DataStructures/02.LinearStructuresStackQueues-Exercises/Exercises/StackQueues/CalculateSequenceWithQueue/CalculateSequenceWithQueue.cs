using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculateSequenceWithQueue
{
    public class CalculateSequenceWithQueue
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var queue = new Queue<int>();

            var list = new List<int>()
            {
                n
            };

            queue.Enqueue(n);
            for (int i = 0; i < 50; i++)
            {
                var first = queue.Peek() + 1;
                queue.Enqueue(first);

                var second = queue.Peek() * 2 + 1;
                queue.Enqueue(second);

                var third = first + 1;
                queue.Enqueue(third);

                queue.Dequeue();

                list.Add(first);
                list.Add(second);
                list.Add(third);

            }

            Console.WriteLine(string.Join(", ", list.Take(50)));
        }
    }
}