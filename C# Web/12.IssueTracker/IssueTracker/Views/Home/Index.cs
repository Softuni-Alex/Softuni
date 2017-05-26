using DataTransferObjects.ViewModels;
using SimpleMVC.Interfaces.Generic;
using System.IO;
using System.Text;
using Utility.Utilities;

namespace IssueTracker.Views.Home
{
    public class Index : IRenderable<LoggedInUserViewModel>
    {
        public string Render()
        {
           string menu = null;
            if (!string.IsNullOrEmpty(this.Model.Username))
            {
                string menuLogged = ViewBuilder.DefaultPath + ViewBuilder.MenuLogged;
                var readedFile = File.ReadAllText(menuLogged);
                menu = readedFile.Replace("{0}", this.Model.Username);
            }
            else
            {
                menu = ViewBuilder.Menu;
            }

            StringBuilder renderHtml = new StringBuilder();

            renderHtml.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Header));
            renderHtml.AppendLine(menu);
            renderHtml.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Home));
            renderHtml.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Footer));

            return renderHtml.ToString();
        }

        public LoggedInUserViewModel Model { get; set; }
    }
}
