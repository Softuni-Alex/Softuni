using System.IO;
using SharpStore.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace SharpStore.Views.Products
{
    public class Edit : IRenderable<EditProductViewModel>
    {
        public string Render()
        {
            string fileContent = File.ReadAllText("../../content/editProduct.html");
            return string.Format(fileContent, Model);
        }

        public EditProductViewModel Model { get; set; }
    }
}
