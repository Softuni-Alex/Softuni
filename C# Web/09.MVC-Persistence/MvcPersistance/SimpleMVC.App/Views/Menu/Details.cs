using System.Text;
using SimpleMVC.App.ViewModels;
using SimpleMVC.Interfaces.Generic;

namespace SimpleMVC.App.Views.Menu
{
    public class Details : IRenderable<DetailsViewModel>
    {

        public DetailsViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine("<!doctype html><html lang=\"en\"><head><meta charset=\"UTF-8\" /><title>PizzaMore - Details</title><meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" /><link rel=\"stylesheet\" href=\"/pm/bootstrap/css/bootstrap.min.css\" /><link rel=\"stylesheet\" href=\"/pm/css/signin.css\" /></head><body><div class=\"container\">");
            htmlContent.AppendLine("<div class=\"jumbotron\">");
            htmlContent.AppendLine("<a class=\"btn btn-danger\" href=\"Menu.exe\">All Suggestions</a>");
            htmlContent.AppendLine($"<h3>{this.Model.Title}</h3>");
            htmlContent.AppendLine($"<img src=\"{this.Model.ImageUrl}\" width=\"300px\"/>");
            htmlContent.AppendLine($"<p>{this.Model.Recipe}</p>");
            htmlContent.AppendLine($"<p>Up: {this.Model.UpVotes}</p>");
            htmlContent.AppendLine($"<p>Down: {this.Model.DownVotes}</p>");
            htmlContent.AppendLine("</div>");

            return htmlContent.ToString();

        }
    }
}
