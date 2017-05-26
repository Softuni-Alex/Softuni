using System;

namespace VowelorDigit
{
    class VowelorDigit
    {
        static void Main(string[] args)
        {
            string letter = Console.ReadLine();

            switch (letter)
            {
                case "a":
                case "e":
                case "i":
                case "u":
                case "o":
                    Console.WriteLine("vowel");
                    break;
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    Console.WriteLine("digit");
                    break;
                default:
                    Console.WriteLine("other");
                    break;
            }
        }
    }
}