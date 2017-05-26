namespace Json.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Sold = new List<Product>();
            this.Bought = new List<Product>();
            this.Friends = new List<User>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        [MinLength(3)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Product> Sold { get; set; }

        public virtual ICollection<Product> Bought { get; set; }

        public virtual ICollection<User> Friends { get; set; }
    }
}