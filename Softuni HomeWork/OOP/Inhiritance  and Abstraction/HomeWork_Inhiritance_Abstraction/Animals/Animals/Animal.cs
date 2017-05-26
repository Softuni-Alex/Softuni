using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Animals.Animals
{
    using Enums;
    using Interfaces;
    public abstract class Animal : ISoundProducible
    {
        private string name;
        private int age;

        public Animal(string name,int age,Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
      

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("You have to type a name!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (age < 0 && age > 120)
                {
                    throw new ArgumentOutOfRangeException("Ages should be 1-119!");
                }
                this.age = value;
            }
        }

        public Gender Gender { get; set; }

        public abstract void ProduceSound();




    }
}
