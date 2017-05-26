using System;
using System.Numerics;

namespace CenturiesToNanoseconds
{
    class CenturiesToNanoseconds
    {
        static void Main()
        {
            int centuries = int.Parse(Console.ReadLine());

            int years = (centuries * 100);
            int days = (int)(years * 365.2422);
            ulong hours = (ulong)(days * 24);
            BigInteger minutes = hours * 60;
            BigInteger seconds = minutes * 60;
            BigInteger miliseconds = seconds * 1000;
            BigInteger microseconds = miliseconds * 1000;
            BigInteger nanoseconds = microseconds * 1000;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {miliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");

        }
    }
}