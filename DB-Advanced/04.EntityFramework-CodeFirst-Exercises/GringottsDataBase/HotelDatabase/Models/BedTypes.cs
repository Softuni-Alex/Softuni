namespace HotelDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BedTypes
    {
        [Required, Key]
        public BedType BedType { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }
    }

    public enum BedType
    {
        Single,
        Double
    }
}