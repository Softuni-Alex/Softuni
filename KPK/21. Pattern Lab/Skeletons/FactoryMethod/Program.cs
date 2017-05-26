using FactoryMethod.Units;
using TankManufacturer.Units;

namespace TankManufacturer
{
    using System;

    class Program
    {
        static void Main()
        {
            var factory = new AmericanFactory();
            var fuuoi = factory.CreateTank();
          

            Console.WriteLine(fuuoi);
        }
    }
}
