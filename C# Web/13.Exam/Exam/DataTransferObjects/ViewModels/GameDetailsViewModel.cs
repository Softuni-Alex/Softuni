using System;

namespace DataTransferObjects.ViewModels
{
    public class GameDetailsViewModel
    {
        public int Id { get; set; }

        public string Trailer { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public decimal Size { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
