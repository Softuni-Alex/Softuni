using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Computer
{
    class Computer
    {
        private string name;
        private Component processor;
        private Component graphicsCard;
        private Component motherboard;
        private decimal price;

        public Computer(string name, Component processor, Component graphicsCard, Component motherboard)
        {
            this.Name = name;
            this.Processor = processor;
            this.GraphicsCard = graphicsCard;
            this.Motherboard = motherboard;
            this.Price = this.processor.Price + this.graphicsCard.Price + this.motherboard.Price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Name cannot be empty!");
                }
                this.name = value;
            }
        }

        public Component Processor
        {
            get { return this.processor; }

            set { this.processor = value; }
        }

        public Component GraphicsCard
        {
            get { return this.graphicsCard; }

            set { this.graphicsCard = value; }
        }

        public Component Motherboard
        {
            get { return this.motherboard; }

            set { this.motherboard = value; }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new Exception("Components price cannot be negative number!");
                }
                this.price = value;
            }
        }



        public override string ToString()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg");

            StringBuilder result = new StringBuilder();
            result.AppendLine("Computer name: " + this.name);
            result.AppendLine("Processor: " + this.Processor.Name);
            result.AppendLine("Processor price: " + this.Processor.Price + "lv.");
            result.AppendLine("Graphic card: " + this.GraphicsCard.Name);
            result.AppendLine("Graphic card price: " + this.GraphicsCard.Price + "lv.");
            result.AppendLine("Motherboard: " + this.Motherboard.Name);
            result.AppendLine("Motherboard price: " + this.Motherboard.Price + "lv.");
            result.AppendLine("Total price: " + this.Price + "lv.\n");

            return result.ToString();

        }


    }
}
