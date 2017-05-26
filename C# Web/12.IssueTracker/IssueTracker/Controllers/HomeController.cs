using DataTransferObjects.ViewModels;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces.Generic;
using Utility.Security;

namespace IssueTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService service;
        //make an interface
        private readonly SignInManager singInManager;

        public HomeController()
        {
            this.service = new HomeService(new IssueTrackerData());
            this.singInManager = new SignInManager(new IssueTrackerData());
        }
        //
        //        public HomeController(IHomeService service)
        //        {
        //            this.service = service;
        //            this.singInManager = new SignInManager(new IssueTrackerData(new IssueTrackerContext()));
        //        }

        //if needed to show the username and logout e.g. Hello, Alex
        [HttpGet]
        public IActionResult<LoggedInUserViewModel> Index(HttpSession session)
        {
            var loginModel = new LoggedInUserViewModel();

            if (this.singInManager.IsAuthenticated(session))
            {
                var user = this.service.FindUserBySession(session);

                var userName = this.service.GetUserNameByUserId(user.Id);

                loginModel.Username = userName;
            }
            return this.View(loginModel);
        }
    }
}
