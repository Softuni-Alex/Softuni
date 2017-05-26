using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpStore.BindingModels;
using SharpStore.Models;
using SharpStore.Services;
using SharpStore.Utilities;
using SharpStore.ViewModels;
using SharpStore.Views.Home;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace SharpStore.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult Add(HttpSession session, HttpResponse response)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (user == null)
            {
                this.Redirect(response, "/login/login");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Add(HttpSession session, HttpResponse response, AddProductBindingModel binding)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (user == null)
            {
                this.Redirect(response, "/login/login");
                return null;
            }

            ProductsService service = new ProductsService(Data.Data.Context);
            service.AddProduct(binding);

            this.Redirect(response, "/admin/index");
            return null;
        }

        [HttpGet]
        public IActionResult<EditProductViewModel> Edit(HttpSession session, HttpResponse response, int knifeId)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (user == null)
            {
                this.Redirect(response, "/login/login");
                return null;
            }

            ProductsService service = new ProductsService(Data.Data.Context);
            EditProductViewModel model = service.GetEditProductViewModel(knifeId);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(HttpSession session, HttpResponse response, EditProductBindingModel bind)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (user == null)
            {
                this.Redirect(response, "/login/login");
                return null;
            }

            ProductsService service = new ProductsService(Data.Data.Context);
            service.UpdateProduct(bind);

            this.Redirect(response, "/admin/index");
            return null;
        }

        [HttpGet]
        public IActionResult Delete(HttpSession session, HttpResponse response, int knifeId)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (user == null)
            {
                this.Redirect(response, "/login/login");
                return null;
            }

            ProductsService service = new ProductsService(Data.Data.Context);
            service.DeleteKnife(knifeId);

            this.Redirect(response, "/admin/index");
            return null;
        }
    }
}
