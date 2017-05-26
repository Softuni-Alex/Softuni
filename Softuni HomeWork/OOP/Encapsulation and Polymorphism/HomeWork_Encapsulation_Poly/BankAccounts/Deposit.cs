using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    class Deposit : Account
    {
        //constructor
        public Deposit(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        { }

        //methods
        public override decimal CalculateInterest(decimal money, int months)
        {
            if (money < 1000)
            {
                return 0;
            }
            return money * (1 + this.InterestRate * months);
        }

        public void Withdraw(decimal money)
        {
            this.Balance -= money;
        }
    }
}