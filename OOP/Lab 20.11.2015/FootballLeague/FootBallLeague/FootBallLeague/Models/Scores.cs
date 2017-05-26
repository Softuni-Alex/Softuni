using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallLeague.Models
{
    class Scores
    {
        //FIELDS
        private int awayTeamGoals;
        private int homeTeamGoals;

        //CONSTRUCTOR
        public Scores(int AwayTeamGoals, int HomeTeamGoals)
        {
            this.awayTeamGoals = AwayTeamGoals;
            this.homeTeamGoals = HomeTeamGoals;
        }

        //PROPERTY FOR AWAYTEAMS
        public int AwayTeamGoals
        {
            get
            {
                return this.awayTeamGoals;
            }
            set
            {
                if (awayTeamGoals < 0)
                {
                    throw new ArgumentException("The goals cannot be negative!");
                }
                this.awayTeamGoals = value;
            }
        }
        //PROPERTY FOR HOMETEAMS
        public int HomeTeamGoals
        {
            get
            {
                return this.homeTeamGoals;
            }
            set
            {
                if (homeTeamGoals < 0)
                {
                    throw new Exception("The goals cannot be negative!");
                }
                this.homeTeamGoals = value;
            }
        }

    }
}
