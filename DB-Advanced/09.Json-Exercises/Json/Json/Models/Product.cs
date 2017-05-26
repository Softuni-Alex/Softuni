namespace Json.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public Product()
        {
            this.Categories = new List<Categories>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        [InverseProperty("Sold")]
        public virtual User SellerId { get; set; }

        [InverseProperty("Bought")]
        public virtual User BuyerId { get; set; }

        public virtual ICollection<Categories> Categories { get; set; }
    }
}