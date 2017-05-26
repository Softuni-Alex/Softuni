namespace StupidList
{
    using System;
    using System.Diagnostics;

    public class StupidListMain
    {
        static Random rng = new Random();
        private static Stopwatch timer = new Stopwatch();
        private static StupidList<char> stupidList;

        static void Main(string[] args)
        {
            stupidList = new StupidList<char>();

            for (int i = 0; i < 50; i++)
            {
                stupidList.Add((char)rng.Next(32, 128));
            }
            Console.WriteLine("Add - Expected running time O(n)");
            Add('^');
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Remove(at index) - Worst   : Expected running time O(n)");
            Console.WriteLine("Remove(at index) - Average : Expected running time O(n)");
            Console.WriteLine("Remove(at index) - Best    : Expected running time O(1)");
            Remove(1);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Remove first - Expected running time O(n)");
            RemoveFirst();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Remove last - Expected running time O(n)");
            RemoveLast();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Lenght - Expected running time O(1)");
            Lenght();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Index -  Expected running time O(1)");
            Index();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("First -  Expected running time O(1)");
            First();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Last -  Expected running time O(1)");
            Last();
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Expected running time O(n)
        /// </summary>
        /// <param name="c"></param>
        public static void Add(char c)
        {
            timer.Reset();
            timer.Start();
            stupidList.Add(c);
            timer.Stop();
            Console.Write("Index() :");
            Console.WriteLine(timer.Elapsed);
        }

        /// <summary>
        /// Worst case
        /// Expected running time O(n)
        /// Avarage 
        /// Expected running time O(n)
        /// Best case (1 element in list)
        /// Expected running time O(1)
        /// </summary>
        /// <param name="index"></param>
        public static void Remove(int index)
        {
            timer.Reset();
            timer.Start();
            stupidList.Remove(index);
            timer.Stop();
            Console.Write("Remove(index) : ");
            Console.WriteLine(timer.Elapsed);
        }

        /// <summary>
        /// Expected running time O(n)
        /// </summary>
        public static void RemoveFirst()
        {
            timer.Reset();
            timer.Start();
            stupidList.RemoveFirst();
            timer.Stop();
            Console.Write("RemoveFirst() : ");
            Console.WriteLine(timer.Elapsed);
        }

        /// <summary>
        /// Expected running time O(n)
        /// </summary>
        public static void RemoveLast()
        {
            timer.Reset();
            timer.Start();
            stupidList.RemoveLast();
            timer.Stop();
            Console.Write("RemoveLast() : ");
            Console.WriteLine(timer.Elapsed);
        }

        /// <summary>
        /// Expected running time O(1)
        /// </summary>
        public static void Lenght()
        {
            timer.Reset();
            timer.Start();
            int x = stupidList.Length;
            timer.Stop();
            Console.Write("Lenght() : ");
            Console.WriteLine(timer.Elapsed);
        }

        /// <summary>
        /// Expected running time O(1)
        /// </summary>
        public static void Index()
        {
            timer.Reset();
            timer.Start();
            char x = stupidList[1];
            timer.Stop();
            Console.Write("Index() : ");
            Console.WriteLine(timer.Elapsed);
        }

        /// <summary>
        /// Expected running time O(1)
        /// </summary>
        public static void First()
        {
            timer.Reset();
            timer.Start();
            char x = stupidList.First;
            timer.Stop();
            Console.Write("First() : ");
            Console.WriteLine(timer.Elapsed);
        }
        /// <summary>
        /// Expected running time O(1)
        /// </summary>
        public static void Last()
        {
            timer.Reset();
            timer.Start();
            char x = stupidList.Last;
            timer.Stop();
            Console.Write("Last() : ");
            Console.WriteLine(timer.Elapsed);
        }
    }
}