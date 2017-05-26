namespace GringottsDataBase.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        [Key]
        public string Name { get; set; }

        public string Country { get; set; }
    }
}
