using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Console_Game
{
    enum Direction
    {
        Up = 1,
        Down = 2,
        Left = 3,
        Right = 4,
    }
    public enum e
    {
        Digest = 1,
        Move = 2,
    }
    public class Coordinates
    {
        public Coordinates(int xCoordinate, int yCoordinate)
        {
            x = xCoordinate;
            y = yCoordinate;
        }
        public int x { get; set; }
        public int y { get; set; }
    }
    public class Snake
    {
        public LinkedList<Coordinates> snakeList { get; set; }
        private int SnakeLength { get; set; } 
        private Direction MoveDirection { get; set; } = Direction.Up;  
        private bool StillDigesting { get; set; }

        public void ControlSnake(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (MoveDirection != Direction.Down)
                    {
                        MoveDirection = Direction.Up;
                    }                                        
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (MoveDirection != Direction.Up)
                    {
                        MoveDirection = Direction.Down;
                    }                    
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (MoveDirection != Direction.Right)
                    {
                        MoveDirection = Direction.Left;
                    }
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (MoveDirection != Direction.Left)
                    {
                        MoveDirection = Direction.Right;
                    }
                    break;
            }
        }  
        
        public void InitSnake(Board board)
        {
            snakeList = new LinkedList<Coordinates>();
            
            SnakeLength = 4;

            for (int i = 0; i < SnakeLength; i++)
            {
                Coordinates coordinatesNode = new Coordinates(board.Width / 2, board.Height / 2 + i);
                LinkedListNode<Coordinates> lln = new LinkedListNode<Coordinates>(coordinatesNode);
                snakeList.AddLast(lln);
            }
        }

        public void PrintSnakeInit()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Coordinates item in snakeList)
            {
                Console.SetCursorPosition(item.x, item.y);
                Console.Write("■");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void PrintSnake()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(snakeList.First.Value.x, snakeList.First.Value.y);
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(snakeList.Last.Value.x, snakeList.Last.Value.y);
            Console.Write(" ");
        }

        public void MoveSnake(e order)
        {
            if (StillDigesting)
            {
                StillDigesting = false;
                return;
            }

            Coordinates firstCoordinates = snakeList.First.Value;

            switch (MoveDirection)
            {
                case Direction.Up:
                    Coordinates coordinatesNode = new Coordinates(firstCoordinates.x, firstCoordinates.y - 1);
                    LinkedListNode<Coordinates> up = new LinkedListNode<Coordinates>(coordinatesNode);
                    snakeList.AddFirst(up);
                    break;
                case Direction.Down:
                    coordinatesNode = new Coordinates(firstCoordinates.x, firstCoordinates.y + 1);
                    LinkedListNode<Coordinates> down = new LinkedListNode<Coordinates>(coordinatesNode);
                    snakeList.AddFirst(down);
                    break;
                case Direction.Left:
                    coordinatesNode = new Coordinates(firstCoordinates.x - 1, firstCoordinates.y);
                    LinkedListNode<Coordinates> left = new LinkedListNode<Coordinates>(coordinatesNode);
                    snakeList.AddFirst(left); 
                    break;
                case Direction.Right:
                    coordinatesNode = new Coordinates(firstCoordinates.x + 1, firstCoordinates.y);
                    LinkedListNode<Coordinates> right = new LinkedListNode<Coordinates>(coordinatesNode);
                    snakeList.AddFirst(right);
                    break;
            }
            if (order == e.Digest)
            {
                PrintSnake();
                StillDigesting = true;
            }
            else if (order == e.Move)
            {
                PrintSnake();
                snakeList.RemoveLast();
            }
        }
        
        /// <summary>
        /// Checks if the Snake hit itself or the border and colors the the spot the snake hit in red
        /// </summary>
        /// <param name="gameWidth"></param>
        /// <param name="gameHeight"></param>
        /// <returns></returns>
        public bool IsLost(int gameWidth, int gameHeight)
        {
            //Check if snake hit itself
            foreach (var s in snakeList.Skip(1))
            {
                if (s.x == snakeList.First.Value.x && s.y == snakeList.First.Value.y)
                {
                    ChangeHitColor(snakeList.First.Value.x, snakeList.First.Value.y);
                    return true;
                }
            }
            //Same As above just more fancy
            //if (snakeList.Skip(1).Any(s => s.x == snakeList.First.Value.x && s.y == snakeList.First.Value.y))            
            //    return true;            

            //Check if snake hit border
            if (snakeList.First.Value.x == 0 || snakeList.First.Value.x == gameWidth|| snakeList.First.Value.y == 0 || snakeList.First.Value.y == gameHeight)
            {
                ChangeHitColor(snakeList.First.Value.x, snakeList.First.Value.y);
                return true;
            }
            return false;            
        }
        
        /// <summary>
        /// Calls the MoveSnake() methode so it can grow the snake linked list by one node.
        /// </summary>
        /// <param name="apple"></param>
        public void DigestApple(Apple apple)
        {
            MoveSnake(e.Digest);            
        }

        /// <summary>
        /// Changes the color of the ■ spot the snake hit itself or the border.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void ChangeHitColor(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x, y);
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
