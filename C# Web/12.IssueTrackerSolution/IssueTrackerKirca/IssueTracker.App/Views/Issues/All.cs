namespace IssueTracker.App.Views.Issues
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;
    public class All : IRenderable<HashSet<IssueViewModel>>
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(File.ReadAllText(Constants.HeaderFolderLocation));

            htmlContent.AppendLine(File.ReadAllText(Constants.NavLoggedFolderLocation));
            htmlContent = htmlContent.Replace("##username##", ViewBag.Bag["username"]);


            htmlContent.AppendLine(File.ReadAllText(Constants.IssuesAllFolderLocation));
            StringBuilder issuesHtml = new StringBuilder();
            foreach (IssueViewModel issueViewModel in this.Model)
            {
                issuesHtml.AppendLine(issueViewModel.ToString());
            }

            htmlContent = htmlContent.Replace("##issues##", issuesHtml.ToString());
            htmlContent.AppendLine(File.ReadAllText(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }

        public HashSet<IssueViewModel> Model { get; set; }
    }
}
