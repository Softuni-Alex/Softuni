namespace AirConditioner.Files
{
    using System.Collections.Generic;
    using System.Linq;

    public class AirConditioner
    {
        static AirConditioner()
        {
            AirConditioners = new List<Conditioner>();
            Reports = new List<Report>();
        }

        public static List<Conditioner> AirConditioners { get; set; }

        public static List<Report> Reports { get; set; }

        public static void AddAirConditioner(Conditioner conditioner)
        {
            AirConditioners.Add(conditioner);
        }

        public static void RemoveAirConditioner(Conditioner conditioner)
        {
            AirConditioners.Remove(conditioner);
        }

        public static Conditioner GetAirConditioner(string manufacturer, string model)
        {
            return AirConditioners.First(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public static int GetAirConditionersCount()
        {
            return AirConditioners.Count;
        }

        public static void AddReport(Report report)
        {
            Reports.Add(report);
        }

        public static void RemoveReport(Report report)
        {
            Reports.Remove(report);
        }

        public static Report GetReport(string manufacturer, string model)
        {
            return Reports.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public static int GetReportsCount()
        {
            return Reports.Count;
        }

        public static List<Report> GetReportsByManufacturer(string manufacturer)
        {
            return Reports.Where(x => x.Manufacturer == manufacturer).ToList();
        }
    }
}