using System.IO;
using SimpleMVC.Interfaces;

namespace SharpStore.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/home.html");
        }
    }
}
