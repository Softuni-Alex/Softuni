namespace HospitalDataBase
{
    public class HotelApp
    {
        public static void Main()
        {
            var hospital = new HospitalDbContext();
            hospital.Database.Initialize(true);
        }
    }
}