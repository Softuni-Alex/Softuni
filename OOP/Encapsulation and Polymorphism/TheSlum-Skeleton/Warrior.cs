namespace TheSlum.Interfaces

{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheSlum.Interfaces;

    class Warrior : Character, IAttack
    {
        private int attackPoints = 150;

        public Warrior(string id,
            int x,
            int y,
            int healthPoints,
            int defensePoints,
            Team team,
            int range)
            : base(id,
                x,
                y,
                healthPoints = 200,
                defensePoints = 100,
                team,
                range = 2)
        {
            this.AttackPoints = 150;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            set { this.attackPoints = value; }
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.ToList()[0];
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
        }

        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints += item.AttackEffect;
        }

        protected override void RemoveItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints -= item.AttackEffect;

            if (this.HealthPoints < 0)
            {
                this.HealthPoints = 1;
            }
        }
    }
}