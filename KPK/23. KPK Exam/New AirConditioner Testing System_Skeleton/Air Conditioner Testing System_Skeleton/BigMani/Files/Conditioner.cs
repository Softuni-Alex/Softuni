namespace AirConditioner.Files
{
    using System;
    using Interfaces;
    using Utilities;

    public class Conditioner : IConditioner
    {
        private readonly int powerUsage;
        private readonly string type;
        private string manufacturer;
        private string model;
        private int energyRating;
        private int volumeCovered;
        private int electricityUsed;

        public Conditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            switch (energyEfficiencyRating)
            {
                case "A":
                    this.energyRating = 10;
                    break;
                case "B":
                    this.energyRating = 12;
                    break;
                case "C":
                    this.energyRating = 15;
                    break;
                case "D":
                    this.energyRating = 20;
                    break;
                case "E":
                    this.energyRating = 90;
                    break;
            }

            this.powerUsage = powerUsage;
            this.type = "stationary";
        }

        public Conditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.VolumeCovered = volumeCoverage;
            this.ElectricityUsed = Convert.ToInt32(electricityUsed);
            this.type = "plane";
        }

        public int EnergyRating
        {
            get { return this.energyRating; }
            set { this.energyRating = value; }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectManufactoryLength, "Manufacturer", Constants.ManufacturerMinLength));
                }

                this.manufacturer = value;
            }
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NonPositive, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }

        public int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Constants.NonPositive, "Electricity Used"));
                }

                this.electricityUsed = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.ModelMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectModelLength, "Model", Constants.ModelMinLength));
                }

                this.model = value;
            }
        }

        public int Test()
        {
            if (this.type == "stationary")
            {
                if (this.powerUsage / 100 <= this.energyRating)
                {
                    return 1;
                }
            }
            else if (this.type == "car")
            {
                double sqrtVolume = Math.Sqrt(this.volumeCovered);
                if (sqrtVolume < 3)
                {
                    return 1;
                }

                return 2;
            }
            else if (this.type == "plane")
            {
                double sqrtVolume = Math.Sqrt(this.volumeCovered);
                if (this.ElectricityUsed / sqrtVolume < Constants.MinPlaneElectricity)
                {
                    return 1;
                }
            }

            return 0;
        }

        public override string ToString()
        {
            string print = "Air Conditioner" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " +
                           this.Manufacturer + "\r\n" + "Model: " + this.Model + "\r\n";

            if (this.type == "stationary")
            {
                string energy = "A";
                switch (this.energyRating)
                {
                    case 12:
                        energy = "B";
                        break;
                    case 15:
                        energy = "C";
                        break;
                    case 20:
                        energy = "D";
                        break;
                    case 90:
                        energy = "E";
                        break;
                }

                print += "Required energy efficiency rating: " + energy + "\r\n" + "Power Usage(KW / h): " +
                         this.powerUsage + "\r\n";
            }
            else if (this.type == "car")
            {
                print += "Volume Covered: " + this.VolumeCovered + "\r\n";
            }
            else
            {
                print += "Volume Covered: " + this.VolumeCovered + "\r\n" + "Electricity Used: " + this.ElectricityUsed + "\r\n";
            }

            print += "====================";

            return print;
        }
    }
}