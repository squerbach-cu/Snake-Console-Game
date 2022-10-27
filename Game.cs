using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;


namespace Snake_Console_Game
{
    public class Game
    {
        public Game()
        {
            Apple = new Apple();
            Board = new Board();
            Snake = new Snake();
        }
        
        public Apple Apple { get; set; }
        public Board Board { get; set; }
        public Snake Snake { get; set; }
        public int Score { get; set; }    

        public void Run()
        {
            Console.CursorVisible = false;

            Board.PrintBoard();                       

            Snake.InitLinkedListSnake();

            Snake.PrintLLSnakeInit();

            Apple.PlaceApple(Snake);

            while (true)
            {
                Thread.Sleep(250);

                if (Console.KeyAvailable)
                {
                    Snake.ControlSnakeLL(Console.ReadKey(true));
                }

                Snake.MoveSnakeLL(e.Move);                

                if (Snake.IsLost(Board.Width, Board.Height))
                {
                    string gameOver = "Game Over!";
                    Console.SetCursorPosition((Board.Width / 2) - (gameOver.Length / 2), Board.Height / 2);
                    Console.WriteLine(gameOver);
                    break;
                }
                if (Apple.AteApple(Snake))
                {
                    Score++;
                    Board.UpdateScore(Score);
                    Snake.DigestApple(Apple);
                    Apple.PlaceApple(Snake);                    
                }
            }
            Console.ReadKey();
        }        
    }
}
