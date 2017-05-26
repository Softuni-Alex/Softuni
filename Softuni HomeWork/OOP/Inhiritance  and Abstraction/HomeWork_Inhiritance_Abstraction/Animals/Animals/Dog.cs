using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Animals
{
    using Enums;
    class Dog:Animal
    {

        public Dog(string name,int age,Gender gender)
            :base(name,age,gender)
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("The dog {0} says: baaauu!",this.Name);
        }



    }
}
