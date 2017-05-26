using BookLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BookLibraryModification
{
    class BookLibraryModification
    {
        public static void Main(string[] args)
        {
            Dictionary<string, DateTime> dictionary = new Dictionary<string, DateTime>();
            Book book = new Book();

            int numberOfBooks = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBooks; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                book.Title = tokens[0];
                book.RelaseDate = DateTime.ParseExact(tokens[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);

                if (!dictionary.ContainsKey(book.Title))
                {
                    dictionary.Add(book.Title, book.RelaseDate);
                }
                else
                {
                    dictionary[book.Title] = book.RelaseDate;
                }
            }

            DateTime currentDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            foreach (var t in dictionary.Where(x => DateTime.Compare(x.Value, currentDate) > 0).OrderBy(date => date.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine("{0} -> {1:dd.MM.yyyy}", t.Key, t.Value);
            }
        }
    }
}