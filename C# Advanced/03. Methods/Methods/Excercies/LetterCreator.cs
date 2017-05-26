using System;

namespace Excercies
{
    class LetterCreator
    {
        static void PrintLetter(string sender, string reciever, DateTime currentDateTime)
        {
            Console.WriteLine("Dear {0},", reciever);
            Console.WriteLine("I hope I find you in good health.");
            Console.WriteLine("I need to inform you that the cheese has run away.");
            Console.WriteLine("Sincerely, {0}", sender);
            Console.WriteLine(currentDateTime);
        }

        static void Main(string[] args)
        {
            string sender = Console.ReadLine();
            string reciever = Console.ReadLine();

            DateTime currentDate = DateTime.Now;

            PrintLetter(sender, reciever, currentDate);
        }
    }
}