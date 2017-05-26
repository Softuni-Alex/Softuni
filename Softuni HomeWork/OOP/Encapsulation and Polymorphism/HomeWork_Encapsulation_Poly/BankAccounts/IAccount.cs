namespace BankAccounts
{
   public interface IAccount
    {
        void DepositMoney(decimal money);

        decimal CalculateInterest(decimal money, int months);
    }
}