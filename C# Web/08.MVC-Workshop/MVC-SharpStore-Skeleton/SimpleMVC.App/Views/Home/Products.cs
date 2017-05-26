using System.Collections.Generic;
using System.IO;
using System.Text;
using SharpStore.ViewModels;
using SimpleMVC.Interfaces.Generic;

namespace SharpStore.Views.Home
{
    public class Products : IRenderable<IEnumerable<ProductViewModel>>
    {
        public string Render()
        {
            string template = File.ReadAllText("../../content/products.html");
            StringBuilder builder = new StringBuilder();
            foreach (var viewModel in Model)
            {
                builder.Append(viewModel);
            }

            return string.Format(template, builder);
        }

        public IEnumerable<ProductViewModel> Model { get; set; }
    }
}
