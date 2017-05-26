using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.App.Views.Issues
{
    using System.IO;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;

    public class New : IRenderable
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(File.ReadAllText(Constants.HeaderFolderLocation));

            htmlContent.AppendLine(File.ReadAllText(Constants.NavLoggedFolderLocation));
            htmlContent = htmlContent.Replace("##username##", ViewBag.Bag["username"]);


            htmlContent.AppendLine(File.ReadAllText(Constants.IssuesNewFolderLocation));

            htmlContent.AppendLine(File.ReadAllText(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }
    }
}
