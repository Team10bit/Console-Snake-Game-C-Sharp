using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Test
{
    public class Gameboard
    {
        int targetTick, currentTick, previousTick;
        Random ran = new Random();
        int x, y;
        String space = "0";
        String apple = "A";
        public bool playing = true;
        int fruitX, fruitY;
        List<Snake> snake = new List<Snake>();
        Apple fruit;
        int _wid, _hei;

        String[,] grid;

        public Gameboard(int hei)
        {
            targetTick = 2;
            Console.Title = "Snake Game (C# Console Edition!)";
            Console.SetWindowSize(48, 40);
            x = hei;
            y = hei * 2;
            _hei = y;
            _wid = x; //width of board
            grid = new string[x, y];
            fruit = new Apple((int)ran.Next(0, _wid - 1), (int)ran.Next(0, _hei - 1));
            snake.Add(new Snake(0, 3, true));
            snake.Add(new Snake(0, 4, false));
            snake.Add(new Snake(0, 5, false));
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {

                    if (i == fruitX && j == fruitY)
                    {
                        if (i != 0 && j != 0) grid[i, j] = apple;
                    }
                    else
                    {
                        grid[i, j] = space;
                    }
                    for (int k = 0; k < snake.Count; k++)
                    {
                        if (i == snake[k].getX() && j == snake[k].getY())
                        {
                            grid[i, j] = snake[k].getChar();
                        }
                    }
                }

                if (i == fruitX && fruitY == 0)
                {
                    grid[i, 0] = apple;
                }
                else
                {
                    grid[i, 0] = space;
                }
                for (int k = 0; k < snake.Count; k++)
                {
                    if (i == snake[k].getX() && snake[k].getY() == 0)
                    {
                        grid[i, 0] = snake[k].getChar();
                    }
                }
            }
        }

        public void setup()
        {

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine(grid[i, 0]);
            }
        }

        void updateBoard()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {

                    if (i == fruitX && j == fruitY)
                    {
                        if (i != 0 && j != 0) grid[i, j] = apple;
                    }
                    else
                    {
                        grid[i, j] = space;
                    }
                    for (int k = 0; k < snake.Count; k++)
                    {
                        if (i == snake[k].getX() && j == snake[k].getY())
                        {
                            grid[i, j] = snake[k].getChar();
                        }
                    }
                }

                if (i == fruitX && fruitY == 0)
                {
                    grid[i, 0] = apple;
                }
                else
                {
                    grid[i, 0] = space;
                }
                for (int k = 0; k < snake.Count; k++)
                {
                    if (i == snake[k].getX() && snake[k].getY() == 0)
                    {
                        grid[i, 0] = snake[k].getChar();
                    }
                }
            }
        }

        void fixSnake()
        {
            for (int i = 0; i < snake.Count; i++)
            {
                if (snake[i].getY() > _hei) //X-Axis
                {
                    snake[i].setY(-1);
                }
                else if (snake[i].getY() < 0) //X-Axis
                {
                    snake[i].setY(_hei);
                }
                else if (snake[i].getX() > _wid) //Y-Axis
                {
                    snake[i].setX(-1);
                }
                else if (snake[i].getX() < 0) //Y-Axis (Somehow I messed up the coordinate system and too lazy to fix it.)
                {
                    snake[i].setX(_wid);
                }
            }
        }

        void displayBoard()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {

                    if (fruit.getX() == i && fruit.getY() == j)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    for (int k = 0; k < snake.Count; k++)
                    {
                        if (snake[k].getX() == i && snake[k].getY() == j)
                        {
                            if (snake[k].isHead())
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                            }
                        }
                    }
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine(grid[i, 0]);
            }
        }

        public void checkControl()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case 'w':
                        if(snake[0].direction != Snake.Directions.DOWN) snake[0].setDir(Snake.Directions.UP);
                        break;
                    case 's':
                        if (snake[0].direction != Snake.Directions.UP) snake[0].setDir(Snake.Directions.DOWN);
                        break;
                    case 'a':
                        if (snake[0].direction != Snake.Directions.RIGHT) snake[0].setDir(Snake.Directions.LEFT);
                        break;
                    case 'd':
                        if (snake[0].direction != Snake.Directions.LEFT) snake[0].setDir(Snake.Directions.RIGHT);
                        break;
                    case (char)27:
                        Environment.Exit(0);
                        break;
                }
            }

        }

        public void TICK()
        {
            currentTick = System.DateTime.Now.Millisecond;
            if (previousTick != 0 && targetTick % previousTick == 0)
            {
                update();
            }
            previousTick = currentTick;
        }

        public void update()
        {

            Console.Clear();
            updateBoard();
            displayBoard();
            fixSnake();
            checkControl();

            for (int i = 0; i < snake.Count; i++)
            {
                if (i != 0 && snake[0].getX() == snake[i].getX() && snake[0].getY() == snake[i].getY())
                {
                    snake[0].alive = false;
                    playing = false;
                }
            }

            if (snake[0].getX() == fruit.getX() && snake[0].getY() == fruit.getY())
            {
                eatFruit();
                snake.Add(new Snake(snake[snake.Count - 1].getX(), snake[snake.Count - 1].getY() + 1, false));
            }

            for (int i = 0; i < snake.Count; i++)
            {
                snake[i].update();
                if (i != 0)
                {
                    snake[i].setDir(snake[i - 1].lastDir);
                }
            }
        }

        public void eatFruit()
        {
            fruit = new Apple((int)ran.Next(0, _wid - 1), (int)ran.Next(0, _hei - 1));
        }
    }
}
