using System;

namespace DataTransferObjects.ViewModels
{
    public class IssueViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public DateTime Date { get; set; }

        public string Author { get; set; }

        public bool IsEditable { get; set; }

        public override string ToString()
        {
            string template = string.Empty;

            if (this.IsEditable)
            {
                template =
                    "<td>{id}</td>" +
                    "\r\n<td>{name}</td>" +
                    "\r\n<td>{status}</td>" +
                    "\r\n<td>{priority}</td>" +
                    "\r\n<td>{date}</td>" +
                    $"\r\n<td>{this.Author}</td>" +
                    "\r\n<td>\r\n<a href=\"/issue/edit?id=\" class=\"btn mini btn-primary\">Edit</a>\r\n</td>" +
                    "\r\n<td>" +
                    "\r\n<a href=\"/issue/delete?id=\" class=\"confirm-delete mini btn btn-danger\">Delete</a>" +
                    "\r\n</td>";
            }
            else
            {
                template = "<td>{id}</td>" +
                           "\r\n<td>{name}</td>" +
                           "\r\n<td>{status}</td>" +
                           "\r\n<td>{priority}</td>" +
                           "\r\n<td>{date}</td>" +
                           $"\r\n<td>{this.Author}</td>";
            }

            return template;
        }
    }
}
