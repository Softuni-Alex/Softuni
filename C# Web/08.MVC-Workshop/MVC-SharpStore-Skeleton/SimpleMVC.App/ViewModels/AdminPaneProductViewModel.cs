namespace SharpStore.ViewModels
{
    public class AdminPaneProductViewModel
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
                              $"<a href=\"/products/edit?knifeId={this.Id}\"><button class=\"btn btn-primary\">Edit</button></a>\r\n" +
                              $"<a href=\"/products/delete?knifeId={this.Id}\"><button class=\"btn btn-primary\">Delete</button></a>\r\n" +
                              "</div>";    
            return template;
        }
    }
}
