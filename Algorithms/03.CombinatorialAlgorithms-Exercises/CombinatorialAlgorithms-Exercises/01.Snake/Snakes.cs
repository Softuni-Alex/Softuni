using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Snake
{
    public class Snakes
    {
        private static readonly HashSet<string> FoundSnakes = new HashSet<string>();
        private static readonly Stack<Coordinates> Visited = new Stack<Coordinates>();
        private static int count;
        private static int snakeLength;
        private static string snake;

        public static void Main(string[] args)
        {
            snake = string.Empty;
            snakeLength = int.Parse(Console.ReadLine());
            BuildSnake("S", 0, 0);

            Console.WriteLine("Snakes count = {0}", count);
        }

        private static void BuildSnake(string direction, int x, int y)
        {
            Coordinates currentCoordinates = new Coordinates(x, y);

            if (Visited.Contains(currentCoordinates))
            {
                return;
            }

            snake = snake + direction;
            Visited.Push(currentCoordinates);

            if (snake.Length == snakeLength)
            {
                if (!FoundSnakes.Contains(snake))
                {
                    MarkSnakes(snake);
                    count++;
                    Console.WriteLine(snake);
                }
                snake = snake.Remove(snake.Length - 1);
                Visited.Pop();
                return;
            }

            BuildSnake("R", x + 1, y);

            if (snake.Length > 1)
            {
                BuildSnake("D", x, y - 1);

                BuildSnake("L", x - 1, y);

                BuildSnake("U", x, y + 1);
            }

            snake = snake.Remove(snake.Length - 1);
            Visited.Pop();
        }

        private static bool MarkSnakes(string snake)
        {
            FoundSnakes.Add(snake);
            FoundSnakes.Add(MirrorSnake(snake));
            string reversed = ReverseSnake(snake);
            while (reversed[1] != 'R')
            {
                reversed = RotateSnake(reversed);
            }

            FoundSnakes.Add(reversed);
            FoundSnakes.Add(MirrorSnake(reversed));

            return true;
        }

        private static string RotateSnake(string snakeToRotate)
        {
            StringBuilder snakeBuilder = new StringBuilder("S");
            for (int i = 1; i < snakeToRotate.Length; i++)
            {
                switch (snakeToRotate[i])
                {
                    case 'D':
                        snakeBuilder.Append("R");
                        break;
                    case 'L':
                        snakeBuilder.Append("D");
                        break;
                    case 'U':
                        snakeBuilder.Append("L");
                        break;
                    case 'R':
                        snakeBuilder.Append("U");
                        break;
                }
            }

            return snakeBuilder.ToString();
        }

        private static string MirrorSnake(string snakeToMirror)
        {
            StringBuilder snakeBuilder = new StringBuilder("S");

            for (int i = 1; i < snakeToMirror.Length; i++)
            {
                switch (snakeToMirror[i])
                {
                    case 'U':
                        snakeBuilder.Append("D");
                        break;
                    case 'D':
                        snakeBuilder.Append("U");
                        break;
                    default:
                        snakeBuilder.Append(snakeToMirror[i]);
                        break;
                }
            }

            return snakeBuilder.ToString();
        }

        private static string ReverseSnake(string snakeToReverse)
        {
            StringBuilder snakeBuilder = new StringBuilder("S");
            for (int i = snakeToReverse.Length - 1; i > 0; i--)
            {
                snakeBuilder.Append(snakeToReverse[i]);
            }
            return snakeBuilder.ToString();
        }

        // used struct
        public struct Coordinates
        {
            public int X;

            public int Y;

            public Coordinates(int x, int y)
                : this()
            {
                this.X = x;
                this.Y = y;
            }
        }

    }
}
