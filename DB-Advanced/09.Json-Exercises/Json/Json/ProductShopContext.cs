namespace Json
{
    using Models;
    using System.Data.Entity;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
            : base("name=ProductShopContext")
        {
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Friends)
                .WithMany();
        }
    }
}