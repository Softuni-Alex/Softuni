using SimpleMVC.Interfaces;
using SoftuniStore.Utilities;
using System.IO;
using System.Text;

namespace SoftuniStore.Views.Game
{
    public class Add : IRenderable
    {
        public string Render()
        {
            StringBuilder pageContent = new StringBuilder();

            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Header));
            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.NavLogged));
            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.AddGame));
            pageContent.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Footer));

            return pageContent.ToString();
        }
    }
}
