using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbEntities.Models
{
    public class User
    {
        public User()
        {
            this.Games = new List<Game>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(50), Index(IsUnique = true)]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }

        public bool IsAdministrator { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
