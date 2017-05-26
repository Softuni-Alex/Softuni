using SimpleMVC.Interfaces;
using SoftuniStore.Utilities;
using System.IO;
using System.Text;

namespace SoftuniStore.Views.Account
{
    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder pageContent = new StringBuilder();

            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Header));
            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.NavNotLogged));
            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Login));
            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Footer));

            return pageContent.ToString();
        }
    }
}
