using System;
using System.Collections.Generic;

namespace CommonStrings
{
    class CommonStrings
    {
        public static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();

            var result1 = s1.ToCharArray();
            var result2 = s2.ToCharArray();

            List<char> a1 = new List<char>();
            List<char> a2 = new List<char>();


            foreach (var temp1 in result1)
            {
                foreach (var temp2 in result2)
                {
                    if (temp1.Equals(temp2))
                    {
                        a1.Add(temp1);
                    }
                    else
                    {
                        a2.Add(temp2);
                    }
                }
            }

            if (a1.Count > 0)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}