namespace PetShopDB.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum Materials
    {
        Wood,
        Iron,
        Leather
    }

    public class Cage
    {
        [Key]
        public string Name { get; set; }

        public string Notes { get; set; }

        public Materials Material { get; set; }
    }
}