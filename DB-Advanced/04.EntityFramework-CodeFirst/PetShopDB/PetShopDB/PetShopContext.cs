namespace PetShopDB
{
    using Models;
    using System.Data.Entity;

    public class PetShopContext : DbContext
    {
        public PetShopContext()
            : base("name=PetShopContext")
        {
        }

        public IDbSet<Cat> Cats { get; set; }

        public IDbSet<Dog> Dogs { get; set; }

        public IDbSet<Cage> Cages { get; set; }

        public IDbSet<Person> Persons { get; set; }
    }
}