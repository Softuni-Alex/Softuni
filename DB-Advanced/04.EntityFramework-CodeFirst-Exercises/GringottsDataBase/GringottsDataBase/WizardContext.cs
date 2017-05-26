namespace GringottsDataBase
{
    using Models;
    using System.Data.Entity;

    public class WizardContext : DbContext
    {
        public WizardContext()
            : base("name=WizardContext")
        {
        }

        public IDbSet<WizardDeposit> WizardDeposits { get; set; }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Town> Towns { get; set; }
    }
}