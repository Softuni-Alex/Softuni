namespace FootballBookmakerSystem.Data
{
    using Models.Models;
    using System.Data.Entity;
    public class FootballContext : DbContext
    {
        public FootballContext()
            : base("FootballContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<FootballContext>());
        }

        public IDbSet<BetGame> BetGame { get; set; }

        public IDbSet<Bets> Bets { get; set; }

        public IDbSet<Colors> Colors { get; set; }

        public IDbSet<Competitions> Competitions { get; set; }

        public IDbSet<CompetitionTypes> CompetitionTypes { get; set; }

        public IDbSet<Continents> Continents { get; set; }

        public IDbSet<Countries> Countries { get; set; }

        public IDbSet<Games> Games { get; set; }

        public IDbSet<Players> Players { get; set; }

        public IDbSet<PlayerStatistics> PlayerStatistics { get; set; }

        public IDbSet<Position> Position { get; set; }

        public IDbSet<ResultPrediction> ResultPrediction { get; set; }

        public IDbSet<Rounds> Rounds { get; set; }

        public IDbSet<Teams> Teams { get; set; }

        public IDbSet<Towns> Towns { get; set; }

        public IDbSet<Users> Users { get; set; }
    }
}