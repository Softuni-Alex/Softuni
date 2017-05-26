using DataTransferObjects.ViewModels;
using SimpleMVC.Interfaces.Generic;
using SoftuniStore.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SoftuniStore.Views.Game
{
    public class Index : IRenderable<List<GameViewModel>>
    {
        public List<GameViewModel> Model { get; set; }

        public string Render()
        {
            string menu = null;
            StringBuilder pageContent = new StringBuilder();
            StringBuilder gameContent = new StringBuilder();

            foreach (var gameViewModel in this.Model)
            {
                int i = 0;
                if (gameViewModel.IsAuthenticated)
                {
                    string menuLogged = ViewBuilder.DefaultPath + ViewBuilder.NavLogged;

                    menu = File.ReadAllText(menuLogged);
                }
                else
                {
                    string menuNotLogged = ViewBuilder.DefaultPath + ViewBuilder.NavNotLogged;

                    menu = File.ReadAllText(menuNotLogged);
                }

                gameContent.AppendLine(gameViewModel.ToString());
            }

            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Header));

            pageContent.AppendLine(menu);

            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Home));

            pageContent = pageContent.Replace("##games##", gameContent.ToString());
            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Footer));

            return pageContent.ToString();
        }

    }
}
