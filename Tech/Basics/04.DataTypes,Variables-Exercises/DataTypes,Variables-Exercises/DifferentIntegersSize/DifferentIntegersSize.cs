using System;
using System.Collections.Generic;

namespace DifferentIntegersSize
{
    class DifferentIntegersSize
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            List<string> numbers = new List<string>();

            try
            {
                sbyte s = sbyte.Parse(number.ToString());
                numbers.Add("* sbyte");
            }
            catch (Exception)
            {
            }
            try
            {
                byte s = byte.Parse(number.ToString());
                numbers.Add("* byte");
            }
            catch (Exception)
            {
            }
            try
            {
                short s = short.Parse(number.ToString());
                numbers.Add("* short");
            }
            catch (Exception)
            {
            }
            try
            {
                ushort s = ushort.Parse(number.ToString());
                numbers.Add("* ushort");
            }
            catch (Exception)
            {
            }
            try
            {
                int s = int.Parse(number.ToString());
                numbers.Add("* int");
            }
            catch (Exception)
            {
            }
            try
            {
                uint s = uint.Parse(number.ToString());
                numbers.Add("* uint");
            }
            catch (Exception)
            {
            }
            try
            {
                long s = long.Parse(number.ToString());
                numbers.Add("* long");
            }
            catch (Exception)
            {
            }
            if (numbers.Count > 0)
            {
                Console.WriteLine("{0} can fit in:", number);
                Console.WriteLine(string.Join("\n", numbers));
            }
            else
            {
                Console.WriteLine($"{number} can't fit in any type");
            }
        }
    }
}