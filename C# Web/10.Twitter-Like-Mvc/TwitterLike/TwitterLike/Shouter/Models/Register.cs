using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shouter.Models
{
    public class Register
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50), Index(IsUnique = true)]
        public string Username { get; set; }

        [Required, StringLength(50), Index(IsUnique = true)]
        public string Email { get; set; }

        [Required, MinLength(3)]
        public string Password { get; set; }

        [Required, MinLength(3)]
        public string ConfirmPassword { get; set; }

        [Required, Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }
    }
}
