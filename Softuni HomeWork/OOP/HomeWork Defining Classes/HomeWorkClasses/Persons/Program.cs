using System;

namespace Persons
{
    class PersonMainClass
    {


        static void Main()
        {

            Person person1 = new Person("Alex",19);
            Person person2 = new Person("Den", 16, "alexden@gmail.com");
            Console.WriteLine(person1);
            Console.WriteLine(person2);

            
        }
    }
}