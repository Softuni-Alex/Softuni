namespace AirConditioner.Files
{
    using System;
    using Commands;
    using Interfaces;
    using Utilities;

    public class Engine : IEngine
    {
        private readonly Controller.Controller airConditioner;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.airConditioner = new Controller.Controller(this);
            this.reader = reader;
            this.writer = writer;
        }

        public Command Magic { get; set; }

        public void Run()
        {
            // BUG:Possible bottleneck
            string line = string.Empty;
            while (true)
            {
                // string line = this.reader.ReadLine();
                line = this.reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                line = line.Trim();
                try
                {
                    this.Magic = new Command(line);
                    this.airConditioner.Commands();
                }
                catch (InvalidOperationException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        public string Status()
        {
            int reports = AirConditioner.GetReportsCount();
            double airConditioners = AirConditioner.GetAirConditionersCount();

            double percent = reports / airConditioners;
            percent = percent * 100;
            var status = string.Format(Constants.Status, percent);

            return status;
        }

        public void ValidateParametersCount(Command command, int count)
        {
            if (command.Parameters.Length != count)
            {
                throw new InvalidOperationException(Constants.InvalidCommand);
            }
        }
    }
}