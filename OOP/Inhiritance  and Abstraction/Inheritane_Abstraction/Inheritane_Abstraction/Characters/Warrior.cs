using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritane_Abstraction.Characters
{
    public class Warrior : Characters
    {

        public Warrior()
            :base(300,0,120)
        {

        }

        public override void Atack(Characters target)
        {
            target.Health = target.Health - this.Damage;
        }

    }
}
