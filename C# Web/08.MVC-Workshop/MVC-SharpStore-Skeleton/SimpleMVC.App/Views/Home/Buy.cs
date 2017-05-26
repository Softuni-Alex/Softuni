using System.IO;
using SharpStore.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace SharpStore.Views.Home
{
    public class Buy : IRenderable<BuyKnifeViewModel>
    {
        public string Render()
        {
            string fileContent = File.ReadAllText("../../content/buy.html");
            return string.Format(fileContent, this.Model);
        }

        public BuyKnifeViewModel Model { get; set; }
    }
}
