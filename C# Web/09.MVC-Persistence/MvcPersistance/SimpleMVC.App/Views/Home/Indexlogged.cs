using SimpleMVC.App.Utillities;
using SimpleMVC.Interfaces;

namespace SimpleMVC.App.Views.Home
{
    public class Indexlogged : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent(Constants.HomeLoggedFolderLocation);

            return htmlContent;
        }
    }
}
