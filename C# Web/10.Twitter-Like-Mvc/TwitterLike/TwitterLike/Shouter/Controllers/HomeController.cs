using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace Shouter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
