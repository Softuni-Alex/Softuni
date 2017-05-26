using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallLeague.Models
{
    class Players
    {
        //FIELDS
        private string firstName;
        private string lastName;
        private decimal salary;
        private DateTime birthDate;
        private Teams team;
        private const int minYear = 1980;

        //CONSTRUCTORS

        public Players(string FirstName, string LastName, decimal Salary, DateTime BirthDate, Teams Team)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.salary = Salary;
            this.birthDate = BirthDate;
            this.team = Team;
        }

        //PROPERTY FOR FIRSTNAME

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length <3)
                {
                    throw new ArgumentException("Name must be at least 3 characters long.");
                }
                this.firstName = value;
            }
        }
        //PROPERTY FOR LAST NAME
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (lastName.Length <= 3)
                {
                    throw new Exception("Last name must be at least 3 characters long.");
                }
                this.lastName = value;
            }
        }

        //PROPERTY FOR SALARY
        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                if (salary < 0)
                {
                    throw new ArgumentException("The sallary cannot be negative!");
                }
                this.salary = value;
            }
        }
        //PROPERTY FOR BIRTHDATE

        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }
            set
            {
                if (value.Year < minYear)
                {
                    throw new Exception("You cannot enter a birth date lower than 1980.");
                }
                this.birthDate = value;
            }
        }





    }
}
