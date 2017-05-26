using SimpleMVC.Interfaces;
using System.IO;
using System.Text;
using Utility.Utilities;

namespace IssueTracker.Views.User
{
    public class MenuLogged : IRenderable
    {
        public string Render()
        {
            StringBuilder renderHtml = new StringBuilder();

            renderHtml.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Header));
            renderHtml.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.MenuLogged));
            renderHtml.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Home));
            renderHtml.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Footer));

            return renderHtml.ToString();
        }
    }
}
