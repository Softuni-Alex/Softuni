namespace SalesDataBase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        public Customer()
        {
            this.SalesOfCustomer = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MaxLength(50)]
        public string CreditCardNumber { get; set; }

        public ICollection<Sale> SalesOfCustomer { get; set; }
    }
}