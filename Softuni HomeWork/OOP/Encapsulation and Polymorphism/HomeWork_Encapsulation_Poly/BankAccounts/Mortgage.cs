using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankAccounts
{
    class Mortgage : Account
    {
        //constructor
        public Mortgage(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        { }

        //methods
        public override decimal CalculateInterest(decimal money, int months)
        {
            decimal interest = money * (1 + this.InterestRate * months);
            if (months < 6 && this.Customer == Customer.Individual)
            {
                return 0;
            }
            else if (months < 12 && this.Customer == Customer.Company)
            {
                return interest / 2;
            }
            return interest;
        }
    }
}