using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaForum.Models
{
    public class User
    {
        public User()
        {
            this.Topics = new List<Topic>();
        }

        public int Id { get; set; }

        [MaxLength(100), Index(IsUnique = true)]
        public string Username { get; set; }

        [MaxLength(100), Index(IsUnique = true)]
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdministrator { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}
