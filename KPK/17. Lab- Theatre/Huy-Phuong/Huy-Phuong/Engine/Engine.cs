namespace Huy_Phuong.Core
{
    using Interfaces;
    using Models;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Engine : IEngine
    {
        private IUserInterface userInterface;
        private IPerformanceDatabase database = new PerformanceDatabase();

        public Engine(IPerformanceDatabase database, IUserInterface userInterface)
        {
            this.database = database;
            this.userInterface = userInterface;
        }

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                string input = userInterface.ReadLine();
                if (input == null)
                {
                    isRunning = false;
                    break;
                }
                else if (input != string.Empty)
                {
                    string[] commands = input.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToArray();

                    string command = commands[0];

                    string message;

                    try
                    {
                        switch (command)
                        {
                            case "AddTheatre":
                                message = ExecuteAddTheatreCommand(commands);
                                break;
                            case "PrintAllTheatres":
                                message = ExecutePrintAllTheatresCommand();
                                break;
                            case "AddPerformance":
                                message = ExecuteAddPerformanceCommand(commands);
                                break;
                            case "PrintAllPerformances":
                                message = ExecutePrintAllPerformancesCommand();
                                break;
                            case "PrintPerformances":
                                message = ExecutePrintPerformancesCommand(commands);
                                break;
                            default:
                                throw new InvalidOperationException("Invalid command!");
                        }
                    }
                    catch (Exception ex)
                    {
                        message = "Error: " + ex.Message;
                    }

                    userInterface.WriteLine(message);
                }
            }
        }

        private string ExecutePrintPerformancesCommand(string[] commands)
        {
            string theatre = commands[1];
            string result = string.Empty;

            var performances = this.database.ListPerformances(theatre).Select(
                performance =>
                {
                    string date = performance.Date.ToString("dd.MM.yyyy HH:mm");
                    string performanceName = performance.PerformanceName;
                    return string.Format("({0}, {1})", performanceName, date);
                }).ToList();

            result = performances.Any() ? string.Join(", ", performances) : "No performances";
            return result;
        }

        private string ExecuteAddPerformanceCommand(string[] commands)
        {
            ITheatre theatre = new Theatre(commands[1]);
            string performanceTitle = commands[2];
            DateTime startDateTime = DateTime.ParseExact(commands[3], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse(commands[4]);
            decimal price = decimal.Parse(commands[5], NumberStyles.Float);

            database.AddPerformance(theatre, performanceTitle, startDateTime, duration, price);
            string successMessage = "Performance added";
            return successMessage;
        }

        private string ExecutePrintAllPerformancesCommand()
        {
            var performances = database.ListAllPerformances().ToList();
            string result = string.Empty;

            if (performances.Any())
            {
                var allPerformancesAsString = new StringBuilder();
                for (int i = 0; i < performances.Count; i++)
                {
                    if (i > 0)
                    {
                        allPerformancesAsString.Append(", ");
                    }

                    ITheatre teathre = performances[i].Theatre;
                    string performance = performances[i].PerformanceName;
                    string date = performances[i].Date.ToString("dd.MM.yyyy HH:mm");
                    allPerformancesAsString.AppendFormat("({0}, {1}, {2})", performance, teathre, date);
                }
                result = allPerformancesAsString.ToString();
            }
            else
            {
                result = "No performances";
            }

            return result;
        }

        private string ExecutePrintAllTheatresCommand()
        {
            string result = String.Empty;
            var theatresCount = database.ListTheatres().Count();
            var theatres = this.database.ListTheatres();
            if (theatresCount > 0)
            {
                result = String.Join(", ", theatres);
            }
            else
            {
                result = "No theatres";
            }

            return result;
        }

        private string ExecuteAddTheatreCommand(string[] parameters)
        {
            string theatreName = parameters[1];
            database.AddTheatre(theatreName);
            string successMessage = "Theatre added";
            return successMessage;
        }
    }
}
