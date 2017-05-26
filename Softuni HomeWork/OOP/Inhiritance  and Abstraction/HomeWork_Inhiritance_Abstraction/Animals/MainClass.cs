using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    using Animals;
    using Interfaces;
    using Enums;
    class MainClass
    {
        static void Main(string[] args)
        {

            Animal[] animals =
            {
                new Dog("Alexcho", 1, Gender.Male),
                new Frog("Gergancho",3,Gender.Male),
                new Kitten("Barovcho",2,Gender.Female),
                new Tomcat("Asencho",12,Gender.Male),
                 new Dog("Dancho", 5, Gender.Male),
                new Frog("Dencho",7,Gender.Female),
                new Kitten("Barcha",3,Gender.Female),
                new Tomcat("Sencho",10,Gender.Male),
            };

           
            
            var dogsAverageAge = animals.Where(x => x is Dog).Average(x => x.Age);
            Console.WriteLine("The average age of all dogs is: {0}", dogsAverageAge);

            var frogsAverageAge = animals.Where(x => x is Frog).Average(x => x.Age);
            Console.WriteLine("The average age of all frogs is: {0}", frogsAverageAge);

            var kittysAverageAge = animals.Where(x => x is Kitten).Average(x => x.Age);
            Console.WriteLine("The average age of all kitties is: {0}", kittysAverageAge);

            var tomcatsAverageAge = animals.Where(x => x is Tomcat).Average(x => x.Age);
            Console.WriteLine("The average age of all tomcats is: {0}", tomcatsAverageAge);
        }
    }
}
