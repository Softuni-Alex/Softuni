using Empires.Interface;
using System;

namespace Empires.Object
{
    public abstract class Unit : IUnit
    {
        private int health;
        private int atackDamage;


        protected Unit(int health, int atackDamage)
        {
            this.Health = health;
            this.AtackDamage = atackDamage;
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Health", "Health cannot be negative!");
                }
                this.health = value;
            }
        }

        public int AtackDamage
        {
            get { return this.atackDamage; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Damage", "You cannot deal negative damage");
                }
                this.atackDamage = value;
            }
        }

        public string ID
        {
            get { return this.GetType().Name; }
        }
    }
}
