using SimpleMVC.App.Utillities;
using SimpleMVC.Interfaces;

namespace SimpleMVC.App.Views.Menu
{
    public class Add : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent(Constants.AddPizzaFolderLocation);

            return htmlContent;
        }
    }
}
