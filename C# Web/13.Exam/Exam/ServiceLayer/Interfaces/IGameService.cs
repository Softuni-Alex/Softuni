using DataTransferObjects.BindingModels;
using DataTransferObjects.ViewModels;
using SimpleHttpServer.Models;
using System.Collections.Generic;

namespace ServiceLayer.Interfaces
{
    public interface IGameService
    {
        List<GameViewModel> GetAll(HttpSession session);

        GameDetailsViewModel Details(int id);

        List<AllGamesViewModel> All();

        void Add(AddGameBindingModel model);

        void Delete(int id);
    }
}
