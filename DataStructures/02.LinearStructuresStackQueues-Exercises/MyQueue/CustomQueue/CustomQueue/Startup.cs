using System;

namespace CustomQueue
{
    public static class Startup
    {
        public static void Main(string[] args)
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Dequeue();
            queue.Enqueue(5);

            foreach (var test in queue)
            {
                Console.WriteLine(test + " ");
            }
        }
    }
}
