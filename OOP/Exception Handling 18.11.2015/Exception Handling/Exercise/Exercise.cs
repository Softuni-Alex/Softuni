using System;

namespace Exercise
{

    class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string FirstName,string LastName,int Age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Your string format is not right!");

                }
                this.firstName = value;

            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Your string format isn't right!");
                }
                this.lastName = value;
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
                if (value <0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("Your age is not valid, use age between 1 and 120!");
                }
                this.age = value;
            }
        }



    }


    class Exercise
    {
        static void Main()
        {
            try
            {
                Person Alex = new Person("Alex", "Alex", 1120);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
        }
    }
}
