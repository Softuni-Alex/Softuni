using SimpleMVC.App.Utillities;
using SimpleMVC.Interfaces;

namespace SimpleMVC.App.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent(Constants.HomeEnFolderLocation);

            return htmlContent;
        }
    }
}
