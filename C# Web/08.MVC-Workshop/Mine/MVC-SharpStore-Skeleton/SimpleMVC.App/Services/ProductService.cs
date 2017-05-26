using SimpleMVC.App.BindingModels;
using SimpleMVC.App.Data;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMVC.App.Services
{
    public class ProductService
    {
        private readonly SharpStoreContext context;

        public ProductService()
        {
            this.context = new SharpStoreContext();
        }

        public IEnumerable<ProductViewModel> GetProducts(string keyword)
        {
            var knives = this.context.Knives.Where(k => k.Name.Contains(keyword)).ToArray();
            List<ProductViewModel> viewModel = new List<ProductViewModel>();
            foreach (var knife in knives)
            {
                viewModel.Add(new ProductViewModel()
                {
                    Id = knife.Id,
                    Keyword = knife.Name,
                    Price = knife.Price,
                    Url = knife.ImageUrl
                });
            }

            return viewModel;
        }
    }
}
