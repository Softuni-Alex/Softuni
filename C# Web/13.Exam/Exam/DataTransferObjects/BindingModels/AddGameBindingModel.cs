using System;

namespace DataTransferObjects.BindingModels
{
    public class AddGameBindingModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Thumbnail { get; set; }

        public decimal Price { get; set; }

        public decimal Size { get; set; }

        public string VideoUrl { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
