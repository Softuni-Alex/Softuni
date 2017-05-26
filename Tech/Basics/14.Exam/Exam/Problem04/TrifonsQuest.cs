using System;
using System.Linq;

namespace Problem04
{
    class TrifonsQuest
    {
        static void Main(string[] args)
        {
            long health = long.Parse(Console.ReadLine());
            long turns = 0;
            long[] dimentions = Console.ReadLine().Split().Select(long.Parse).ToArray();

            long rows = dimentions[0];
            long cols = dimentions[1];

            char[][] map = new char[rows][];

            //read the matrix
            for (int row = 0; row < rows; row++)
            {
                map[row] = Console.ReadLine().ToArray();
            }

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    switch (map[j][i])
                    {
                        case 'F':
                            long tempHealthF = 0;
                            tempHealthF = turns / 2;
                            health -= tempHealthF;
                            turns++;
                            break;

                        case 'H':
                            long tempHealthH = 0;
                            tempHealthH = turns / 3;
                            health += tempHealthH;
                            turns++;
                            break;

                        case 'T':
                            turns += 2;
                            turns++;
                            break;

                        case 'E':
                            turns++;
                            break;
                    }
                    if (health <= 0)
                    {
                        Console.WriteLine("Died at: [{0}, {1}]", j, i);
                        break;
                    }
                }
            }
            if (health > 0)
            {
                Console.WriteLine("Quest completed!");
                Console.WriteLine("Health: {0}", health);
                Console.WriteLine("Turns: {0}", turns);
            }
        }
    }
}