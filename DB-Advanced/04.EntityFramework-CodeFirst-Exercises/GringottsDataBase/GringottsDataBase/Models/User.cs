using System.Web.Security;

namespace GringottsDataBase.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        //02.
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual string FullName { get { return this.FirstName + " " + this.LastName; } set { } }

        [Required, MinLength(4), MaxLength(30)]
        public string Username { get; set; }

        /// <summary>
        /// !!!!!NICE!!!!!
        /// </summary>
        [MembershipPassword(MinRequiredPasswordLength = 4, ErrorMessage = "Incorect password"), MaxLength(16)]
        public string Password { get; set; }

        [Required, RegularExpression(@"^([a-zA-Z0-9]+([-._][a-zA-Z0-9]+)*)@([a-z]+(\.[a-z]+)+)$")]
        public string Email { get; set; }

        public string BornTown { get; set; }

        public string LivingTown { get; set; }

        [MaxLength(1024)]
        public string ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}