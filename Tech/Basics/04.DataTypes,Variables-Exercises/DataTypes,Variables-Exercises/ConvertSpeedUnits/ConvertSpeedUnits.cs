using System;

namespace ConvertSpeedUnits
{
    class ConvertSpeedUnits
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            float distanceInMiles = distance / 1609f;

            float timeInSeconds = hours * 3600f + minutes * 60f + seconds;

            Console.WriteLine(distance / timeInSeconds);
            float km = distance / 1000f;
            float timeInHours = hours + minutes / 60f + seconds / 3600f;
            Console.WriteLine(km / timeInHours);
            Console.WriteLine(distanceInMiles / timeInHours);
        }
    }
}