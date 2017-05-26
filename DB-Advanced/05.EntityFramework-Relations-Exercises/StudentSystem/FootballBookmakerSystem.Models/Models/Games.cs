namespace FootballBookmakerSystem.Models.Models
{
    using System;
    using System.Collections.Generic;

    public class Games
    {
        public Games()
        {
            this.Players = new List<Players>();
        }

        public int Id { get; set; }

        public Teams HomeTeam { get; set; }

        public Teams AwayTeam { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }

        public DateTime? GameDateTime { get; set; }

        public Bets HomeTeamWinBetRate { get; set; }

        public Bets AwayTeamWinBetRate { get; set; }

        public Bets DrawBetRate { get; set; }

        public Rounds Round { get; set; }

        public Competitions Competition { get; set; }

        public ICollection<Players> Players { get; set; }
    }
}