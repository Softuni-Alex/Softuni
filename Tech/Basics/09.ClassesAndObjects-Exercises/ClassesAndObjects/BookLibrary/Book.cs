using System;

namespace BookLibrary
{
    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public DateTime RelaseDate { get; set; }

        public long ISBN { get; set; }

        public decimal Price { get; set; }
    }
}