namespace PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PopulationCounter
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> cityCountry = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();

            while (input != "report")
            {
                string[] splitedStrings = input.Split('|');

                string city = splitedStrings[0];
                string country = splitedStrings[1];
                int populationCounter = int.Parse(splitedStrings[2]);

                if (!cityCountry.ContainsKey(country))
                {
                    cityCountry.Add(country, new Dictionary<string, long>());
                }

                cityCountry[country].Add(city, populationCounter);

                input = Console.ReadLine();
            }

            var orderedCountry = cityCountry.OrderByDescending(x => x.Value.Sum(y => y.Value));

            foreach (var keyValuePair in orderedCountry)
            {
                long totalPopulation = keyValuePair.Value.Sum(x => x.Value);
                Console.WriteLine("{0} (total population: {1})", keyValuePair.Key, totalPopulation);

                var orderedCity = keyValuePair.Value.OrderByDescending(x => x.Value);

                foreach (var city in orderedCity)
                {
                    Console.WriteLine("=>{0}: {1}", city.Key, city.Value);
                }
            }
        }
    }
}