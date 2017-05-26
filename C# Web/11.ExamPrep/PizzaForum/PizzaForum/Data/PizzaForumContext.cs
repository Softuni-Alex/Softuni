using PizzaForum.Models;

namespace PizzaForum.Data
{
    using System.Data.Entity;

    public class PizzaForumContext : DbContext
    {
        public PizzaForumContext()
            : base("name=PizzaForumContext")
        {
        }

        public virtual DbSet<Replie> Replies { get; set; }

        public virtual DbSet<Topic> Topics { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Categorie> Categories { get; set; }
    }
}