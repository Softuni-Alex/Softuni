using System;
using System.Collections.Generic;
using SharpStore.BindingModels;
using SharpStore.Services;
using SharpStore.ViewModels;
using SharpStore.Views.Home;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SimpleMVC.ViewEngine;

namespace SharpStore.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult<IEnumerable<ProductViewModel>> Products(string productName)
        {
            if (productName == null)
            {
                productName = String.Empty;
            }

            ProductsService service = new ProductsService(Data.Data.Context);
            IEnumerable<ProductViewModel> viewModels = service.GetProducts(productName);

            return this.View(viewModels);
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Contacts(HttpResponse response, MessageBinding messageBindingModel)
        {
            if (string.IsNullOrEmpty(messageBindingModel.Email) || string.IsNullOrEmpty(messageBindingModel.Subject))
            {
                this.Redirect(response, "/home/contacts");
                return null;
            }

            MessagesService service = new MessagesService(Data.Data.Context);
            service.AddMessageFromBind(messageBindingModel);

            this.Redirect(response, "/home/index");
            return this.View();
        }

        [HttpGet]
        public IActionResult<BuyKnifeViewModel> Buy(int knifeId, HttpResponse response)
        {
            BuyService service = new BuyService(Data.Data.Context);
            if (!service.IsKnifeIdValid(knifeId))
            {
                this.Redirect(response, "/home/products");
                return null;
            }

            return this.View(new BuyKnifeViewModel()
            {
                KnifeId = knifeId
            });
        }

        [HttpPost]
        public IActionResult Buy(PurchaseBindingModel model, HttpResponse responce)
        {
            BuyService service = new BuyService(Data.Data.Context);
            service.AddPurchase(model);

            this.Redirect(responce, "/home/index");
            return null;
        }
    }
}
