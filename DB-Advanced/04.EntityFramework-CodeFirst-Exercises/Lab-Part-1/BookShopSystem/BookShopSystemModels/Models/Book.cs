namespace BookShopSystemModels.Models
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public Book()
        {
            this.RelatedBooks = new List<Book>();
        }

        public int Id { get; set; }

        [MinLength(1), MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Descripton { get; set; }

        public EditionType EditionType { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual DateTime ReleaseDate { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Category> Category { get; set; }

        public ICollection<Book> RelatedBooks { get; set; }
    }
}