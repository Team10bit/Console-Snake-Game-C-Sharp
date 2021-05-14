using System;

namespace Test
{
    class Program
    {
        /* WELCOME TO SNAKE GAME (C# CONSOLE EDITION)!
        I know the code is messy/sloppy and generally all over the place,
        But I wasn't planning on releasing this to the public.
        Basically I was just dicking around and playing with C# in Visual Basic.
        I primarily use Processing (Java), so I was trying to get a feel for C#.
        Once I got a general feel for it, I decided I would create an easy game.
        Snake Game is probably the game I always recreate in a new language because it's fun and usually easy.
        However, it was a bit difficult doing it in the command prompt.
        I learned a lot, though. I definitely want to continue learning more about Visual Basic and C#.
        But that's that. I hope it's as "fun" for you as the original.
        If you have some suggestions to improve the code or want to give me tips/advice,
        Feel free to contact me if there's a contact link on github somewhere.
        TDLR; I used a new language and wanted to test my abilities in C#.
        */

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
                board = new Gameboard(10);
                goto regularUpdate;
            }
        }
    }
}
