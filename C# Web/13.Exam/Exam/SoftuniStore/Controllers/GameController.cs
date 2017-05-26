using DataTransferObjects.BindingModels;
using DataTransferObjects.ViewModels;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using System.Collections.Generic;
using System.Linq;

namespace SoftuniStore.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService service;
        private readonly Security.Security.AuthenticationManager manager;

        public GameController()
        {
            this.service = new GameService(new SoftuniStoreData());
            this.manager = new Security.Security.AuthenticationManager(new SoftuniStoreData());
        }

        [HttpGet]
        public IActionResult<List<GameViewModel>> Index(HttpResponse response, HttpSession session)
        {
            var gameViewModel = this.service.GetAll(session);

            if (gameViewModel.Any(g => g.IsAuthenticated == false))
            {
                this.Redirect(response, "/game/index");
            }

            return this.View(gameViewModel);
        }

        [HttpGet]
        public IActionResult<List<AllGamesViewModel>> Allgames(HttpResponse response, HttpSession session)
        {
            var isAdmin = this.manager.IsAdmin(session);

            if (isAdmin)
            {
                var allGames = this.service.All();

                return this.View(allGames);
            }
            else
            {
                this.Redirect(response, "/account/login");
                return null;
            }
        }

        [HttpGet]
        public IActionResult Edit(HttpResponse response, HttpSession session)
        {
            if (this.manager.IsAuthenticated(session))
            {
                return this.View();
            }
            else
            {
                this.Redirect(response, "/account/login");
                return null;
            }
        }

        [HttpGet]
        public IActionResult<GameDetailsViewModel> Details(HttpResponse response, HttpSession session, int id)
        {
            var details = this.service.Details(id);

            if (this.manager.IsAuthenticated(session))
            {
                return this.View(details);
            }
            else
            {
                this.Redirect(response, "/account/login");
                return null;
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddGameBindingModel model)
        {
            this.service.Add(model);

            return this.View();
        }

        [HttpGet]
        public IActionResult<DeleteViewBindingModel> Delete(DeleteViewBindingModel model, int id)
        {
            this.service.Delete(id);
            //todo: 
            return this.View(new DeleteViewBindingModel());
        }


        //        [HttpPost]
        //        public IActionResult<GameDetailsViewModel> Buy(HttpResponse response, HttpSession session, int id)
        //        {
        //            var buy = this.service.Edit(id);
        //
        //            if (this.manager.IsAuthenticated(session))
        //            {
        //                return this.View(details);
        //            }
        //            else
        //            {
        //                this.Redirect(response, "/account/login");
        //                return null;
        //            }
        //        }
    }
}
