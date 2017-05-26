using DataTransferObjects.ViewModels;
using SimpleMVC.Interfaces.Generic;
using System.IO;
using System.Text;
using Utility.Utilities;

namespace IssueTracker.Views.Issue
{
    public class All : IRenderable<IssueViewModel>
    {
        public IssueViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder renderHtml = new StringBuilder();

            renderHtml.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Header));

            renderHtml.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.MenuLogged));

            renderHtml.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Issues));

            renderHtml.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Footer));

            return renderHtml.ToString();
        }

    }
}
