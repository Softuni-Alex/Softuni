namespace HotelDatabase
{
    public class HotelApp
    {
        public static void Main()
        {
            var hotel = new HotelDbContext();
            hotel.Database.Initialize(true);
        }
    }
}