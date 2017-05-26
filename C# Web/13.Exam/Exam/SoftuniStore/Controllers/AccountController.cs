using DataTransferObjects.BindingModels;
using RepositoryLayer;
using Security.Security;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using System;

namespace SoftuniStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService service;
        private readonly AuthenticationManager manager;

        public AccountController()
        {
            this.service = new AccountService(new SoftuniStoreData());
            this.manager = new AuthenticationManager(new SoftuniStoreData());
        }

        [HttpGet]
        public IActionResult Login(HttpResponse response, HttpSession session)
        {
            if (this.manager.IsAuthenticated(session))
            {
                this.Redirect(response, "/game/index");
                return null;
            }
            else
            {
                return this.View();
            }
        }

        [HttpPost]
        public void Login(HttpSession session, HttpResponse response, LoginBindingModel loginModel)
        {
            if (this.manager.IsAuthenticated(session))
            {
                this.Redirect(response, "/game/index");
            }
            else
            {
                try
                {
                    this.service.Login(session, loginModel);
                    this.Redirect(response, "/game/index");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exeption of type: {ex.GetType().Name} and Message: {ex.Message} has been thrown.");
                }
            }
        }

        [HttpGet]
        public IActionResult Register(HttpResponse response, HttpSession session)
        {
            if (this.manager.IsAuthenticated(session))
            {
                this.Redirect(response, "/game/index");
                return null;
            }
            else
            {
                return this.View();
            }
        }

        [HttpPost]
        public void Register(HttpSession session, HttpResponse response, RegisterBindingModel registerModel)
        {
            if (this.manager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/index");
            }
            else
            {
                var isRegistered = this.service.IsRegistered(registerModel);
                try
                {
                    if (isRegistered)
                    {
                        this.Redirect(response, "/account/login");
                    }
                    else
                    {
                        this.Redirect(response, "/account/register");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exeption of type: {ex.GetType().Name} and Message: {ex.Message} has been thrown.");
                }
            }
        }

        [HttpGet]
        public void Logout(HttpResponse response, HttpSession session)
        {
            try
            {
                this.service.Logout(response, session.Id);
                this.Redirect(response, "/account/login");
            }
            catch (Exception ex)
            {
                throw new Exception($"Exeption of type: {ex.GetType().Name} and Message: {ex.Message} has been thrown.");
            }
        }
    }
}