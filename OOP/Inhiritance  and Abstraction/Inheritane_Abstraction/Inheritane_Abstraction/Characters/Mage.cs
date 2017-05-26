using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritane_Abstraction.Characters
{
   public class Mage : Characters,IAtack
    {

       public Mage()
           :base(100,300,75)
       {

       }

       public override void Atack(Characters target)
       {
           this.Mana -= 100;
           target.Health -= 2 * this.Damage;
       }

    }
}
