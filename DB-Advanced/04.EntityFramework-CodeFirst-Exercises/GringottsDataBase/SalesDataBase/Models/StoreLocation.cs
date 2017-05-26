namespace SalesDataBase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class StoreLocation
    {
        public StoreLocation()
        {
            this.SalesInStore = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string LocationName { get; set; }

        public ICollection<Sale> SalesInStore { get; set; }
    }
}