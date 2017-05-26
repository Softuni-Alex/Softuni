using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritane_Abstraction.Characters
{
    public class Priest : Characters,IHeal
    {

        public Priest()
            :base(125,200,100)
        {

        }

        public override void Atack(Characters target)
        {
            this.Mana -= 100;
            target.Health -= this.Damage;
            this.Health += this.Damage / 10;
        }

        public void Heal(Characters target)
        {
            this.Mana -= 100;
            target.Health += 150;
        }

    }
}
