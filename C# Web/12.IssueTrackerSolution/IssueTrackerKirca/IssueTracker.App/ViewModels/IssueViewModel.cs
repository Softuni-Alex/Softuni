namespace IssueTracker.App.ViewModels
{
    using System;
    using System.Text;

    public class IssueViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsEditable { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"\t<tr><td>{this.Id}</td><td>{this.Name}</td><td>{this.Status}</td><td>{this.Priority}</td><td>{this.CreatedOn}</td>" +
                   $"<td>{this.Author}</td>");
            if (this.IsEditable)
            {
                result.AppendLine($"<td><a href=\"/issues/edit?id={this.Id}\" class=\"btn mini btn-primary\">Edit</a></td>" +
                 $"<td><a href=\"/issues/delete?id={this.Id}\" class=\"confirm-delete mini btn btn-danger\">Delete</a></td>");
            }
            else
            {
                result.AppendLine("<td>  </td><td>  </td>");
            }

            result.AppendLine("</tr>");
            return result.ToString();
        }
    }
}
