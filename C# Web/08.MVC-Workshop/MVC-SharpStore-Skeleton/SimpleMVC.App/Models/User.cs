using System.Collections.Generic;

namespace SharpStore.Models
{
    public class User
    {
        public User()
        {
            this.Logins = new List<Login>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}
