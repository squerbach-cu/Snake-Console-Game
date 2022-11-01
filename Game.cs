using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Threading.Timer;


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

        private Apple Apple { get; set; }
        private Board Board { get; set; }
        private Snake Snake { get; set; }
        private int Score { get; set; }    

        /// <summary>
        /// Initialises
        /// </summary>
        /// <param name="restart"></param>
        public void Run(bool restart)
        {
            Console.CursorVisible = false;

            Board.PrintBoard();

            if (!restart) PressButtonToStart();

            Snake.InitSnake(Board);

            Snake.PrintSnakeInit();

            Apple.PlaceApple(Snake, Board);

            while (true)
            {
                if (Score > 20)
                {
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(250 - (Score * 10));
                }

                if (Console.KeyAvailable)
                {
                    Snake.ControlSnake(Console.ReadKey(true));
                }

                Snake.MoveSnake(e.Move);                

                if (Snake.IsLost(Board.Width, Board.Height))
                {
                    const string gameOver = "Game Over!";
                    Console.SetCursorPosition((Board.Width / 2) - (gameOver.Length / 2), Board.Height / 2);
                    Console.WriteLine(gameOver);
                    break;
                }
                if (Apple.AteApple(Snake))
                {
                    Score++;
                    Board.UpdateScore(Score);
                    Snake.DigestApple(Apple);
                    Apple.PlaceApple(Snake, Board);                    
                }
            }

            if (IsRestartWanted())
            {
                Restart();
            } 
            Environment.Exit(0);            
        }
        
        /// <summary>
        /// Reads the Y or N Key to determine whether the user wants to start again. 
        /// </summary>
        /// <returns></returns>
        private bool IsRestartWanted()
        {
            string restart = "Restart? (y/n)";
            Console.SetCursorPosition((Board.Width / 2) - (restart.Length / 2), (Board.Height / 2) + 1);
            Console.WriteLine(restart);                       
            
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Y:
                            return true;
                        case ConsoleKey.N:
                            return false;                        
                    }
                }                
            }
        }
        
        /// <summary>
        /// Creates new Game instance and calls Run()
        /// </summary>
        /// Should I just call Main() or reset all the existing objects somehow? 
        private void Restart()
        {
            Console.Clear();            
            Game snake = new Game();
            snake.Run(true);
        }

        /// <summary>
        /// Waits for an initial button press, so that the snake doesn't run into the border without the player being ready
        /// </summary>
        private void PressButtonToStart()
        {
            const string start = "Press any key to start!";
            const string empty = " ";
            Console.SetCursorPosition((Board.Width / 2) - (start.Length / 2), (Board.Height / 2) + 1);
            Console.WriteLine(start);
            Console.ReadKey(true);
            Console.SetCursorPosition((Board.Width / 2) - (start.Length / 2), (Board.Height / 2) + 1);
            for (int i = 0; i < start.Length; i++)
            {
                Console.Write(empty);
            }
        }
    }
}
