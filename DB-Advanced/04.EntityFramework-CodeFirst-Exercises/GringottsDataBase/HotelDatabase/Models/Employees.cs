using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    [Table("Employees")]
    public class Employees
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }
    }
}