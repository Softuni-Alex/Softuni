using DataTransferObjects.BindingModels;
using DataTransferObjects.ViewModels;
using DbEntities.Models;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;
using SimpleHttpServer.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Services
{
    public class GameService : Service, IGameService
    {
        private readonly Security.Security.AuthenticationManager manager;

        public GameService(ISoftuniStoreData data)
            : base(data)
        {
            this.manager = new Security.Security.AuthenticationManager(data);
        }

        public List<GameViewModel> GetAll(HttpSession session)
        {
            var games = this.Data.Games.Query().ToList();
            var isAuthenticated = this.manager.IsAuthenticated(session);

            List<GameViewModel> gameViewModel = new List<GameViewModel>();

            foreach (var game in games)
            {
                if (isAuthenticated)
                {
                    gameViewModel.Add(new GameViewModel
                    {
                        Id = game.Id,
                        Description = game.Description,
                        ImageUrl = game.ImageUrl,
                        Price = game.Price,
                        Size = game.Size,
                        Title = game.Title,
                        IsAuthenticated = true
                    });
                }
                else
                {
                    gameViewModel.Add(new GameViewModel
                    {
                        Id = game.Id,
                        Description = game.Description,
                        ImageUrl = game.ImageUrl,
                        Price = game.Price,
                        Size = game.Size,
                        Title = game.Title,
                        IsAuthenticated = false
                    });
                }
            }

            return gameViewModel;
        }

        public GameDetailsViewModel Details(int id)
        {
            var game = this.Data.Games.Query().FirstOrDefault(g => g.Id == id);

            if (game != null)
            {
                var details = new GameDetailsViewModel()
                {
                    ReleaseDate = game.ReleaseDate,
                    Description = game.Description,
                    Id = game.Id,
                    Trailer = game.Trailer,
                    Price = game.Price,
                    Size = game.Size,
                    Title = game.Title
                };

                return details;
            }
            return null;
        }

        public List<AllGamesViewModel> All()
        {
            var games = this.Data.Games.Query().ToList();

            var allgamesViewModel = new List<AllGamesViewModel>();

            foreach (var game in games)
            {
                allgamesViewModel.Add(new AllGamesViewModel()
                {
                    Title = game.Title,
                    Size = game.Size,
                    Price = game.Price
                });
            }

            return allgamesViewModel;
        }

        public void Add(AddGameBindingModel model)
        {
            this.CheckIfNull(model);

            var game = new Game()
            {
                ImageUrl = model.Thumbnail,
                Description = model.Description,
                Size = model.Size,
                Price = model.Price,
                ReleaseDate = model.ReleaseDate,
                Title = model.Title,
                Trailer = model.VideoUrl
            };

            this.Data.Games.Add(game);
            this.Data.SaveChanges();
        }

        public void Delete(int id)
        {
            var first = this.Data.Games.Query().FirstOrDefault(g => g.Id == id);

            this.Data.Games.Delete(first);
            this.Data.SaveChanges();
        }
    }
}
