namespace DataTransferObjects.ViewModels
{
    public class AllGamesViewModel
    {
        public int Id { get; set; }

        public decimal Size { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        //        public string Trailer { get; set; }
        //
        //        public string ImageUrl { get; set; }
        //
        //        public string Description { get; set; }

        public override string ToString()
        {
            string template = "<tr>" +
                $" <td>{this.Title}</td>\n" +
                              $"<td>{this.Size}</td>\n" +
                              $"<td>{this.Price} \\&euro;</td>\n" +
                              "<td>\n" +
                        $"<a href=\"/game/edit?id={this.Id}\" class=\"btn btn-warning btn-sm\">Edit</a>\n" +
                        $"<a href=\"/game/delete?id={this.Id}\" class=\"btn btn-danger btn-sm\">Delete</a>\n</td>" +
                        "</tr>";

            return template;
        }
    }
}
