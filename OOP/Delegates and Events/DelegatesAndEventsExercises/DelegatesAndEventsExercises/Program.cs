using System;
using System.Collections.Generic;

namespace DelegatesAndEventsExercises
{
    class Program
    {
        static void Main()
        {

            List<int> colelction = new List<int> { 1, 2, 3, 4, 5, 6, 11, 3 };

            Console.WriteLine(colelction.MyFirstOrDefault(x => x > 7));

            Console.WriteLine(colelction.MyFirstOrDefault(x => x < 0));

        }
    }
}
