using System.Collections.Generic;

namespace Func
{
    class Program
    {
        static void Main()
        {

            List<int> collection = new List<int> { 1, 2, 3, 4, 5, 6, 11, 3 };

            System.Console.WriteLine(string.Join(", ", collection.TakeWhile(x => x < 10)));

        }
    }
}
