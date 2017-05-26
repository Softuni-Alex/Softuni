namespace SharpStore.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Url { get; set; }

        public override string ToString()
        {
            string template = "<div class=\"col-sm-4\">\r\n " +
                              "<img class=\"img-thumbnail\" " +
                              $"src=\"{this.Url}\" alt =\"\">\r\n" +
                              $"<h3>{this.Name}</h3>\r\n" +
                              $"<p>${this.Price:f2}</p>\r\n" +
                              $"<a href=\"/home/buy?knifeId={this.Id}\"><button class=\"btn btn-primary\">Buy NOW!</button></a>\r\n" +
                              "</div>";

            return template;
        }
    }
}