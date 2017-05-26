using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBookmakerSystem.Models.Models
{
    public class BetGame
    {
        [Key, Column(Order = 0)]
        public int GameId { get; set; }

        [Key, Column(Order = 1)]
        public int BetId { get; set; }

        [ForeignKey("GameId")]
        public Games Game { get; set; }

        [ForeignKey("BetId")]
        public Bets Bet { get; set; }

        public ResultPrediction ResultPrediction { get; set; }
    }
}