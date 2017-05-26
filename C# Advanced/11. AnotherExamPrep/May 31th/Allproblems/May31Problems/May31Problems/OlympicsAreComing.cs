using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace May31Problems
{
    class OlympicsAreComing
    {
        static void Main()
        {
            Dictionary<string, List<string>> olympicDictionary = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "report")
            {
                string[] splitedStrings = input.Split('|');

                string athlete = splitedStrings[0];
                string country = splitedStrings[1];

                athlete = Regex.Replace(athlete, @"\s{2,}", " ").Trim();
                country = Regex.Replace(country, @"\s{2,}", " ").Trim();

                if (!olympicDictionary.ContainsKey(country))
                {
                    olympicDictionary.Add(country, new List<string>());
                }
                olympicDictionary[country].Add(athlete);

                input = Console.ReadLine();
            }

            var orderedDict = olympicDictionary.OrderByDescending(z => z.Value.Count);

            foreach (var keyValuePair in orderedDict)
            {
                Console.WriteLine("{0} ({1} participants): {2} wins", keyValuePair.Key, keyValuePair.Value.Distinct().Count(), keyValuePair.Value.Count);
            }
        }
    }
}