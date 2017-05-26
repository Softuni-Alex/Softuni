using System;

namespace ShowData
{
    public class AppAds
    {
        public static void Main()
        {
            var context = new AdsContext();

            var ads = context.Ads.Include("SELECT * FROM Ads");

            foreach (var ad in ads)
            {
                Console.WriteLine($"{ad.Text} ");
            }
        }
    }
}