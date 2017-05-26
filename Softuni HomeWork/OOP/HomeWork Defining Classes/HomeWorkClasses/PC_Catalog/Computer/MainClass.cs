using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Linq;

namespace Computer
{
    class Computers
    {
        class PC_Catalog
        {
            static void Main()
            {
                Console.OutputEncoding = Encoding.Unicode;

                Computer computer1 = new Computer(
                    name: "Razor",
                    processor: new Component("i7-3770k", 500m),
                    graphicsCard: new Component("Nvidia 810M", 150m),
                    motherboard: new Component("ASRock 990FX Extreme3", 300.99m));

                Computer computer2 = new Computer(
                    name: "HP",
                    processor: new Component("Core i3-3220 (3.30 GHz, 3 MB cache, 2 cores)", 300m),
                    graphicsCard: new Component("Intel HD Graphics", 200m),
                    motherboard: new Component("ASUS Atheros", 220m));

                Computer computer3 = new Computer(
                    name: "ASUS",
                    processor: new Component("Core i5-4130", 420m),
                    graphicsCard: new Component("NVIDIA GeForce GTX 970", 1200m),
                    motherboard: new Component("ASUS MAXIMUS VII HERO", 580m));

                List<Computer> computers = new List<Computer>() { computer1, computer2, computer3 };

                var output = from elements in computers
                             orderby elements.Price ascending
                             select elements;

                foreach (var computer in output)
                {
                    Console.WriteLine(computer);
                }

               
            }
        }
    }
}