using CarDealer.Data;
using System.Linq;
using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    public class CarController : Controller
    {
        private readonly CarDealerContext data;

        public CarController()
        {
            this.data = new CarDealerContext();
        }

        public ActionResult Make()
        {
            var cars = this.data.Cars
                .OrderBy(c => c.Model)
                .ThenByDescending(d => d.TravelledDistance)
                .ToList();

            return this.View(cars);
        }
    }
}