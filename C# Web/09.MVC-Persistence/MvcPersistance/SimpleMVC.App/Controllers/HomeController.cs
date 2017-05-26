using SimpleHttpServer.Models;
using SimpleMVC.App.Data;
using SimpleMVC.App.Security;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace SimpleMVC.App.Controllers
{
    public class HomeController : Controller
    {
        private SignInManager signInManger;

        public HomeController()
        {
             this.signInManger = new SignInManager(new PizzaMoreContext());   
        }

        [HttpGet]
        public IActionResult Index(HttpSession session, HttpResponse response)
        {
            if (this.signInManger.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/indexlogged");
            }

            return this.View();
        }

        public IActionResult Indexlogged(HttpSession session)
        {
            return this.View();
        }

    }
}
