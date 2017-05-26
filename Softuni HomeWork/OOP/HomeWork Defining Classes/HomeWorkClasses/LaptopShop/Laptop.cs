using System;

namespace LaptopShop
{
    class Laptop
    {
        private string model;
        private string manufact;
        private string processor;
        private int ram;
        private string video;
        private string hdd;
        private string screen;
        private double price;
        private Battery batt;

        public Laptop(string model, double price)
        {
            this.Model = model;
            this.Price = price;
        }

        public Laptop(string model, double price, Battery battery, string manufact)
            : this(model, price)
        {
            this.batt = battery;
            this.Manufact = manufact;
        }

        public Laptop(string model, double price, Battery battery, string manufact = null, string processor = null,
            int ram = 0, string video = null, string hdd = null, string screen = null)
            : this(model, price, battery, manufact)
        {
            this.Processor = processor;
            this.Ram = ram;
            this.Video = video;
            this.Hdd = hdd;
            this.Screen = screen;
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("Model missing!");
                this.model = value;
            }
        }

        public string Manufact
        {
            get { return this.manufact; }
            set { this.manufact = value; }
        }

        public string Processor
        {
            get { return this.processor; }
            set { this.processor = value; }
        }

        public int Ram
        {
            get { return this.ram; }
            set
            {
                if (value < 0)
                    throw new Exception("Ram must be > 0");
                this.ram = value;
            }
        }

        public string Video
        {
            get { return this.video; }
            set { this.video = value; }
        }

        public string Hdd
        {
            get { return this.hdd; }
            set { this.hdd = value; }
        }

        public string Screen
        {
            get { return this.screen; }
            set { this.screen = value; }
        }

        public double Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                    throw new Exception("The price must be set and > 0");
                this.price = value;
            }
        }

        public void AddBattery(Battery battery)
        {
            this.batt = battery;
        }

        public override string ToString()
        {
            string output = "Model: " + this.model + "\n";
            if (!String.IsNullOrEmpty(this.manufact))
                output += "Manufacturer: " + this.manufact + "\n";
            if (!String.IsNullOrEmpty(this.processor))
                output += "Processor: " + this.processor + "\n";
            if (this.Ram != 0)
                output += "RAM: " + this.ram + " GB" + "\n";
            if (!String.IsNullOrEmpty(this.video))
                output += "Graphics card: " + this.video + "\n";
            if (!String.IsNullOrEmpty(this.hdd))
                output += "HDD: " + this.hdd + "\n";
            if (!String.IsNullOrEmpty(this.screen))
                output += "Screen: " + this.screen + "\n";
            output += batt + "\n";

            output += "Price: " + this.price + " lv.\n";
            return output;
        }

    }
}
