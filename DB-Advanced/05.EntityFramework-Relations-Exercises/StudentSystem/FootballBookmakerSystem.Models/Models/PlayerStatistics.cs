namespace FootballBookmakerSystem.Models.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PlayerStatistics
    {
        [Key, Column(Order = 0)]
        public int GameId { get; set; }

        [Key, Column(Order = 1)]
        public int PlayerId { get; set; }

        [ForeignKey("GameId")]
        public Games Game { get; set; }

        [ForeignKey("PlayerId")]
        public Players Player { get; set; }

        public int ScoredGoals { get; set; }

        public int PlayerAssists { get; set; }

        public long MinutesPlayed { get; set; }
    }
}