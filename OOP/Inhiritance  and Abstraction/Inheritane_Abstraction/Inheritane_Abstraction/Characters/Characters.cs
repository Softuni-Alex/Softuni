using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Inheritane_Abstraction.Characters;
namespace Inheritane_Abstraction.Characters
{
   public abstract class Characters : IAtack
    {

       protected Characters(int health,int mana,int damage)
       {
           this.Health = health;
           this.Mana = mana;
           this.Damage = damage;
       }

        public int Health { get; set; }
        public int Mana { get; set; }

        public int Damage { get; set; }

        public abstract void Atack(Characters target);



    }
}
