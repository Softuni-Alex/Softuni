using System.IO;
using SimpleMVC.Interfaces;

namespace SharpStore.Views.Login
{
    public class Login : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/login.html");
        }
    }
}
