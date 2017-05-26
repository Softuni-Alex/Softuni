using System;

namespace AnimalType
{
    class AnimalType
    {
        static void Main(string[] args)
        {
            string inputAnimal = Console.ReadLine();

            switch (inputAnimal)
            {
                case "dog":
                    Console.WriteLine("mammal");
                    break;
                case "crocodile":
                case "tortoise":
                case "snake":
                    Console.WriteLine("reptile");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}