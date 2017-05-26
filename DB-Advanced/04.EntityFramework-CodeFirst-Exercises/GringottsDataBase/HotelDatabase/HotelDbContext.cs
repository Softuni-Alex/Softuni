namespace HotelDatabase
{
    using Models;
    using System.Data.Entity;

    public class HotelDbContext : DbContext
    {
        public HotelDbContext()
            : base("name=HotelDbContext")
        {
        }

        public IDbSet<BedTypes> BedTypeses { get; set; }

        public IDbSet<Customers> Customerses { get; set; }

        public IDbSet<Employees> Employeeses { get; set; }

        public IDbSet<Occupancies> Occupancieses { get; set; }

        public IDbSet<Payments> Paymentses { get; set; }

        public IDbSet<Rooms> Roomses { get; set; }

        public IDbSet<RoomStatus> RoomStatuses { get; set; }

        public IDbSet<RoomTypes> RoomTypeses { get; set; }
    }
}