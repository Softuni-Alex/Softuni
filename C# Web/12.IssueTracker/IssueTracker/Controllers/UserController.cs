using DataTransferObjects.BindingModels;
using DataTransferObjects.ViewModels;
using DbEntities;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using System;
using System.Collections.Generic;
using Utility.Utilities;

namespace IssueTracker.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService service;

        public UserController()
        {
            this.service = new UserService(new IssueTrackerData(new IssueTrackerContext()), new AccoutManager(new IssueTrackerData(new IssueTrackerContext())));
        }

        [HttpGet]
        public IActionResult<HashSet<RegistrationVerificationErrorViewModel>> Register()
        {
            return this.View(new HashSet<RegistrationVerificationErrorViewModel>());
        }

        [HttpPost]
        public void Register(RegisterUserBindingModel registerModel, HttpResponse response)
        {
            try
            {
                this.service.Register(registerModel);
                this.Redirect(response, "/user/login");
            }
            catch (Exception ex)
            {
                throw new Exception($"Exeption of type: {ex.GetType().Name} and Message: {ex.Message} has been thrown.");
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public void Login(LoginUserBingingModel loginModel, HttpResponse response, HttpSession session)
        {
            try
            {
                this.service.Login(loginModel, session.Id);

                this.Redirect(response, "/home/index");

                //                this.Redirect(response, "/user/register");
            }
            catch (Exception ex)
            {
                throw new Exception($"Exeption of type: {ex.GetType().Name} and Message: {ex.Message} has been thrown.");
            }

            //if smth dont work
            //            bool success = this.service.Login(loginModel,session.Id);
            //            if (success)
            //            {
            //                this.Redirect(response,"/home/index");
            //                return null;
            //            }
            //            return this.View();
        }

        //        [HttpGet]
        //        public IActionResult MenuLogged()
        //        {
        //            return this.View();
        //        }

        [HttpGet]
        public void Logout(HttpResponse response, HttpSession session)
        {
            try
            {
                this.service.Logout(response, session.Id);
                this.Redirect(response, "/user/login");
            }
            catch (Exception ex)
            {
                throw new Exception($"Exeption of type: {ex.GetType().Name} and Message: {ex.Message} has been thrown.");
            }
        }
    }
}
