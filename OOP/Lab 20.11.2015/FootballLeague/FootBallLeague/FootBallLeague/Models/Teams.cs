using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallLeague.Models
{
    class Teams
    {
        //FIELDS
        private string name;
        private string nickname;
        private DateTime foundDate;
        private List<Players> player;

        //CONSTRUCTOR
        public Teams(string Name, string NickName, DateTime FoundDate)
        {
            this.name = Name;
            this.nickname = NickName;
            this.foundDate = FoundDate;
            this.player = new List<Players>();
        }
        //PROPERTY FOR NAME
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (name.Length >= 5)
                {
                    throw new Exception("The name should be at least 5 characters long!");
                }
                this.name = value;
            }
        }
        //PROPERTY FOR NICKNAME
        public string NickName
        {
            get
            {
                return this.nickname;
            }
            set
            {
                if (nickname.Length >= 5)
                {
                    throw new Exception("The nick name should be at least 5 characters long!");
                }
                this.name = value;
            }
        }

        //PROPERTY FOR FoundDate
        public DateTime FoundDate
        {
            get
            {
                return this.foundDate;
            }
            set
            {
                this.foundDate = value;
            }
        }


        //property for player
        public IEnumerable<Players> Player
        {
            get
            {
                return this.Player;
            }

        }
        //METHOD FOR ADDING PLAYERS

        public void AddPlayer(Players player)
        {
            if (CheckIfPlayerExists(player))
            {
                throw new InvalidOperationException("Player already exists for that team");
            }
        }   


        //METHOD FOR CHECKING IF PLAYER EXIST
        private bool CheckIfPlayerExists(Players player)
        {
            return this.player.Any(p => p.FirstName == player.FirstName &&
                                        p.LastName == player.LastName);
        }




    }
}
