using SimpleMVC.App.Utillities;
using SimpleMVC.Interfaces;

namespace SimpleMVC.App.Views.Users
{
    public class Signup :IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent(Constants.SignUpFolderLocation);

            return htmlContent;
        }
    }
}
