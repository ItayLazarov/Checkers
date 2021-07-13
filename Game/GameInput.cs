using Checkers.Model;
using Checkers.Model.Request;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Checkers.Game
{
    public class GameInput
    {
        public static object GetPlayerInput(Board board)
        {
            var playerinput = new Input();

            while (true)
            {
                Console.WriteLine($"{board.CurrentTurn} : Enter The Location Of The Pawn\n");
                var input = GetPoint(board,playerinput);

                if (input.Equals(false))
                    return false;

                else if (ValidUserStartingPointInput(board, (Point)input) == true)
                {
                    playerinput.StartingPoint = (Point)input;
                    break;
                }
                Thread.Sleep(2000);
                DisplayBoard.Display(board);
            }

            Console.WriteLine($"{board.CurrentTurn} : Enter The Intended Location Of Your Pawn\n");

            var endPoint = GetPoint(board, playerinput);

            if (endPoint.Equals(false))
                return false;

            //Setting The Ending Point
            playerinput.EndPoint = (Point)endPoint;

            return playerinput;
        }

        public static Point GetNextEatPoint(Board board)
        {
            while (true)
            {
                Console.WriteLine("Current Position : (Y , X)\n");

                Console.WriteLine("\nEnter Y Location:");

                if (int.TryParse(Console.ReadLine(), out int height) == false)
                {
                    Console.WriteLine("\nSorry,That's Not a Number...\n");
                    continue;
                }

                else if (height > board.Tiles.GetLength(0) || height < 0)
                {
                    Console.WriteLine("\nSorry, This number is not in the borders of the board\nPlease Try Again...");
                    continue;
                }

                Console.WriteLine($"\nCurrent Position : ({height} , X)\n");

                Console.WriteLine("\nEnter X Location:");

                if (int.TryParse(Console.ReadLine(), out int width) == false)
                {
                    Console.WriteLine("\nSorry,That's Not a Number...\n");
                    continue;
                }

                else if (width > board.Tiles.GetLength(1) || width < 0)
                {
                    Console.WriteLine("\nSorry, This number is not in the borders of the board\nPlease Try Again...");
                    continue;
                }

                DisplayBoard.Display(board);

                Console.WriteLine($"\nCurrent Position : ({height} , {width})\n");

                return new Point { Height = height, Width = width };
            }
        }

        public static List<Point> IsTherePawnsAround(Point startingPoint)
        {
            List<Point> tilesThatCanBeEaten = new List<Point>();

            var move = 2;
            // + Y , + X
            tilesThatCanBeEaten.Add(CreatingNextEatingInput(startingPoint, move, move).EndPoint);

            // + Y , - X
            tilesThatCanBeEaten.Add(CreatingNextEatingInput(startingPoint, move, move * -1).EndPoint);

            // - Y , - X
            tilesThatCanBeEaten.Add(CreatingNextEatingInput(startingPoint, move * -1, move * -1).EndPoint);

            // - Y , + X
            tilesThatCanBeEaten.Add(CreatingNextEatingInput(startingPoint, move * -1, move).EndPoint);


            return tilesThatCanBeEaten;
        }

        private static object GetPoint(Board board,Input playerInput)
        {
            var point = new Point();

            //Y Loop
            while (true)
            {
                if (playerInput.StartingPoint != null)
                {
                    Console.WriteLine($"Current Position : ({playerInput.StartingPoint.Height} , {playerInput.StartingPoint.Width})\n");
                    Console.WriteLine("Destinate Position : (Y , X)\n");
                }

                else
                {
                    Console.WriteLine("Current Position : (Y , X)\n");
                }

                Console.WriteLine("Enter Y Location:");

                var obj1 = Compare(board);

                if (obj1.Equals(false))
                    return false;

                else if (obj1 is int Y)
                {
                    if (Y >= board.Tiles.GetLength(0) || Y < 0)
                    {
                        Console.WriteLine("\nSorry, This number is not in the borders of the board\nPlease Try Again...\n");
                        Thread.Sleep(2000);
                        DisplayBoard.Display(board);
                        continue;
                    }

                    point.Height = Y;
                    break;
                }

                else if(obj1 is string str)
                {
                    Console.WriteLine(str);
                    Thread.Sleep(2000);
                }

                DisplayBoard.Display(board);
            }

            DisplayBoard.Display(board);

            //X Loop
            while (true)
            {
                Console.WriteLine($"{board.CurrentTurn}:\n");

                if (playerInput.StartingPoint != null)
                {
                    Console.WriteLine($"Current Position : ({playerInput.StartingPoint.Height} , {playerInput.StartingPoint.Width})\n");
                    Console.WriteLine($"Destinate Position : ({point.Height} , X)\n");
                }

                else
                {
                    Console.WriteLine($"Current Position : ({point.Height} , X)\n");
                }

                Console.WriteLine("Enter X Location:");

                var obj2 = Compare(board);

                if (obj2.Equals(false))
                    return false;

                else if (obj2 is int X)
                {
                    if (X >= board.Tiles.GetLength(1) || X < 0)
                    {
                        Console.WriteLine("\nSorry, This number is not in the borders of the board\nPlease Try Again...\n");
                        Thread.Sleep(2000);
                        DisplayBoard.Display(board);
                        continue;
                    }

                    point.Width = X;
                    break;
                }

                else if (obj2 is string str)
                {
                    Console.WriteLine(str);
                    Thread.Sleep(2000);
                }

                DisplayBoard.Display(board);
            }

            DisplayBoard.Display(board);

            return point;
        }

        private static bool ValidUserStartingPointInput(Board board, Point point)
        {
            if (board.Tiles[point.Height, point.Width] == null)
            {
                Console.WriteLine("Sorry, There is no Pawn on this Tile\nPlease Try Again...\n");
                return false;
            }

            else if (board.Tiles[point.Height, point.Width] != null && board.Tiles[point.Height, point.Width].Color != board.CurrentTurn)
            {
                Console.WriteLine("Sorry,That's Not one of your Pawns\nPlease Try Again...\n");
                return false;
            }

            return true;
        }

        private static Input CreatingNextEatingInput(Point startingPoint, int moveY, int moveX)
        {
            var endPoint = new Point { Height = startingPoint.Height + moveY, Width = startingPoint.Width + moveX };

            return new Input { StartingPoint = startingPoint, EndPoint = endPoint };
        }

        private static object Compare(Board board)
        {
            
            //Input
            var obj1 = Console.ReadKey(true);

            if (int.TryParse(obj1.KeyChar.ToString(), out int number) == true)
                return number;

            if (obj1.Key == ConsoleKey.Escape)
            {
                if (Exit.ExitGame() == true)
                    return false;
                return "You Didn't Want To Exit Your Game...";
            }

            if (obj1.Key == ConsoleKey.H)
            {
                DisplayBoard.Display(board);
                MainMenu.Guide();
                return "End of Help...";
            }

            if (obj1.Key == ConsoleKey.F5)
            {
                if (SettingGame.SaveGame(board) == true)
                    return false;
                return "You Didn't Want To Save Your Game...";
            }

            return "That's Not a Number or Exit or Save or Help\nPlease Try again...\n";
        }
    }
}
