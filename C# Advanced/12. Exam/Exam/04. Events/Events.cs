using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Events
{
    public class Events
    {
        public static void Main()
        {
            Regex regex = new Regex(@"#(\D+):\s@([a-zA-z]+)\s(\d+:)(\d+)");

            Dictionary<string, Dictionary<string, string>> events = new Dictionary<string, Dictionary<string, string>>();

            int numberofEvents = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            for (int i = 0; i < numberofEvents; i++)
            {
                var match = regex.Match(input);
                if (match.Success)
                {
                    var name = match.Groups[1].Value;
                    var city = match.Groups[2].Value;
                    var hours = match.Groups[3].Value;
                    var minutes = match.Groups[4].Value;

                    if (!events.ContainsKey(city))
                    {
                        events[city] = new Dictionary<string, string>();
                    }
                    if (!events[city].ContainsKey(name))
                    {
                        events[city][name] = "";
                    }

                    events[city][name] += hours + minutes;
                }
                input = Console.ReadLine();
            }

            foreach (var eventNew in events)
            {
                var orderedCities = eventNew.Key;
                Console.WriteLine("{0}:", orderedCities);

                foreach (var eventInfo in eventNew.Value.OrderBy(x => x.Value))
                {
                    Console.WriteLine("{0}. {1} -> {2}",numberofEvents,eventNew.Key,eventNew.Value);
                }
            }
        }
    }
}