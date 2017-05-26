namespace FootballBookmakerSystem.Models.Models
{
    using System;
    using System.Collections.Generic;

    public class Bets
    {
        public Bets()
        {
            this.Games = new List<Games>();
        }

        public int Id { get; set; }

        public decimal BetMoney { get; set; }

        public DateTime BetDateTime { get; set; }

        public Users User { get; set; }

        public ICollection<Games> Games { get; set; }
    }
}