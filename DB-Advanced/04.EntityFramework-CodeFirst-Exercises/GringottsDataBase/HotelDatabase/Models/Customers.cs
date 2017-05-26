using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDatabase.Models
{
    [Table("Customers")]
    public class Customers
    {
        [Key]
        public int AccountNumber { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string EmergencyName { get; set; }

        [MaxLength(15)]
        public string EmergencyNumber { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }
    }
}