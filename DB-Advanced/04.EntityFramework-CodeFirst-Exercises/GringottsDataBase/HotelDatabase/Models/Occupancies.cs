using System;
using System.ComponentModel.DataAnnotations;

namespace HotelDatabase.Models
{
    public class Occupancies
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateOccupied { get; set; }

        public string AccountNumber { get; set; }

        public int RoomNumber { get; set; }

        public decimal RateApplied { get; set; }

        public decimal PhoneCharge { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }
    }
}