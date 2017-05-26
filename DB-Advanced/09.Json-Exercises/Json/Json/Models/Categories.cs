namespace Json.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Categories
    {
        public Categories()
        {
            this.Products = new List<Product>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}