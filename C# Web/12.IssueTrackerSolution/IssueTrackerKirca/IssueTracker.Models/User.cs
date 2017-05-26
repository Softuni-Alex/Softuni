using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Models
{
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class User
    {
        public User()
        {
            this.Issues = new HashSet<Issue>();
        }

        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Role Role { get; set; }

        public ICollection<Issue> Issues { get; set; }
    }
}
