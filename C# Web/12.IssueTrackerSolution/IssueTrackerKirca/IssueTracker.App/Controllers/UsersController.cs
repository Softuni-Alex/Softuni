namespace IssueTracker.App.Controllers
{
    using System.Collections.Generic;
    using BindingModels;
    using Data;
    using Security;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;

    public class UsersController : Controller
    {
        private AuthenticationManager authenticationManager;
        private UsersService usersService;

        public UsersController()
        {
            this.usersService = new UsersService();
            this.authenticationManager = new AuthenticationManager(new IssuesContext());
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (!ViewBag.Bag.ContainsKey("errors"))
            {
                ViewBag.Bag.Add("errors", new List<ErrorViewModel>());
            }
            else
            {
                ViewBag.Bag["errors"] = new List<ErrorViewModel>();
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel rubm, HttpResponse response, HttpSession session)
        {
            List<ErrorViewModel> potentialErrors = this.usersService.ValidateRegisterUserBindingModel(rubm);
            if (potentialErrors.Count > 0)
            {
                if (!ViewBag.Bag.ContainsKey("errors"))
                {
                    ViewBag.Bag.Add("errors", potentialErrors);
                }
                else
                {
                    ViewBag.Bag["errors"] = potentialErrors;
                }

                return View();
            }

            this.usersService.RegisterUser(rubm);

            Redirect(response, "/users/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel lubm, HttpSession session, HttpResponse response)
        {
            if (this.usersService.LoginUser(lubm, session.Id))
            {
                Redirect(response, "/home/index");
                return null;
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Logout(HttpSession session, HttpResponse response)
        {
            if (this.authenticationManager.IsAuthenticated(session))
            {
                this.usersService.LogoutUser(session.Id);
                var newSession = SessionCreator.Create();
                var sessionCookie = new Cookie("sessionId", newSession.Id + "; HttpOnly; path=/");
                response.Header.Cookies["sessionId"] = sessionCookie;
            }

            this.Redirect(response, "/home/index");
            return null;
        }
    }
}
