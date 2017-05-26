using SharpStore.Models;

namespace SharpStore.Data
{
    using System.Data.Entity;

    public class SharpStoreContext : DbContext
    {
        public SharpStoreContext()
            : base("SharpStoreContext")
        {
        }

        public DbSet<Knive> Knives { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Login> Logins { get; set; }
    }
}