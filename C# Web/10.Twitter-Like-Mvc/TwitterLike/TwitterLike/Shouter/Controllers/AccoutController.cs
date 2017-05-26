using Shouter.DataTransferObjects.BindingModels;
using Shouter.Services;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace Shouter.Controllers
{
    public class AccoutController : Controller
    {
        private readonly AccoutService service;

        public AccoutController(AccoutService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model, HttpResponse response)
        {
            //            var registerModel = this.service.Register(model);

            this.Redirect(response, "/home/login");
            return this.View();
        }
    }
}