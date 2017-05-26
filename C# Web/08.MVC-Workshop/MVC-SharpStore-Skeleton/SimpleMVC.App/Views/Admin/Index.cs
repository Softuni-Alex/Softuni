using System.Collections.Generic;
using System.IO;
using System.Text;
using SharpStore.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace SharpStore.Views.Admin
{
    public class Index : IRenderable<IEnumerable<AdminPaneProductViewModel>>
    {
        public string Render()
        {
            string fileContent = File.ReadAllText("../../content/adminPanel.html");
            StringBuilder builder = new StringBuilder();
            foreach (var product in Model)
            {
                builder.Append(product);
            }

            fileContent = string.Format(fileContent, builder);

            return fileContent;
        }

        public IEnumerable<AdminPaneProductViewModel> Model { get; set; }
    }
}
