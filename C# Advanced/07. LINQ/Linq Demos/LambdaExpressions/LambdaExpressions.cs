using System;
using System.Collections.Generic;

class LambdaExpressions
{
    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    static void Main()
    {
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        List<int> evenNumbers = numbers.FindAll(x => x % 2 == 0);

        foreach (var evenNumber in evenNumbers)
        {
            Console.WriteLine(evenNumber);
        }

        numbers.RemoveAll(x => x < 3);

        foreach (var allNumbersLeft in numbers)
        {
            Console.WriteLine(allNumbersLeft);
        }

        Console.WriteLine();

        //var pets = new Pet[]
        //{
        // new Pet { Name="Sharo", Age=8 },
        // new Pet { Name="Rex", Age=4 },
        // new Pet { Name="Strela", Age=1 },
        // new Pet { Name="Bora", Age=3 }
        //};
        //var sortedPets = pets.OrderBy(pet => pet.Age);
        //foreach (Pet pet in sortedPets)
        //{
        //    Console.WriteLine("{0} -> {1}",
        //      pet.Name, pet.Age);
        //}

        //Console.WriteLine();

        numbers = new List<int>()
        { 20, 1, 4, 8, 9, 44 };

        // Process each argument with code statements
        evenNumbers = numbers.FindAll((i) =>
            {
                Console.WriteLine("value of i is: {0}", i);
                return i % 2 == 0;
            });

        Console.WriteLine("Here are your even numbers:");
        foreach (int even in evenNumbers)
            Console.Write("{0} ", even);

        Console.WriteLine();
        Console.WriteLine();

        Func<bool> boolFunc = () => true;
        Func<int, bool> boolintFunc = x => x < 10;

        if (boolFunc() && boolintFunc(5))
        {
            Console.WriteLine("5 < 10");
        }
        //    List<string> towns = new List<string>()
        //{
        //  "Sofia", "Plovdiv", "Varna", "Sopot", "Silistra"
        //};

        //    List<string> townsWithV = towns.FindAll((town) => town.StartsWith("p".ToUpper()));

        //    foreach (var asd in townsWithV)
        //    {
        //        Console.WriteLine(asd);
        //    }

        // A short form of the above (with lambda expression)
        //List<string> townsWithS = towns.FindAll((town) => town.StartsWith("S"));

        //  foreach (string town in townsWithS)
        //  {
        //      Console.WriteLine(town);
        //  }
    }
}
