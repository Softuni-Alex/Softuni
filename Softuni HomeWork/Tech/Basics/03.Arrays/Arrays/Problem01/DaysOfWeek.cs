using System;

namespace Problem01
{
    class DaysOfWeek
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };


            if (number >= 1 && number <= 7)
            {
                Console.WriteLine(String.Join(" ", daysOfWeek[number - 1]));
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }


            //            switch (number)
            //            {
            //                case 1:
            //                    Console.WriteLine("Monday");
            //                    break;
            //                case 2:
            //                    Console.WriteLine("Tuesday");
            //                    break;
            //                case 3:
            //                    Console.WriteLine("Wednesday");
            //                    break;
            //                case 4:
            //                    Console.WriteLine("Thursday");
            //                    break;
            //                case 5:
            //                    Console.WriteLine("Friday");
            //                    break;
            //                case 6:
            //                    Console.WriteLine("Saturday");
            //                    break;
            //                case 7:
            //                    Console.WriteLine("Sunday");
            //                    break;
            //                default:
            //                    Console.WriteLine("Invalid day!");
            //                    break;
            //            }
        }
    }
}