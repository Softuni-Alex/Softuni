using System;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary
{
    public class BookLibrary
    {
        public static void Main(string[] args)
        {
            Dictionary<string, decimal> dictionary = new Dictionary<string, decimal>();
            Book book = new Book();

            int numberOfBooks = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBooks; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                book.Author = tokens[1];
                book.Price = decimal.Parse(tokens[5]);

                if (!dictionary.ContainsKey(book.Author))
                {
                    dictionary.Add(book.Author, book.Price);
                }
                else
                {
                    dictionary[book.Author] += book.Price;
                }
            }

            foreach (var t in dictionary.OrderByDescending(x => x.Value).ThenBy(price => price.Key))
            {
                Console.WriteLine("{0} -> {1:f2}", t.Key, t.Value);
            }

            //            var selected =
            //                library.Books.Select(b => b)
            //                    .Where(nb => nb.RelaseDate > new DateTime(1, 1, 2000));
        }
    }
}