namespace IssueTracker.App.Controllers
{
    using Data;
    using Security;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;

    public class HomeController : Controller
    {
        private AuthenticationManager authenticationManager;

        public HomeController()
        {
            this.authenticationManager = new AuthenticationManager(new IssuesContext());
        }

        [HttpGet]
        public IActionResult<bool> Index(HttpSession session, HttpResponse response)
        {
            return View(this.authenticationManager.IsAuthenticated(session));
        }
    }
}
