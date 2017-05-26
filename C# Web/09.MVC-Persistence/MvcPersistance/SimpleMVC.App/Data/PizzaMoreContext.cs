using System.Data.Entity;
using SimpleMVC.App.Models;

namespace SimpleMVC.App.Data
{
    public class PizzaMoreContext : DbContext
    {
        public PizzaMoreContext()
            : base("PizzaMoreContext")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Session> Sessions { get; set; }

        public IDbSet<Pizza> Pizzas { get; set; }
    }
 
}