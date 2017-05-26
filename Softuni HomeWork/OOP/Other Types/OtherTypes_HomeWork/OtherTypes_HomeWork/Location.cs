using System;
using System.Runtime.CompilerServices;

namespace OtherTypes_HomeWork
{
    public struct Location
    {
        private double latitute;
        private double longitude;
        private Planet planet;



        public Location(double latitute, double longitude, Planet planet)
            : this()
        {
            this.Latitute = latitute;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public double Latitute
        {
            get { return this.latitute; }
            set
            {
                if (value < -90 || value > 90)
                {
                    try
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("The value must be between {-90 and 90}");
                    }
                }
                this.latitute = value;
            }
        }

        public double Longitude
        {
            get { return this.longitude; }
            set
            {
                if (value < -180 || value > 180)
                {
                    try
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("The value must be between {-180 and 180}");
                    }
                }
                this.longitude = value;
            }
        }

        public Planet Planet
        {
            get { return this.planet; }
            set { this.planet = value; }
        }


        public override string ToString()
        {
            var print = string.Format("Latitude: {0} \nLongitude: {1} \nPlanet: {2}", Latitute, Longitude, Planet);
            return print;
        }
    }
}