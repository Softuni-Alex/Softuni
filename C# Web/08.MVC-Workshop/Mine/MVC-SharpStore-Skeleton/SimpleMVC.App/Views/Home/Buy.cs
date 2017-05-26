using SimpleMVC.App.MVC.Interfaces;
using System.IO;

namespace SimpleMVC.App.Views.Home
{
    public class Buy : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/buy.html");
        }
    }
}
