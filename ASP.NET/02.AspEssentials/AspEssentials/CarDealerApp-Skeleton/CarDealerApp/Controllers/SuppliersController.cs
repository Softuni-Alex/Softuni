using CarDealer.Data;
using CarDealer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly CarDealerContext data;

        public SuppliersController()
        {
            this.data = new CarDealerContext();
        }

        public ActionResult Local()
        {
            var local = this.data.Suppliers.ToList();

            var nonParts = new List<Supplier>();

            foreach (var supplier in local)
            {
                nonParts.Add(new Supplier
                {
                    Id = supplier.Id,
                    Name = supplier.Name,
                    IsImporter = supplier.IsImporter
                });
            }

            return this.View(nonParts);
        }

        public ActionResult Importers()
        {
            var importers = this.data.Suppliers.ToList();

            return this.View(importers);
        }
    }
}