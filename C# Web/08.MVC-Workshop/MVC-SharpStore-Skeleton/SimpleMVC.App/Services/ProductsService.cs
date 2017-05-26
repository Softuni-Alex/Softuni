using System.Collections.Generic;
using System.Linq;
using SharpStore.BindingModels;
using SharpStore.Data;
using SharpStore.Models;
using SharpStore.ViewModels;

namespace SharpStore.Services
{
    public class ProductsService : Service
    {
        public ProductsService(SharpStoreContext context) : base(context) { }

        public IEnumerable<ProductViewModel> GetProducts(string productName)
        {
            var knives = this.context.Knives.Where(knive => knive.Name.Contains(productName)).ToArray();
            List<ProductViewModel> viewModels = new List<ProductViewModel>();
            foreach (Knive knife in knives)
            {
                viewModels.Add(new ProductViewModel()
                {
                    Id = knife.Id,
                    Price = knife.Price,
                    Name = knife.Name,
                    Url = knife.ImageUrl
                });
            }

            return viewModels;
        }

        public IEnumerable<AdminPaneProductViewModel> GetAdminPanelProducts()
        {
            var knives = this.context.Knives.ToArray();
            List<AdminPaneProductViewModel> viewModels = new List<AdminPaneProductViewModel>();
            foreach (Knive knife in knives)
            {
                viewModels.Add(new AdminPaneProductViewModel()
                {
                    Id = knife.Id,
                    Price = knife.Price,
                    Name = knife.Name,
                    Url = knife.ImageUrl
                });
            }

            return viewModels;
        }

        public EditProductViewModel GetEditProductViewModel(int id)
        {
            Knive knife = this.context.Knives.Find(id);
            EditProductViewModel viewModel = new EditProductViewModel()
            {
                Id = knife.Id,
                Price = knife.Price,
                ImageUrl = knife.ImageUrl,
                Name = knife.Name
            };

            return viewModel;
        }

        public void AddProduct(AddProductBindingModel bindingModel)
        {
            Knive knive = new Knive()
            {
                ImageUrl = bindingModel.ImageUrl,
                Name = bindingModel.Name,
                Price = bindingModel.Price
            };

            this.context.Knives.Add(knive);
            this.context.SaveChanges();
        }

        public void UpdateProduct(EditProductBindingModel bind)
        {
            Knive knive = this.context.Knives.Find(bind.Id);
            knive.Price = bind.Price;
            knive.ImageUrl = bind.ImageUrl;
            knive.Name = bind.Name;

            this.context.SaveChanges();
        }

        public void DeleteKnife(int knifeId)
        {
            Knive knife = this.context.Knives.Find(knifeId);
            this.context.Knives.Remove(knife);
            this.context.SaveChanges();
        }
    }
}
