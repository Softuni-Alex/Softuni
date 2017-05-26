using System.IO;
using SimpleMVC.Interfaces;

namespace SharpStore.Views.Home
{
    class About : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/about.html");
        }
    }
}
