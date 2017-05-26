using DbEntities.Models;

namespace DbEntities
{
    using System.Data.Entity;

    public class SoftuniStoreContext : DbContext
    {
        public SoftuniStoreContext()
            : base("name=SoftuniStoreContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Login> Logins { get; set; }
    }
}