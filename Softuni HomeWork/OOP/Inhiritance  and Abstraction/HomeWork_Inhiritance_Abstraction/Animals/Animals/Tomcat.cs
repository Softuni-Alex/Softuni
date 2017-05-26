using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Animals
{
    using Enums;
    class Tomcat :Cat
    {
        public Tomcat(string name,int age,Gender gender)
            :base(name,age,gender)
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("The Tomcat {0} says: MEAOW",this.Name);
        }
    }
}
