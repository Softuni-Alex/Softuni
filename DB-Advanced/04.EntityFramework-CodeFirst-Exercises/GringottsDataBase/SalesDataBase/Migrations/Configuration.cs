using SalesDataBase.Models;
using System;
using System.Linq;

namespace SalesDataBase.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SalesDataBase.SalesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SalesDataBase.SalesDbContext context)
        {
            Random rnd = new Random();
            string[] names = { "Ivan", "Gosho", "Nasko", "Stamat", "Rori", "Kristian", "Rumen", "Maria", "Stanislava" };
            string[] emails = { "sada@dsa.bg", "kdsak24@ads.dsa", "dsad2@f.bg" };

            for (int i = 0; i < 5; i++)
            {
                context.Customers.AddOrUpdate(new Customer()
                {
                    Name = names[rnd.Next(names.Length)],
                    Email = emails[rnd.Next(emails.Length)]
                });
            }

            string[] productNames = { "Ketchup", "Mayo", "Samsung S6", "Kiselo mlqko", "DVD" };

            for (int i = 0; i < 5; i++)
            {
                context.Products.AddOrUpdate(new Product()
                {
                    Name = productNames[rnd.Next(productNames.Length)],
                    Price = (decimal)rnd.NextDouble() * 100m,
                    Quantity = rnd.Next(10)
                });
            }

            string[] locationNames = { "Sofia", "Varna", "Plovdiv", "Panagiurishte", "Pazarjik" };
            for (int i = 0; i < 5; i++)
            {
                context.StoreLocations.AddOrUpdate(new StoreLocation()
                {
                    LocationName = locationNames[rnd.Next(locationNames.Length)]
                });
            }


            Product[] products = context.Products.Local.ToArray();
            StoreLocation[] locations = context.StoreLocations.Local.ToArray();
            Customer[] customers = context.Customers.Local.ToArray();

            for (int i = 0; i < 5; i++)
            {
                context.Sales.AddOrUpdate(new Sale()
                {
                    ProductId = products[rnd.Next(products.Length)],
                    CustomerId = customers[rnd.Next(customers.Length)],
                    StoreLocationId = locations[rnd.Next(locations.Length)],
                    Date = DateTime.Now
                });
            }

            context.SaveChanges();
        }
    }
}