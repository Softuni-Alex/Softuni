using System;

namespace LaptopShop
{
    class MainClass
    {
        static void Main()
        {

            Laptop example1 = new Laptop("Lenovo", 2999, new Battery("Li-Ion", 1), "Lenovo", "Intel", 4, "Nvidia", "", "Full HD");

            Laptop example2 = new Laptop("HP", 899.99);

            Laptop example3 = new Laptop("Toshiba", 2312.21,new Battery("SomeOne",20), "Toshiba","Intel",4,"Nvidia", "400GB SATA","19 inch");


            Battery battery = new Battery("Li-IOn", 4);
            example2.AddBattery(battery);

            Laptop temp3 = new Laptop("HP 500", 1499.99, new Battery("Li", 2), "HP");

            Console.WriteLine(example1);
            Console.WriteLine();
            Console.WriteLine(example2);
            Console.WriteLine();
            Console.WriteLine(example3);
        }
    }

}