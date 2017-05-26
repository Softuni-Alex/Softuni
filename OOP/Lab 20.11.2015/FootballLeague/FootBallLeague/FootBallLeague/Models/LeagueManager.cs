using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallLeague.Models
{
    public static class LeagueManager
    {

       public static void HandInput(string input)
        {
            var inputArgs = input.Split(' ');
            switch (inputArgs[0])
            {
                case "AddTeam":
                    AddTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]));
                    break;
                case "AddMatch":
                    break;
                case "AddPlayerToTeam":
                    break;
                case "ListTeams":
                    break;
                case "ListMatches":
                    break;
            }
            

          
        }

       
    }
}
