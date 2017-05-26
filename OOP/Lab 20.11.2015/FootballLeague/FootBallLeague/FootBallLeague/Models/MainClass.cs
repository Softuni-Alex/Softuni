using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallLeague.Models
{
    class MainClass
    {
        static void Main()
        {

            string line = Console.ReadLine();
            while (line != "End")
            {
                try
                {
                    LeagueManager.HandInput(line);
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch(InvalidOperationException oe)
                {
                    Console.WriteLine(oe.Message);
                }
                line = Console.ReadLine();
            }



        }
        public static void HandleInput(string input)
        {
            var inputArgs = input.Split();
        }
    }
}
