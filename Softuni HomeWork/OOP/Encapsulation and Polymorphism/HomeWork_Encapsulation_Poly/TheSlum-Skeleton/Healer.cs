namespace TheSlum.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheSlum.Interfaces;

    class Healer : Character, IHeal
    {
        private int healingPoints = 60;

        public Healer(string id,
            int x,
            int y,
            int healthPoints,
            int defensePoints,
            Team team,
            int range)
            : base(id,
            x,
            y,
            healthPoints = 75,
            defensePoints = 50,
            team,
            range = 6)
        {
        }

        public int HealingPoints
        {
            get
            {
                return this.healingPoints;
            }
            set
            {
                this.healingPoints = value;
            }
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var targetSortedByHealPoints = targetsList.OrderBy(t => t.HealthPoints);

            return targetSortedByHealPoints.ToList()[0];
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
        }
    }
}