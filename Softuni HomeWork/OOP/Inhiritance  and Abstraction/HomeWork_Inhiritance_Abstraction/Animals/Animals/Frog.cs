using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Animals
{
    using Enums;
    class Frog:Animal
    {
        public Frog(string name,int age,Gender gender)
            :base(name,age,gender)
        {

        }


        public override void ProduceSound()
        {
            Console.WriteLine("The frog {0} says: kwak",this.Name);
        }
    }
}
