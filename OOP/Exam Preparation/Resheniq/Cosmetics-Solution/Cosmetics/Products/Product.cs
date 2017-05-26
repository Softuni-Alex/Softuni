namespace Cosmetics.Products
{
    using System;
    using System.Text;
    using Common;
    using Contracts;

    public abstract class Product : IProduct
    {
        private const int MinProductNameLength = 3;
        private const int MaxProductNameLength = 10;
        private const int MinBrandNameLength = 2;
        private const int MaxBrandNameLength = 10;

        private string name;
        private string brand;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
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

        public string Brand
        {
            get
            {
                return this.brand;
            }

            private set
            {
                // Extracted separate method
                ValidateBrand(value);

                this.brand = value;
            }
        }

        public virtual decimal Price { get; private set; }

        public GenderType Gender { get; private set; }

        public virtual string Print()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("- {0} - {1}:{2}", this.Brand, this.Name, Environment.NewLine);
            sb.AppendFormat("  * Price: ${0}{1}", this.Price, Environment.NewLine);
            sb.AppendFormat("  * For gender: {0}{1}", this.Gender, Environment.NewLine);

            return sb.ToString();
        }

        private static void ValidateName(string value)
        {
            string emptyValueMessage = string.Format(
                GlobalErrorMessages.StringCannotBeNullOrEmpty,
                "Product name");

            Validator.CheckIfStringIsNullOrEmpty(value, emptyValueMessage);

            string invalidValueLengthMessage = string.Format(
                GlobalErrorMessages.InvalidStringLength,
                "Product name",
                MinProductNameLength,
                MaxProductNameLength);

            Validator.CheckIfStringLengthIsValid(
                value,
                MaxProductNameLength,
                MinProductNameLength,
                invalidValueLengthMessage);
        }

        private static void ValidateBrand(string value)
        {
            string emptyValueMessage = string.Format(
                GlobalErrorMessages.StringCannotBeNullOrEmpty,
                "Product brand");

            Validator.CheckIfStringIsNullOrEmpty(value, emptyValueMessage);

            string invalidValueLength = string.Format(
                GlobalErrorMessages.InvalidStringLength,
                "Product brand",
                MinBrandNameLength,
                MaxBrandNameLength);

            Validator.CheckIfStringLengthIsValid(
                value,
                MaxBrandNameLength,
                MinBrandNameLength,
                invalidValueLength);
        }
    }
}
