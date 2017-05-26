using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccounts;

namespace Problem_2.Bank_of_Kurtovo_Konare
{
    class _DemoBankKonare
    {
        static void Main(string[] args)
        {
            Deposit depo = new Deposit(Customer.Individual, 12112312m, 31.4m);
            Console.WriteLine(depo.Balance);
            depo.DepositMoney(10210m);
            Console.WriteLine(depo.Balance);
            depo.Withdraw(10003m);
            Console.WriteLine(depo.Balance);
        }
    }
}