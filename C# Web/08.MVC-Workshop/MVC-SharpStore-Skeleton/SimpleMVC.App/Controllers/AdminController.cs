using System.Collections.Generic;
using SharpStore.Models;
using SharpStore.Services;
using SharpStore.Utilities;
using SharpStore.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace SharpStore.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult<IEnumerable<AdminPaneProductViewModel>> Index(HttpSession session, HttpResponse response)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (user == null)
            {
                this.Redirect(response, "/login/login");
                return null;
            }                                                                

            ProductsService service = new ProductsService(Data.Data.Context);
            var products = service.GetAdminPanelProducts();

            return this.View(products);
        }

        [HttpGet]
        public IActionResult Logout(HttpResponse response, HttpSession session)
        {
            AuthenticationManager.Logout(response, session.Id);
            this.Redirect(response, "/home/index");
            return null;
           
        }
    }
}
