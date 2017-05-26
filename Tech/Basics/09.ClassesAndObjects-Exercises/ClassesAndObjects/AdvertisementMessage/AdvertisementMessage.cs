using System;

namespace AdvertisementMessage
{
    class AdvertisementMessage
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[]
            {
                "Excellent product",
                "Such a great product",
                "I always use that product",
                "Best product of its category"
            };

            string[] events = new string[]
            {
                "Now I feel good.",
                "I have succeeded the change.",
                "That makes miracles.",
                "I cannot believe but now I feel awesome",
                "Try it yourself, I am very satisfied"
            };

            string[] authors = new string[]
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Misha"
            };

            string[] cities = new string[]
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };

            int numberOfMessages = int.Parse(Console.ReadLine());

            Random randomGenerator = new Random();

            for (int i = 0; i < numberOfMessages; i++)
            {
                int phraseIndex = randomGenerator.Next(0, phrases.Length);
                int eventIndex = randomGenerator.Next(0, events.Length);
                int authorIndex = randomGenerator.Next(0, authors.Length);
                int cityIndex = randomGenerator.Next(0, cities.Length);

                Console.WriteLine("{0} {1} {2} - {3}", phrases[phraseIndex], events[eventIndex], authors[authorIndex], cities[cityIndex]);
            }
        }
    }
}