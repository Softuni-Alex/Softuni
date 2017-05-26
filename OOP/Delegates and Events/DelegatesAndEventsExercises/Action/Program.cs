using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Action
{
    class Program
    {
        static void Main()
        {

            List<int> collection = new List<int> { 1, 2, 3, 4, 6, 11, 3 };

            collection.MyForEach(Console.WriteLine);

        }
    }
}
