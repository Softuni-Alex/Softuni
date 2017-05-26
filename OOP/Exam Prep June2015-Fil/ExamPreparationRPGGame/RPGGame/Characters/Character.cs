﻿using RPGGame.Interfaces;
using System;

namespace RPGGame.Characters
{
    public abstract class Character : GameObject, ICharacter
    {
        private string name;

        public Character(Position position, char objectSymbol, int damage, int health, string name)
            : base(position, objectSymbol)
        {
            this.Damage = damage;
            this.Health = health;
            this.Name = name;
        }
        public int Damage { get; set; }
        public int Health { get; set; }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "Name cannot be null empty or whitespace.");
                }
                this.name = value;
            }
        }

        public void Atack(ICharacter enemy)
        {
            enemy.Health -= this.Damage;
        }
    }
}
