using System.Collections.Generic;

namespace DbEntities.Models
{
    public class User
    {
        public User()
        {
            this.Issues = new HashSet<Issue>();
            this.Logins = new HashSet<Login>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}
