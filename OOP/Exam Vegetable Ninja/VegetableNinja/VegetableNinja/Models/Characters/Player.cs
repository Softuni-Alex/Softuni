namespace VegetableNinja.Models.Characters
{
    using Interfaces;
    using System;
    using System.Collections.Generic;

    public abstract class Player : GameObject, IPlayer
    {
        private int stamina = 1;
        private int power = 1;
        private string name;
        //Declare a list for collecting vegetables
        private List<Vegetables.Vegetable> vegetableList;

        protected Player(Position.Position position, char objectSymbol, int stamina, int power, string name)
            : base(position, objectSymbol)
        {
            this.Stamina = stamina;
            this.Power = power;
            this.Name = name;
            this.vegetableList = new List<Vegetables.Vegetable>();
        }

        public string Name { get; set; }

        public int Stamina
        {
            get { return this.stamina; }
            set
            {
                if (this.stamina < 0)
                {
                    this.stamina = 0;
                }
                this.stamina = value;
            }
        }

        public int Power
        {
            get { return this.power; }
            set
            {
                if (this.power < 0)
                {
                    this.power = 0;
                }
                this.power = value;
            }
        }

        public IEnumerable<Vegetables.Vegetable> Vegetables
        {
            get { return this.vegetableList; }
        }

        public void Move(string direction)
        {
            switch (direction.ToUpper())
            {
                case "U":
                    this.Position = new Position.Position(this.Position.X, this.Position.Y - 1);
                    break;
                case "D":
                    this.Position = new Position.Position(this.Position.X, this.Position.Y + 1);
                    break;
                case "L":
                    this.Position = new Position.Position(this.Position.X - 1, this.Position.Y);
                    break;
                case "R":
                    this.Position = new Position.Position(this.Position.X + 1, this.Position.Y);
                    break;
                default:
                    throw new ArgumentException("Invalid direction.", nameof(direction));
            }
        }

        public void CollectVegetables(Vegetables.Vegetable vegetables)
        {
            this.vegetableList.Add(vegetables);
        }

        public void EatVegetables()
        {
            throw new NotImplementedException();
        }
    }
}