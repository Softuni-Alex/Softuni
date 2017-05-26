using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Inhiritance_Abstraction.Human
{
    public class Worker : Human
    {

        public decimal weekSalary;
        public int workHoursPerDay;

        public Worker(string firstName,string lastName, decimal weekSalary,int workHoursPerDay)
            :base(firstName,lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The salary cannot be negative number!");
                }
                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value < 0 && value > 24)
                {
                    throw new ArgumentOutOfRangeException("The work hours must be between 1-24!");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerDay = this.weekSalary / 7;
            decimal moneyPerHour = moneyPerDay / this.workHoursPerDay;
            return moneyPerHour; 

        }

    }
}
