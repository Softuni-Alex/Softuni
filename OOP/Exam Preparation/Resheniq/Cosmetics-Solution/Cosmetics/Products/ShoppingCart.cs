namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private readonly IList<IProduct> products;

        public ShoppingCart()
        {
            this.products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            // Added validation for null
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product"));
            
            this.products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            // Added validation for null
            Validator.CheckIfNull(product, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Product"));

            this.products.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.products.Contains(product);
        }

        public decimal TotalPrice()
        {
            return this.products.Sum(product => product.Price);
        }
    }
}
