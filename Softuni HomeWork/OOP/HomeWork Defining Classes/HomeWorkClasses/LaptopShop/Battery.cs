using System;

namespace LaptopShop
{
    class Battery
    {
        private string batt;
        private int battLife;

        public Battery(string batt = null, int battLife = 0)
        {
            this.Batt = batt;
            this.BattLife = battLife;
        }

        public string Batt
        {
            get { return this.batt; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    this.batt = null;
                this.batt = value;
            }
        }

        public int BattLife
        {
            get { return this.battLife; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("The value must be > 0");
                this.battLife = value;
            }
        }

        public override string ToString()
        {
            return "Battery: " + this.Batt + "  Battery life: " + this.BattLife;
        }
    }
}
