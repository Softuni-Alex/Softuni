using System;
using System.Linq;

namespace PrintAReceipt
{
    class PrintAReceipt
    {
        static void Main(string[] args)
        {
            decimal[] seq = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

            int width = 24;

            //top
            Console.WriteLine("/" + new string('-', width - 2) + "\\");

            //middle
            for (int i = 0; i < seq.Length; i++)
            {
                Console.WriteLine("| {0,20:f2} |", seq[i]);
            }
            Console.WriteLine("|" + new string('-', width - 2) + "|");

            //total
            Console.WriteLine("| Total:{0,14:f2} |", seq.Sum());

            //bot
            Console.WriteLine("\\" + new string('-', width - 2) + "/");
        }
    }
}