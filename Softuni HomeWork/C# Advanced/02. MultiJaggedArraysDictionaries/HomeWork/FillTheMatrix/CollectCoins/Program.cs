using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectCoins
{
    class Program
    {
        private static void Main()
        {
            // input
            string[] board = new string[4];
            for (int i = 0; i < 4; i++)
            {
                board[i] = Console.ReadLine();
            }
            char[] commands = Console.ReadLine().ToCharArray();

            // logic
            int x = 0;
            int y = 0;
            int coins = 0;
            int hits = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case '>':
                        int temp = y + 1;
                        if (temp < board[x].Length)
                        {
                            y = temp; // apply new position if valid
                            if (board[x][y] == '$')
                            {
                                coins++;
                            }
                        }
                        else
                        {
                            hits++;
                        }
                        break;

                    case '<':
                        temp = y - 1;
                        if (temp >= 0)
                        {
                            y = temp; // apply new position if valid
                            if (board[x][y] == '$')
                            {
                                y = temp;
                                coins++;
                            }
                        }
                        else
                        {
                            hits++;
                        }
                        break;

                    case '^':
                        temp = x - 1;
                        if (temp >= 0)
                        {
                            x = temp; // apply new position if valid
                            if (board[x][y] == '$')
                            {
                                coins++;
                            }
                        }
                        else
                        {
                            hits++;
                        }
                        break;

                    case 'v':
                        temp = x + 1;
                        if (temp < 4)
                        {
                            x = temp; // apply new position if valid
                            if (board[x][y] == '$')
                            {
                                coins++;
                            }
                        }
                        else
                        {
                            hits++;
                        }
                        break;
                }
            }

            // output
            Console.WriteLine("Coins collected: {0}", coins);
            Console.WriteLine("Walls hit: {0}", hits);
        }
    }
}
