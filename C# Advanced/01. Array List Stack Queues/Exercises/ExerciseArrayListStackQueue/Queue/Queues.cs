using System;
using System.Collections.Generic;

namespace Queue
{
    public class Queues
    {
        public static void Main()
        {
            Queue<int> queue = new Queue<int>();
            //adding elements in the queue
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(1);
            queue.Enqueue(2);

            //removes the first entered element
            queue.Dequeue();

            //peek checks the value of the first element (5);
            queue.Peek();

            foreach (var i in queue)
            {
                Console.WriteLine(i);
            }

            queue.ToArray();
        }
    }
}