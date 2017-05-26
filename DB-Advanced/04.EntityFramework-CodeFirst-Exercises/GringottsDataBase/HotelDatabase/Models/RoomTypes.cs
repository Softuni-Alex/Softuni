namespace HotelDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RoomTypes
    {
        [Required, Key]
        public RoomType RoomType { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }
    }

    public enum RoomType
    {
        Single,
        Double,
        Family
    }
}