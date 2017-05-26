using System;

namespace Persons
{
    public class Person
    {

        private string name;
        private int age;
        private string email;

        public Person(string Name,int Age, string Email)
        {
            this.name = Name;
            this.age = Age;
            this.email = Email;
        }
        public Person(string Name,int Age)
            :this(Name,Age,null)
        {

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new System.ArgumentException();
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
                if (value<1 || value>100)
                {
                    throw new System.Exception();
                }
                this.age = value;
            }
        }
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (string.IsNullOrEmpty(value) && value.Contains("@"))
                {
                    throw new Exception();
                }
                this.email = value;
            }

        }
        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}, Email: {2}", this.name, this.age, this.email);
        }


    }
}
