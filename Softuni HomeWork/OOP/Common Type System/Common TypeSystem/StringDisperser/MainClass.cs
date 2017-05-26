using System;

namespace StringDisperser
{
    class MainClass
    {
        static void Main()
        {

            StringDisperser disperser = new StringDisperser("bye", "gym");
            Console.WriteLine(disperser);
            foreach (var ch in disperser)
            {
                Console.Write(ch + " ");
            }
            StringDisperser disperser2 = new StringDisperser("okay", "shit!");
            Console.WriteLine();
            Console.WriteLine(disperser.CompareTo(disperser2));
            StringDisperser disperser2Copy = (StringDisperser)disperser2.Clone();
            disperser2Copy.Strings[0] = "new";
            Console.WriteLine(disperser2Copy);
            Console.WriteLine(disperser2);
        }
    }
}
