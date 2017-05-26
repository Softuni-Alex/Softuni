using CarDealer.Data;
using CarDealer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CarDealerContext data;

        public CustomerController()
        {
            this.data = new CarDealerContext();
        }

        public ActionResult All(string param)
        {
            if (!string.IsNullOrEmpty(param))
            {
                var customers = new List<Customer>();

                if (param.ToLower() == "ascending")
                {
                    customers = this.data.Customers.OrderBy(x => x.BirthDate).ToList();
                }
                if (param.ToLower() == "descending")
                {
                    customers = this.data.Customers.OrderByDescending(x => x.BirthDate).ToList();
                }

                return this.View(customers);
            }

            this.ViewBag.Error = "Error on loading the parameter";

            return this.View();
        }
    }
}
