using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Animals
{
    using Enums;
    class Kitten:Cat
    {

        public Kitten(string name,int age,Gender gender)
            :base(name,age,gender)
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("The kitten {0} says: meaaaaaaaow",this.Name);
        }

    }
}
