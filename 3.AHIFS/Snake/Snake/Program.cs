using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeLib;
using System.Windows.Input;
using System.IO;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int actScore = 0;
            string[] scorings = null;
            string finalscore;
            try
            {
                scorings = File.ReadAllLines(@".\ScoringList.txt");
                Console.CursorVisible = false;
                SnakeLib.Snake snake = new SnakeLib.Snake();

                int before = 3;

                DrawSnake(snake.GetKooSnake());

                do
                {
                    while (!Console.KeyAvailable)
                    {
                        System.Threading.Thread.Sleep(150);
                        if (before == 1) GoUp(snake);
                        if (before == 2) GoDown(snake);
                        if (before == 3) GoRight(snake);
                        if (before == 4) GoLeft(snake);
                        Console.Clear();
                        DrawSnake(snake.GetKooSnake());
                        SpawnFood(snake, ref actScore);
                        snake.testGameOver();
                    }


                    ConsoleKeyInfo key = Console.ReadKey(true);
                    //Console.WriteLine(keyinfo.KeyChar + " was pressed");

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            {
                                GoUp(snake);
                                before = 1;
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                GoDown(snake);
                                before = 2;
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                before = 3;
                                GoRight(snake);                                
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            {
                                GoLeft(snake);
                                before = 4;
                                break;
                            }
                        default:
                            {
                                if (before == 1) GoUp(snake);
                                if (before == 2) GoDown(snake);
                                if (before == 3) GoRight(snake);
                                if (before == 4) GoLeft(snake);

                                break;
                            }

                    }
                    //Console.Clear();
                    //DrawSnake(snake.GetKooSnake());
                    SpawnFood(snake, ref actScore);
                    snake.testGameOver();
                }
                while (true);

            }
            catch (Exception)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Game Over!!!\nYour Score: " + actScore);
                Console.Write("Type in your name:");
                Console.CursorVisible = true;
                string Name = Console.ReadLine();
                finalscore = "" + actScore;
                int i = 0;
                string[] s;
                bool result = true;
                
                while(scorings.Length > i && result)
                {
                    s = scorings[i].Split(' ');
                    if(int.Parse(s[2]) < int.Parse(finalscore))
                    {
                        scorings[i] = "" + (i + 1) + "." + " " + Name + " " + finalscore;
                        result = false;
                    }

                    i++;
                }

                File.WriteAllLines(@".\ScoringList.txt", scorings);
            }
        }

        private static void GoUp(SnakeLib.Snake snake)
        {
            int[,] snakeKoo = snake.GetKooSnake();
            int x = snakeKoo[snakeKoo.GetLength(0) - 1, 0];
            int y = snakeKoo[snakeKoo.GetLength(0) - 1, 1];
            Console.SetCursorPosition(x, y);
            Console.Write("");
            Console.SetCursorPosition(snakeKoo[0, 0], snakeKoo[0, 1] - 1);
            Console.Write("*");
            snake.GoUp();
        }

        private static void GoDown(SnakeLib.Snake snake)
        {
            int[,] snakeKoo = snake.GetKooSnake();
            int x = snakeKoo[snakeKoo.GetLength(0) - 1, 0];
            int y = snakeKoo[snakeKoo.GetLength(0) - 1, 1];
            Console.SetCursorPosition(x, y);
            Console.Write("");
            Console.SetCursorPosition(snakeKoo[0, 0], snakeKoo[0, 1] + 1);
            Console.Write("*");
            snake.GoDown();
        }

        private static void GoRight(SnakeLib.Snake snake)
        {
            int[,] snakeKoo = snake.GetKooSnake();
            int x = snakeKoo[snakeKoo.GetLength(0) - 1, 0];
            int y = snakeKoo[snakeKoo.GetLength(0) - 1, 1];
            Console.SetCursorPosition(x, y);
            Console.Write("");
            Console.SetCursorPosition(snakeKoo[0, 0] + 1, snakeKoo[0, 1]);
            Console.Write("*");
            snake.GoRight();
        }

        private static void GoLeft(SnakeLib.Snake snake)
        {
            int[,] snakeKoo = snake.GetKooSnake();
            int x = snakeKoo[snakeKoo.GetLength(0) - 1, 0];
            int y = snakeKoo[snakeKoo.GetLength(0) - 1, 1];
            Console.SetCursorPosition(x, y);
            Console.Write("");
            Console.SetCursorPosition(snakeKoo[0, 0] - 1, snakeKoo[0, 1]);
            Console.Write("*");
            snake.GoLeft();
        }

        static void DrawSnake(int[,] Koordinates)
        {
            for (int i = 0; i < Koordinates.GetLength(0); i++)
            {
                Console.SetCursorPosition(Koordinates[i, 0], Koordinates[i, 1]);
                Console.Write("*");
            }
        }

        static void SpawnFood(SnakeLib.Snake snake, ref int score)
        {
            int[,] kooSnake = snake.GetKooSnake();
            int[] kooFood = snake.GetKooFood();
            int oldx = Console.CursorLeft;
            int oldy = Console.CursorTop;
            int x;
            int y;

            if (kooSnake[0, 0] == kooFood[0] && kooSnake[0, 1] == kooFood[1])
            {
                Random rnd = new Random();
                x = rnd.Next(50);
                y = rnd.Next(20);
                snake.SetFoodKoo(x, y);
                snake.GetBigger();
                score++;
            }
            else
            {
                x = kooFood[0];
                y = kooFood[1];
            }
                

            Console.SetCursorPosition(x, y);

            Console.Write("*");

            Console.SetCursorPosition(115, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(score);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(oldx, oldy);

        }
    }
}
