using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    [Table("RoomStatus")]
    public class RoomStatus
    {
        [Required, Key]
        public Status Status { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }
    }

    public enum Status
    {
        Taken,
        Free
    }
}