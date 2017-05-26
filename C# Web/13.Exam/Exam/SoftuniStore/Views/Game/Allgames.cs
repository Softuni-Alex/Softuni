using DataTransferObjects.ViewModels;
using SimpleMVC.Interfaces.Generic;
using SoftuniStore.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SoftuniStore.Views.Game
{
    public class Allgames : IRenderable<List<AllGamesViewModel>>
    {
        public List<AllGamesViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder adminGames = new StringBuilder();
            StringBuilder pageContent = new StringBuilder();

            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Header));
            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.NavLogged));

            foreach (var allGamesViewModel in this.Model)
            {
                adminGames.AppendLine(allGamesViewModel.ToString());
            }

            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.AdminGames));

            pageContent = pageContent.Replace("##allgames##", adminGames.ToString());

            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Footer));

            return pageContent.ToString();
        }

    }
}
