using System.IO;
using SimpleMVC.Interfaces;

namespace SharpStore.Views.Home
{
    public class Contacts : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/contacts.html");
        }
    }
}
