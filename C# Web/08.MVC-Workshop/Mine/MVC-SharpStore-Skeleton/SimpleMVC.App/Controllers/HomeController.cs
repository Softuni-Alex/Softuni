using SimpleHttpServer.Models;
using SimpleMVC.App.BindingModels;
using SimpleMVC.App.Data;
using SimpleMVC.App.Models;
using SimpleMVC.App.MVC.Attributes.Methods;
using SimpleMVC.App.MVC.Controllers;
using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.Services;
using System.Collections.Generic;

namespace SimpleMVC.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly SharpStoreContext context;

        public HomeController()
        {
            this.context = new SharpStoreContext();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Buy()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Buy(BuyViewModel model)
        {
            var buy = new Bought()
            {
                Name = model.Name,
                Address = model.Address,
                DeliveryType = model.DeliveryType,
                PhoneNumber = model.PhoneNumber
            };

            this.context.Bought.Add(buy);
            this.context.SaveChanges();

            return this.View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Products()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult<IEnumerable<ProductViewModel>> SearchProducts(string keyword)
        {
            ProductService service = new ProductService();

            IEnumerable<ProductViewModel> viewModels = service.GetProducts(keyword);

            return this.View(viewModels);
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return this.View();
        }

        [HttpPost]
        public void ContactsMessage(Messages message, HttpResponse response)
        {
            var messageModel = new Messages()
            {
                Sender = message.Sender,
                Subject = message.Subject,
                Message = message.Message
            };

            this.context.Messages.Add(messageModel);
            this.context.SaveChanges();

            this.Redirect(response, @"\home\index");
        }
    }
}
