using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.App.Views.Home
{
    using System.IO;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;

    public class Index : IRenderable<bool>
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(File.ReadAllText(Constants.HeaderFolderLocation));
            if (this.Model)
            {
                htmlContent.AppendLine(File.ReadAllText(Constants.NavLoggedFolderLocation));
                htmlContent = htmlContent.Replace("##username##", ViewBag.Bag["username"]);
            }
            else
            {
                htmlContent.AppendLine(File.ReadAllText(Constants.NavFolderLocation));
            }

            htmlContent.AppendLine(File.ReadAllText(Constants.HomeFolderLocation));

            htmlContent.AppendLine(File.ReadAllText(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }

        public bool Model { get; set; }
    }
}
