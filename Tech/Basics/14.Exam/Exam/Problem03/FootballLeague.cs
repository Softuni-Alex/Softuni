using System;
using System.Collections.Generic;

namespace Problem03
{
    class Program
    {
        static void Main(string[] args)
        {
            string decryptionKey = Console.ReadLine();
            Dictionary<string, long> league = new Dictionary<string, long>();

            while (true)
            {
                string comands = Console.ReadLine();

                if (comands == "final")
                {
                    break;
                }

                string newstring = string.Empty;

                for (int i = 0; i < comands.Length; i++)
                {
                    int indexOpen = comands.IndexOf(decryptionKey, i);
                    int indexClose = comands.IndexOf(decryptionKey, i);
                    if (i == indexOpen)
                    {
                        if (indexOpen != -1 && indexClose != -1)
                        {
                            for (int j = indexOpen + decryptionKey.Length; j < indexClose; j++)
                            {
                                newstring += comands[j].ToString().ToUpper();
                            }
                            i += indexClose - indexOpen + decryptionKey.Length;
                        }
                    }
                    if (i < comands.Length)
                    {
                        newstring += comands[i];
                    }
                }
                Console.WriteLine(newstring);

                string[] mody = newstring.Split(" .,!@#$%^&*()_+=-[]'\\\';.,/?><|".ToCharArray());
                string firstTeamNames = mody[0];
                string secondTeamNames = mody[1];
                string[] teamScores = mody[2].Split(':');

                for (int i = firstTeamNames.Length - 1; i >= 0; i--)
                {
                    firstTeamNames = firstTeamNames[i];
                }

                long firstTeamScore = long.Parse(teamScores[0]);
                long secondTeamScore = long.Parse(teamScores[1]);

                if (!league.ContainsKey(firstTeamNames))
                {
                    league[firstTeamNames] = firstTeamScore;
                }
            }
        }
    }
}