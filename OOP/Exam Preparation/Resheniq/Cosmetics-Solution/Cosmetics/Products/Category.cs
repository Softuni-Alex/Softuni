namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common;
    using Contracts;

    public class Category : ICategory
    {
        private const int MinCategoryNameLength = 2;
        private const int MaxCategoryNameLength = 15;

        private readonly IList<IProduct> products;
        private string name;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                // Extracted separate method
                ValidateName(value);

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            // Added validation for null
            Validator.CheckIfNull(
                cosmetics, 
                string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Cosmetics"));

            this.products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.products.Contains(cosmetics))
            {
                throw new ArgumentException(string.Format(
                    "Product {0} does not exist in category {1}!",
                    cosmetics.Name,
                    this.Name));
            }

            this.products.Remove(cosmetics);
        }

        public string Print()
        {
           StringBuilder sb = new StringBuilder();

            sb.AppendFormat(
                "{0} category - {1} product{2} in total{3}",
                this.Name,
                this.products.Count,
                this.products.Count == 1 ? string.Empty : "s",
                Environment.NewLine);

            var sortedProducts = this.products
                .OrderBy(product => product.Brand)
                .ThenByDescending(product => product.Price);

            foreach (var product in sortedProducts)
            {
                sb.AppendLine(product.Print());
            }

            return sb.ToString().Trim();
        }

        private static void ValidateName(string value)
        {
            string emptyValueMessage = string.Format(
                GlobalErrorMessages.StringCannotBeNullOrEmpty,
                "Category name");

            Validator.CheckIfStringIsNullOrEmpty(value, emptyValueMessage);

            string invalidValueLengthMessage = string.Format(
                GlobalErrorMessages.InvalidStringLength,
                "Category name",
                MinCategoryNameLength,
                MaxCategoryNameLength);

            Validator.CheckIfStringLengthIsValid(
                value,
                MaxCategoryNameLength,
                MinCategoryNameLength,
                invalidValueLengthMessage);
        }
    }
}
