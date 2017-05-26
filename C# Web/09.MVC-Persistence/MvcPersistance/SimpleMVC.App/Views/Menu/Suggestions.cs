using System.Text;
using SimpleMVC.App.Utillities;
using SimpleMVC.App.ViewModels;
using SimpleMVC.Interfaces.Generic;

namespace SimpleMVC.App.Views.Menu
{
    public class Suggestions : IRenderable<PizzasViewModel>
    {
        public PizzasViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(WebUtil.RetrieveFileContent(Constants.YourSuggestionsTopFolderLocation));
            htmlContent.AppendLine("<ul>");
            foreach (var suggestion in this.Model.PizzaSuggestions)
            {
                htmlContent.AppendLine("<form method=\"POST\">");
                htmlContent.AppendLine($"<li><a href=\"DetailsPizza.exe?pizzaid={suggestion.Id}\">{suggestion.Title}</a> <input type=\"hidden\" name=\"pizzaId\" value=\"{suggestion.Id}\"/>" +
                                       $"<button type=\"submit\" name=\"PizzaId\" value=\"{suggestion.Id}\">X</button>");
                htmlContent.AppendLine("</form>");
            }
            htmlContent.AppendLine("</ul>");

            htmlContent.AppendLine(WebUtil.RetrieveFileContent(Constants.YourSuggestionsBottomFolderLocation));

            return htmlContent.ToString();
        }
    }
}
