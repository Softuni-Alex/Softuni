using System;

public class Factorial
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine(FindFactoriel(number));
    }

    private static int FindFactoriel(int number)
    {
        if (number < 2)
        {
            return 1;
        }

        return number * FindFactoriel(number - 1);
    }
}
