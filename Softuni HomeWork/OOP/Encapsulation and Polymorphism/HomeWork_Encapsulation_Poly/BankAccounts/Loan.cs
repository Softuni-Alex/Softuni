using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    class Loan : Account
    {
        //constructor
        public Loan(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        { }

        //methods
        public override decimal CalculateInterest(decimal money, int months)
        {
            if (months < 3 && this.Customer == Customer.Individual)
            {
                return 0;
            }
            else if (months < 2 && this.Customer == Customer.Company)
            {
                return 0;
            }
            return money * (1 + this.InterestRate * months);
        }
    }
}