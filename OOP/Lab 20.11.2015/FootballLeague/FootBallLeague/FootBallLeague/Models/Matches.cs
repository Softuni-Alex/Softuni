using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallLeague.Models
{
    class Matches
    {
        //FIELDS
        private Teams homeTeam;
        private Teams awayTeam;
        private Scores score;
        private int id;

        //CONSTRUCTOR
        public Matches(Teams HomeTeam, Teams AwayTeam, Scores Score, int ID)
        {
            this.homeTeam = HomeTeam;
            this.awayTeam = AwayTeam;
            this.score = Score;
            this.id = ID;
        }

        //PROPERTY FOR HOMETEAM
        public Teams HomeTeam
        {
            get
            {
                return this.HomeTeam;
            }
            set
            {
                if (homeTeam == awayTeam)
                {
                    throw new Exception("You cannot enter two teams with same name!");
                }
                this.HomeTeam = value;
            }
        }

        //PROPERTY FOR AwayTeam
        public Teams AwayTeam
        {
            get
            {
                return this.HomeTeam;
            }
            set
            {
                if (awayTeam == homeTeam)
                {
                    throw new Exception("You cannot enter two teams with same name!");
                }
                this.HomeTeam = value;
            }
        }

        //PROPERTY FOR SCORE

        public Scores Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }

        //PROPERTY FOR ID
        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        //METHOD FOR Winners
        public Teams Winner()
        {
            if (this.IsDraw())
            {
                return null;
            }
            return this.Score.HomeTeamGoals > this.Score.AwayTeamGoals
                ? this.HomeTeam
                : this.AwayTeam;
        }


        //METHOD FOR IF ITS DRAW
        private bool IsDraw()
        {
            return this.Score.AwayTeamGoals == this.Score.HomeTeamGoals;
        }

    }


}

