using System;

namespace StrawBerry
{
    class StrawBerry
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char tireChar = '-';
            int tire = size;
            int tempTire = 0;
            //drujkata
            for (int i = 0; i < size / 2; i++, tempTire += 2)
            {
                Console.WriteLine(new string(tireChar, tempTire) + "\\" + new string(tireChar, tire) + "|" + new string(tireChar, tire) + "/" + new string(tireChar, tempTire));
                tire -= 2;
            }

            //top middle part
            char dotInside = '.';
            int dot = 1;
            tire = size;
            for (int i = 0; i < (size / 2) + 1; i++)
            {
                Console.WriteLine(new string(tireChar, tire) + "#" + new string(dotInside, dot) + "#" + new string(tireChar, tire));
                tire -= 2;
                dot += 4;
            }

            //middle line
            Console.WriteLine("#" + new string(dotInside, size * 2 + 1) + "#");

            //bot middle part
            int tireCharOutside = 1;
            int dots = (size * 2) - 1;
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(new string(tireChar, tireCharOutside) + "#" + new string(dotInside, dots) + "#" + new string(tireChar, tireCharOutside));
                tireCharOutside++;
                dots -= 2;
            }
        }
    }
}