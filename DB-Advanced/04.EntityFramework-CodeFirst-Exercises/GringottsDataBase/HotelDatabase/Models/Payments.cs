namespace HotelDatabase.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Payments")]
    public class Payments
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [MaxLength(30), Required]
        public string AccountNumber { get; set; }

        public DateTime FirstDateOccupied { get; set; }

        public DateTime LastDateOccupied { get; set; }

        public long TotalDays { get; set; }

        public decimal AmountCharged { get; set; }

        public decimal TaxRate { get; set; }

        [Required]
        public decimal PaymentTotal { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }
    }
}