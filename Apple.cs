using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Console_Game
{
    public class Apple
    {
        private int AppleX { get; set; }
        private int AppleY { get; set; }
        public void PlaceApple(Snake snake)
        {
            Random random = new Random();

            AppleX = random.Next(1, 1);
            AppleY = random.Next(1, 25);

            if (true)
            {
                foreach (var s in snake.snakeList)
                {
                    if (s.x == AppleX && s.y == AppleY)
                    {
                        PlaceApple(snake);
                        return;
                    }
                }
            }

            Console.SetCursorPosition(AppleX, AppleY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("■");
            Console.ForegroundColor = ConsoleColor.White;            
        }

        public bool AteApple(Snake snake)
        {
            if (snake.snakeList.First.Value.x == AppleX && snake.snakeList.First.Value.y == AppleY)
            {
                return true;
            }            
            return false;
        }
    }
}
