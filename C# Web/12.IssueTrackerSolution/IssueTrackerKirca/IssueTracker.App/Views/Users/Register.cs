namespace IssueTracker.App.Views.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System.IO;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using Utillities;
    using ViewModels;

    public class Register : IRenderable
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(File.ReadAllText(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.NavFolderLocation));

            List<ErrorViewModel> errors = ViewBag.Bag["errors"];
            foreach (ErrorViewModel errorViewModel in errors)
            {
                htmlContent.AppendLine(errorViewModel.ToString());
            }


            htmlContent.AppendLine(File.ReadAllText(Constants.RegisterFolderLocation));

            htmlContent.AppendLine(File.ReadAllText(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }
    }
}
