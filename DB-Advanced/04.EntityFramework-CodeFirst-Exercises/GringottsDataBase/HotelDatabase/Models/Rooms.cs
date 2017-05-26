namespace HotelDatabase.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Rooms")]
    public class Rooms
    {
        [Key]
        public int RoomNumber { get; set; }

        [Required]
        public RoomType RoomType { get; set; }

        [Required]
        public BedType BedType { get; set; }

        public double Rate { get; set; }

        [Required]
        public Status Status { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }
    }
}