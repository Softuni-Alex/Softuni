using System;
using System.Collections.Generic;

namespace Common_TypeSystem
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Payment newTV = new Payment("Toshiba new", 123423.23m);
            Payment phone = new Payment("Nokia 110", 111);
            Payment chair = new Payment("Chair", 54);
            Payment plate = new Payment("Plate", 20);
            Payment ancientCherokeeSkull = new Payment("Ancient Cherokee skull", 3000);
            Payment lighbulb = new Payment("Lightbulb", 4.99m);
            Payment scrabble = new Payment("Scrabble", 39.99m);

            List<Payment> randomPayments = new List<Payment>();
            randomPayments.Add(newTV);
            randomPayments.Add(phone);
            randomPayments.Add(ancientCherokeeSkull);

            List<Payment> notSoRandomPayments = new List<Payment>();
            notSoRandomPayments.Add(chair);
            notSoRandomPayments.Add(plate);
            notSoRandomPayments.Add(lighbulb);
            notSoRandomPayments.Add(scrabble);

            Customer Alex = new Customer("Alex", "Omg", "Okay", "961011", " shits 12355"
                , "+555 334 534", "AlexOMG@hotmail.com", randomPayments, CustomerType.Regular);

            Customer Alex2 = new Customer("Alex", "Omg", "Okay", "961011", "gek 52135"
                , "+555 334 532", "AlexOMG@hotmail.com", randomPayments, CustomerType.Regular);


            Customer Alex3 = new Customer("John", "Sick", "Uter", "3245655", "Omg street 212316"
                , "+555 132 784", "JohnOMG@gmail.com", notSoRandomPayments, CustomerType.Diamond);

            Console.WriteLine(Customer.Equals(Alex, Alex2));
            Console.WriteLine(Alex.CompareTo(Alex2));
            Console.WriteLine(Alex3);


            Customer Martin2 = (Customer)Alex3.Clone();
            notSoRandomPayments.Remove(chair);
            Martin2.Email = "first Email hasn't changed :)";
            Console.WriteLine(Alex3);
        }
    }
}
