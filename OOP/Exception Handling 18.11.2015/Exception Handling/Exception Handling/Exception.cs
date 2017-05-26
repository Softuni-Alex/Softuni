using System;

class Exception
{
    static void Main()
    {
        try
        {
            int x = int.Parse("asd");
            Console.WriteLine(x);
        }
        catch (OverflowException of)
        {
            Console.WriteLine("Number too big");
        }
        catch (FormatException fe)
        {
            Console.WriteLine("Invalid integer format");
        }


        finally
        {
            Console.WriteLine("FINNALY");
        }



    }

}
