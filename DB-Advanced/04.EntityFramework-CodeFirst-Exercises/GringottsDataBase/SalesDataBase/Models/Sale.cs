namespace SalesDataBase.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Product ProductId { get; set; }

        [Required]
        public Customer CustomerId { get; set; }

        [Required]
        public StoreLocation StoreLocationId { get; set; }

        public DateTime Date { get; set; }
    }
}