using System;

namespace HogwartsSorting
{
    class HogwartsSorting
    {
        static void Main(string[] args)
        {
            int numberOfNewcommers = int.Parse(Console.ReadLine());

            int gryffindorCounter = 0;
            int slytherinCounter = 0;
            int ravenclawCounter = 0;
            int hufflepuffCounter = 0;

            for (int i = 0; i < numberOfNewcommers; i++)
            {
                string[] name = Console.ReadLine().Split();
                string firstName = name[0];
                string lastName = name[1];

                int asciiSum = 0;

                for (int j = 0; j < firstName.Length; j++)
                {
                    asciiSum += firstName[j];
                }

                for (int j = 0; j < lastName.Length; j++)
                {
                    asciiSum += lastName[j];
                }

                string facultyNumber = asciiSum.ToString() + firstName[0] + lastName[0];

                int result = asciiSum % 4;
                if (result == 0)
                {
                    gryffindorCounter++;
                    Console.WriteLine("Gryffindor {0}", facultyNumber);
                }
                if (result == 1)
                {
                    slytherinCounter++;
                    Console.WriteLine("Slytherin {0}", facultyNumber);
                }
                if (result == 2)
                {
                    ravenclawCounter++;
                    Console.WriteLine("Ravenclaw {0}", facultyNumber);
                }
                if (result == 3)
                {
                    hufflepuffCounter++;
                    Console.WriteLine("Hufflepuff {0}", facultyNumber);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Gryffindor: {0}", gryffindorCounter);
            Console.WriteLine("Slytherin: {0}", slytherinCounter);
            Console.WriteLine("Ravenclaw: {0}", ravenclawCounter);
            Console.WriteLine("Hufflepuff: {0}", hufflepuffCounter);
        }
    }
}