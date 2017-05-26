using SimpleMVC.Interfaces;
using System.IO;

namespace Shouter.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../Content/feed.html");
        }
    }
}
