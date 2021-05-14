using System;
using System.Timers;

namespace Test
{
    class Program
    {
        Gameboard board = new Gameboard(10);
        static void Main(string[] args)
        {
            Program game = new Program();
            game.runGame();
        }

        void runGame()
        {
            board.setup();
            goto regularUpdate;

            regularUpdate:
            while (board.playing)
            {
                board.TICK();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Would you like to run the program again?");
            String userInput = Console.ReadLine();
            if (userInput == "n" || userInput == "N")
            {
                Environment.Exit(0);
            }
            else if (userInput == "y" || userInput == "Y")
            {
                board = new Gameboard(5);
                goto regularUpdate;
            }
        }
    }
}
