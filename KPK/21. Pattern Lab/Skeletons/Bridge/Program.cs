using RPG.Characters;
using System;

namespace RPG
{
    using Bridge.Interfaces;
    using Weapons;

    public class Program
    {
        static void Main()
        {
            IWeapon axe = new Axe();
            ICharacter mage = new Mage(axe);

            IWeapon sword = new Sword();
            ICharacter warrior = new Warrior(sword);

            Console.WriteLine(mage);
            Console.WriteLine(warrior);
        }
    }
}