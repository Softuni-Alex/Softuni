using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SharpStore.BindingModels;
using SharpStore.Services;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace SharpStore.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBindingModel lubm)
        {
            LoginService service = new LoginService(Data.Data.Context);
            var user = service.GetCorrespondingUser(lubm);

            if (user == null)
            {
                this.Redirect(response, "/login/login");
                return null;
            }
            
            service.LoginUser(user, session.Id);
            this.Redirect(response, "/home/index");
            return null;
        }
    }
}
