using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationAggregation
{
    class PopulationAggregation
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('\\').ToArray();
            SortedDictionary<string, int> countries = new SortedDictionary<string, int>();
            Dictionary<long, string> cityes = new Dictionary<long, string>();

            while (input[0] != "stop")
            {
                char[] first = input[0].ToCharArray();
                string clearWord = string.Empty;
                for (int i = 0; i < first.Length; i++)
                {
                    if (char.IsLetter(first[i]))
                    {
                        clearWord += first[i];
                    }
                }
                if (char.IsLower(clearWord.First()))
                {
                    if (!cityes.ContainsValue(clearWord))
                    {
                        cityes.Add(long.Parse(input[2]), clearWord);
                    }

                }
                else
                {
                    if (countries.ContainsKey(clearWord))
                    {
                        countries[clearWord]++;
                    }
                    else
                    {
                        countries.Add(clearWord, 1);
                    }
                }
                char[] second = input[1].ToCharArray();
                string clearSecondWord = string.Empty;
                for (int i = 0; i < second.Length; i++)
                {
                    if (char.IsLetter(second[i]))
                    {
                        clearSecondWord += second[i];
                    }
                }
                if (char.IsLower(clearSecondWord.First()))
                {
                    if (!cityes.ContainsValue(clearSecondWord))
                    {
                        cityes.Add(long.Parse(input[2]), clearSecondWord);
                    }
                }
                else
                {
                    if (countries.ContainsKey(clearSecondWord))
                    {
                        countries[clearSecondWord]++;
                    }
                    else
                    {
                        countries.Add(clearSecondWord, 1);
                    }
                }
                input = Console.ReadLine().Split('\\').ToArray();
            }
            foreach (var item in countries)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
            int max = Math.Min(3, cityes.Count);
            int counter = 0;
            var l = cityes.OrderByDescending(b => b.Key);
            foreach (var item in l)
            {
                Console.WriteLine("{0} -> {1}", item.Value, item.Key);
                counter++;
                if (counter == max)
                {
                    break;
                }
            }
        }
    }
}