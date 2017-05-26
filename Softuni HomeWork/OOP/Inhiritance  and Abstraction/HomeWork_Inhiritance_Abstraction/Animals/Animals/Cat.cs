using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Animals
{
    using Enums;
    abstract class Cat : Animal
    {

        protected Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("The cat {0} says: Meeooww!",this.Name);
        }



    }
}
