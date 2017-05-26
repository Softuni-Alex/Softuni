namespace AirConditioner.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Files;
    using Interfaces;
    using Utilities;

    public class Controller : IController
    {
        private readonly Engine engine;

        public Controller(Engine engine)
        {
            this.engine = engine;
        }

        public Engine Engine { get; set; }

        public void Commands()
        {
            var command = this.engine.Magic;
            try
            {
                switch (command.Name)
                {
                    case "RegisterStationaryAirConditioner":
                        this.engine.ValidateParametersCount(command, 4);
                        this.RegisterStationaryAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            command.Parameters[2],
                            int.Parse(command.Parameters[3]));
                        break;
                    case "RegisterCarAirConditioner":
                        this.engine.ValidateParametersCount(command, 3);
                        this.RegisterCarAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]));
                        break;
                    case "RegisterPlaneAirConditioner":
                        this.engine.ValidateParametersCount(command, 4);
                        this.RegisterPlaneAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]),
                            command.Parameters[3]);
                        break;
                    case "TestAirConditioner":
                        this.engine.ValidateParametersCount(command, 2);
                        this.TestAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1]);
                        break;
                    case "FindAirConditioner":
                        this.engine.ValidateParametersCount(command, 2);
                        this.FindAirConditioner(
                            command.Parameters[1],
                            command.Parameters[0]);
                        break;
                    case "FindReport":
                        this.engine.ValidateParametersCount(command, 2);
                        this.FindReport(
                            command.Parameters[0],
                            command.Parameters[1]);
                        break;
                    case "Status":
                        this.engine.ValidateParametersCount(command, 0);
                        this.engine.Status();
                        break;
                    default:
                        throw new IndexOutOfRangeException(Constants.InvalidCommand);
                }
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException(Constants.InvalidCommand, ex.InnerException);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException(Constants.InvalidCommand, ex.InnerException);
            }
        }

        public string RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            Conditioner conditioner = new Conditioner(manufacturer, model, energyEfficiencyRating, powerUsage);
            AirConditioner.AirConditioners.Add(conditioner);
            throw new InvalidOperationException(string.Format(Constants.Register, conditioner.Model, conditioner.Manufacturer));
        }

        public string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            Conditioner conditioner = new Conditioner(manufacturer, model, volumeCoverage, null);
            AirConditioner.AirConditioners.Add(conditioner);
            throw new InvalidOperationException(
                string.Format(Constants.Register, conditioner.Model, conditioner.Manufacturer));
        }

        public string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            Conditioner conditioner = new Conditioner(manufacturer, model, volumeCoverage, electricityUsed);
            AirConditioner.AirConditioners.Add(conditioner);
            throw new InvalidOperationException(
                string.Format(Constants.Register, conditioner.Model, conditioner.Manufacturer));
        }

        public string TestAirConditioner(string manufacturer, string model)
        {
            Conditioner conditioner = AirConditioner.GetAirConditioner(manufacturer, model);
            conditioner.EnergyRating += 5;
            var mark = conditioner.Test();
            AirConditioner.Reports.Add(new Report(conditioner.Manufacturer, conditioner.Model, mark));
            throw new InvalidOperationException(string.Format(Constants.Test, model, manufacturer));
        }

        public string FindAirConditioner(string manufacturer, string model)
        {
            Conditioner conditioner = AirConditioner.GetAirConditioner(manufacturer, model);
            throw new InvalidOperationException(conditioner.ToString());
        }

        public string FindReport(string manufacturer, string model)
        {
            Report report = AirConditioner.GetReport(manufacturer, model);
            throw new InvalidOperationException(report.ToString());
        }

        public string FindAllReportsByManufacturer(string manufacturer)
        {
            IList<Report> reports = AirConditioner.GetReportsByManufacturer(manufacturer);
            if (reports.Count == 0)
            {
                return Constants.NoReports;
            }

            reports = reports.OrderBy(x => x.Mark).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine($"Reports from {manufacturer}:");
            reportsPrint.Append(string.Join(Environment.NewLine, reports));
            return reportsPrint.ToString();
        }
    }
}