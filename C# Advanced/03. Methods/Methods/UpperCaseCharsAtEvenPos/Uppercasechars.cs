using System;

namespace UpperCaseCharsAtEvenPos
{
    class Uppercasechars
    {
        static void Main(string[] args)
        {
            UppercaseCharsAtEvenPosition("Byrzo che sireneto izbega!");
        }

        static void UppercaseCharsAtEvenPosition(string message)
        {
            char[] array = message.ToCharArray();

            string newName = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    newName += array[i].ToString().ToUpper();
                }
                else
                {
                    newName += array[i].ToString().ToLower();
                }
            }
            Console.WriteLine(newName);
        }
    }
}