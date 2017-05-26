using SimpleMVC.App.Utillities;
using SimpleMVC.Interfaces;

namespace SimpleMVC.App.Views.Users
{
    public class Signin  : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent(Constants.SignInFolderLocation);

            return htmlContent;
        }
    }
}
