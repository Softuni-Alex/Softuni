using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Orders.Models;

namespace Orders
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            DataMapper dataMapper = new DataMapper();
            IEnumerable<Category> takeCategories = dataMapper.getAllCategories();
            IEnumerable<Product> takeProducts = dataMapper.getAllProducts();
            IEnumerable<Order> takeOrders = dataMapper.getAllOrders();

            // Names of the 5 most expensive products
            var first = takeProducts
                .OrderByDescending(p => p.UnitPrice)
                .Take(5)
                .Select(p => p.Name);
            Console.WriteLine(string.Join(Environment.NewLine, first));

            Console.WriteLine(new string('-', 10));

            // Number of products in each category
            var second = takeProducts
                .GroupBy(p => p.CatId)
                .Select(grp => new { Category = takeCategories.First(c => c.Id == grp.Key).Name, Count = grp.Count() })
                .ToList();
            foreach (var item in second)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));

            // The 5 top products (by order quantity)
            var third = takeOrders
                .GroupBy(o => o.ProductId)
                .Select(grp => new { Product = takeProducts.First(p => p.Id == grp.Key).Name, Quantities = grp.Sum(grpgrp => grpgrp.Quantity) })
                .OrderByDescending(q => q.Quantities)
                .Take(5);
            foreach (var item in third)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }


            Console.WriteLine(new string('-', 10));

            // The most profitable category
            var category = takeOrders
                .GroupBy(o => o.ProductId)
                .Select(g => new { CatId = takeProducts.First(p => p.Id == g.Key).CatId, price = takeProducts.First(p => p.Id == g.Key).UnitPrice, quantity = g.Sum(p => p.Quantity) })
                .GroupBy(gg => gg.CatId)
                .Select(grp => new { categoryName = takeCategories.First(c => c.Id == grp.Key).Name, totalQuantity = grp.Sum(g => g.quantity * g.price) })
                .OrderByDescending(g => g.totalQuantity)
                .First();
            Console.WriteLine("{0}: {1}", category.categoryName, category.totalQuantity);
        }
    }
}
