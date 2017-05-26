using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.App.Views.Users
{
    using System.IO;
    using SimpleMVC.Interfaces;
    using Utillities;
    using ViewModels;

    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(File.ReadAllText(Constants.HeaderFolderLocation));
            htmlContent.AppendLine(File.ReadAllText(Constants.NavFolderLocation));

            htmlContent.AppendLine(File.ReadAllText(Constants.LoginFolderLocation));

            htmlContent.AppendLine(File.ReadAllText(Constants.FooterFolderLocation));

            return htmlContent.ToString();
        }
    }
}
