using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy.Company
{
    using Interfaces;
    using Enums;

    class Employee : Person
    {

        private decimal salary;


        protected Employee(int id,string firstName,string lastName, decimal salary,Departments department)
            :base(id,firstName,lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                if (value <0)
                {
                    throw new ArgumentOutOfRangeException("Please enter a positive salary!");
                }
                this.salary = value;
            }
            
        }

        public Departments Department { get; set; }



    }
}
