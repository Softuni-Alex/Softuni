using DataTransferObjects.ViewModels;
using SimpleMVC.Interfaces.Generic;
using SoftuniStore.Utilities;
using System.IO;
using System.Text;

namespace SoftuniStore.Views.Game
{
    public class Details : IRenderable<GameDetailsViewModel>
    {
        public GameDetailsViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder gameDetail = new StringBuilder();
            StringBuilder pageContent = new StringBuilder();

            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Header));
            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.NavLogged));


            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.GameDetails)
                .Replace("##title#", this.Model.Title)
                .Replace("##video##", this.Model.Trailer)
                .Replace("##description##", this.Model.Description)
                .Replace("##prize##", this.Model.Price.ToString())
                .Replace("##size##", this.Model.Size.ToString())
                .Replace("##date##", this.Model.ReleaseDate.ToString())
                .Replace("##id##", this.Model.Id.ToString()));

            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Footer));

            return pageContent.ToString();
        }

    }
}
