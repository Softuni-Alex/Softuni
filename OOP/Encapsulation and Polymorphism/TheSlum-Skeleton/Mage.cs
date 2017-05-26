using System;
using System.Collections.Generic;
using System.Linq;
using TheSlum;
using TheSlum.Interfaces;

class Mage : Character, IAttack
{
    private int attackPoints = 300;

    public Mage(string id,
        int x,
        int y,
        int healthPoints,
        int defensePoints,
        Team team,
        int range)
        : base(id,
            x,
            y,
            healthPoints = 150,
            defensePoints = 50,
            team,
            range = 5)
    {
    }

    public int AttackPoints
    {
        get { return this.attackPoints; }
        set { this.attackPoints = value; }
    }

    public override Character GetTarget(IEnumerable<Character> targetsList)
    {
        return targetsList.ToList()[targetsList.Count() - 1];
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