using System.Linq;
using AutoMapper;
using SimpleHttpServer.Models;
using SimpleMVC.App.BindingModels;
using SimpleMVC.App.Data;
using SimpleMVC.App.Models;
using SimpleMVC.App.Security;
using SimpleMVC.App.ViewModels;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace SimpleMVC.App.Controllers
{
    public class MenuController : Controller
    {
        private SignInManager signInManger;

        public MenuController()
        {
            this.signInManger = new SignInManager(new PizzaMoreContext());
        }

        [HttpGet]
        public IActionResult<PizzaSuggestionViewModel> Index(HttpSession session, HttpResponse response)
        {
            if (!this.signInManger.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/index");
            }

            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                User currentUser = RetrieveUser(session, context);
                PizzaSuggestionViewModel viewModel = new PizzaSuggestionViewModel()
                {
                    Email = currentUser.Email,
                    PizzaSuggestions = currentUser.PizzaSuggestions
                };

                return this.View(viewModel);
            }

        }

        [HttpPost]
        public IActionResult<PizzaSuggestionViewModel> Index(VotePizzaBindingModel model, HttpSession session, HttpResponse response)
        {
            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                User currentUser = RetrieveUser(session, context);
                PizzaSuggestionViewModel viewModel = new PizzaSuggestionViewModel()
                {
                    Email = currentUser.Email,
                    PizzaSuggestions = currentUser.PizzaSuggestions
                };

                Pizza pizzaEntity = context.Pizzas.Find(model.PizzaId);
                if (model.PizzaVote == "Up")
                {
                    pizzaEntity.UpVotes++;
                }
                else
                {
                    pizzaEntity.DownVotes++;
                }

                context.SaveChanges();
                this.Redirect(response, "/menu/index");
                return null;
            }
        }

        [HttpGet]
        public IActionResult Add(HttpSession session, HttpResponse response)
        {
            if (!this.signInManger.IsAuthenticated(session))
            {
                this.Redirect(response, "/users/signin");
            }


            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddPizzaBindingModel model, HttpSession session, HttpResponse response)
        {
            if (!this.signInManger.IsAuthenticated(session))
            {
                this.Redirect(response, "/users/signin");
                return null;
            }

            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                ConfigureMapper(session, context);
                Pizza pizzaEntity = Mapper.Map<Pizza>(model);
                context.Pizzas.Add(pizzaEntity);
                context.SaveChanges();
            }

            this.Redirect(response, "/menu/index");
            return null;
        }

        [HttpGet]
        public IActionResult<PizzasViewModel> Suggestions(HttpSession session, HttpResponse response)
        {
            if (!this.signInManger.IsAuthenticated(session))
            {
                this.Redirect(response, "/users/signin");
            }

            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                User currentUser = RetrieveUser(session, context);
                PizzasViewModel viewModel = new PizzasViewModel()
                {
                    PizzaSuggestions = currentUser.PizzaSuggestions.ToList()
                };

                return this.View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult<PizzasViewModel> Suggestions(DeletePizzaBindingModel model, HttpSession session, HttpResponse response)
        {
            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                Pizza pizzaEntity = context.Pizzas.Find(model.PizzaId);
                context.Pizzas.Remove(pizzaEntity);        
                context.SaveChanges();

                User currentUser = RetrieveUser(session, context);
                PizzasViewModel viewModel = new PizzasViewModel()
                {
                    PizzaSuggestions = currentUser.PizzaSuggestions.ToList()
                };


                this.Redirect(response, "/menu/suggestions");
                return null;
            }
        }

        [HttpGet]
        public IActionResult<DetailsViewModel> Details(int pizzaId)
        {
            using (PizzaMoreContext context = new PizzaMoreContext())
            {
                Pizza pizzaEntity = context.Pizzas.Find(pizzaId);
                DetailsViewModel viewModel = new DetailsViewModel()
                {
                   Title = pizzaEntity.Title,
                   Recipe = pizzaEntity.Recipe,
                   ImageUrl = pizzaEntity.ImageUrl,
                   UpVotes = pizzaEntity.UpVotes,
                   DownVotes = pizzaEntity.DownVotes
                };

                return this.View(viewModel);
            }
        }

        private void ConfigureMapper(HttpSession session, PizzaMoreContext context)
        {
            Mapper.Initialize(
                expression => expression.CreateMap<AddPizzaBindingModel, Pizza>()
                .ForMember(p => p.Owner, config => config
                .MapFrom(u => context.Sessions.First(s => s.SessionId == session.Id).User))
                );
        }

        private static User RetrieveUser(HttpSession session, PizzaMoreContext context)
        {
            return context.Sessions.First(s => s.SessionId == session.Id).User;
        }

    }
}
