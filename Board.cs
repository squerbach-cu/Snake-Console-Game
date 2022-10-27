using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Console_Game
{
    public class Board
    {
        public int Width { get; set; } = 50;
        public int Height { get; set; } = 24;
        public void PrintBoard()
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Playing field
            for (int i = 1; i < Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("═");
            }
            for (int i = 1; i < Width; i++)
            {
                Console.SetCursorPosition(i, Height);
                Console.WriteLine("═");
            }
            for (int i = 1; i < Height +2; i++)
            {
                Console.SetCursorPosition(Width, i);
                Console.WriteLine("║");
            }
            for (int i = 1; i < Height +2; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("║");
            }

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("╔");
            Console.SetCursorPosition(Width, 0);
            Console.WriteLine("╗");
            Console.SetCursorPosition(0, Height);
            Console.WriteLine("╟");
            Console.SetCursorPosition(Width, Height);
            Console.WriteLine("╢");

            //Score Box
            Console.SetCursorPosition(0, Height + 2);
            Console.WriteLine("╚");
            Console.SetCursorPosition(Width, Height + 2);
            Console.WriteLine("╝");
            for (int i = 1; i < Width; i++)
            {
                Console.SetCursorPosition(i, Height + 2);
                Console.WriteLine("═");
            }
            Console.SetCursorPosition(2, Height + 1);
            Console.WriteLine("Score: 0");
        }

        public void UpdateScore(int score)
        {
            Console.SetCursorPosition(2, Height + 1);
            Console.WriteLine("Score: {0}", score);
        }        
    }
}
