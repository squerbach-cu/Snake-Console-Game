using System;

namespace Snake_Console_Game
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Game snake = new Game();
            snake.Run(false);  
        }
   }
}
