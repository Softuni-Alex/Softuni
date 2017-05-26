using SimpleMVC.App.Models;
using System.Data.Entity;

namespace SimpleMVC.App.Data
{
    public class SharpStoreContext : DbContext
    {
        public SharpStoreContext()
            : base("name=SharpStoreContext")
        {
        }

        public virtual DbSet<Knive> Knives { get; set; }

        public virtual DbSet<Messages> Messages { get; set; }

        public virtual DbSet<Bought> Bought { get; set; }
    }
}