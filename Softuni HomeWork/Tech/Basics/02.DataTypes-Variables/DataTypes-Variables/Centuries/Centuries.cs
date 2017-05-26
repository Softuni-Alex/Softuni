﻿using System;

namespace Centuries
{
    class Centuries
    {
        static void Main(string[] args)
        {
            byte centuries = byte.Parse(Console.ReadLine());
            short years = (short)(centuries * 100);
            int days = (int)(years * 365.2422);
            long hours = (long)(days * 24);
            ulong minutes = (ulong)(hours * 60);

            Console.WriteLine(centuries + " centuries = " + years + " years = " + days + " days = " + hours + " hours = " + minutes + " minutes");
        }
    }
}