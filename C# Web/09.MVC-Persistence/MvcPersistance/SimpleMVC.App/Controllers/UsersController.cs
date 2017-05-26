using System.Linq;
using SimpleHttpServer.Models;
using SimpleMVC.App.BindingModels;
using SimpleMVC.App.Data;
using SimpleMVC.App.Models;
using SimpleMVC.App.Security;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.ViewEngine;

namespace SimpleMVC.App.Controllers
{
    public class UsersController : Controller
    {
        private SignInManager signInManger;

        public UsersController()
        {
            this.signInManger = new SignInManager(new PizzaMoreContext());
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Signup(SignupBindingModel model, HttpResponse response)
        {
            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                User userEntity = new User()
                {
                    Email = model.SignUpEmail,
                    Password = model.SignUpPassword
                };

                context.Users.Add(userEntity);
                context.SaveChanges();
            }

            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpGet]
        public IActionResult Signin()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Signin(SigninBindingModel model, HttpSession session, HttpResponse response)
        {
            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                User currentUser =
                    context.Users.FirstOrDefault(u => u.Password == model.SignInPassword && u.Email == model.SignInEmail);

                if (currentUser != null)
                {
                    Session sessionEntity = new Session()
                    {
                        SessionId = session.Id,
                        IsActive = true,
                        User = currentUser
                    };

                    context.Sessions.Add(sessionEntity);
                    context.SaveChanges();
                    this.Redirect(response, "/home/index");
                }

            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Logout(HttpSession session, HttpResponse response)
        {
            this.signInManger.Logout(response, session.Id);

            this.Redirect(response, "/home/index");
            return null;
        }
    }
}
