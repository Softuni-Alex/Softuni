using System;
using System.Collections.Generic;
using System.Linq;

namespace VehiclePark
{
    class VehiclePark
    {
        static void Main()
        {
            List<string> vehicles = Console.ReadLine().Split().ToList();

            int soldVehicles = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End of customers!")
                {
                    break;
                }

                string[] inputArgs = command.Split();
                string vehicleType = inputArgs[0];
                int seats = int.Parse(inputArgs[2]);
                string totalVehicle = vehicleType[0] + seats.ToString();
                totalVehicle = totalVehicle.ToLower();

                char priceForALetter = totalVehicle[0];

                var price = (int)priceForALetter * seats;

                if (vehicles.Contains(totalVehicle))
                {
                    Console.WriteLine("Yes, sold for {0}$", price);
                    vehicles.Remove(totalVehicle);
                    soldVehicles++;
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
            Console.WriteLine("Vehicles left: {0}", string.Join(", ", vehicles));
            Console.WriteLine("Vehicles sold: {0}", soldVehicles);
        }
    }
}