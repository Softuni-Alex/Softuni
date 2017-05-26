namespace FootballBookmakerSystem.Models.Models
{
    using System.Collections.Generic;

    public class Users
    {
        public Users()
        {
            this.Bets = new List<Bets>();
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public decimal Balance { get; set; }

        public ICollection<Bets> Bets { get; set; }
    }
}