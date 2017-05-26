namespace GringottsDataBase
{
    using Models;
    using System;

    public class GringottsApp
    {
        public static void Main()
        {
            //            01.
            WizardDeposit wizard = new WizardDeposit();
            wizard.FirstName = "Albus";
            wizard.LastName = "Dumbledore";
            wizard.Age = 150;
            wizard.MagicWandCreator = "Antioch Peverell";
            wizard.MagicWandSize = 15;
            wizard.DepositStartDate = new DateTime(2016, 10, 20);
            wizard.DepositExpirationDate = new DateTime(2020, 10, 20);
            wizard.DepositAmount = 20000.24m;
            wizard.DepositCharge = 0.2m;
            wizard.IsDepositExpired = false;

            WizardContext context = new WizardContext();

            context.WizardDeposits.Add(wizard);
            context.SaveChanges();

            //02.
            User user = new User()
            {
                Username = "Aleax",
                Password = "alexaaaa",
                Email = "asd@abv.bg",
                ProfilePicture = "asdfghju6543wetrsdfgfh",
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Today,
                Age = 20,
                IsDeleted = false
            };

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}