using SalesDataBase.Models;

namespace SalesDataBase
{
    using System.Data.Entity;

    public class SalesDbContext : DbContext
    {
        public SalesDbContext()
            : base("SalesDbContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SalesDbContext>());
            this.Database.Initialize(true);
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<StoreLocation> StoreLocations { get; set; }

        public IDbSet<Sale> Sales { get; set; }
    }
}