using Checkers.Model;
using Checkers.Model.Request;
using System;
using System.Collections.Generic;

namespace Checkers.Game
{
    public class GameInput
    {
        public static Input GetPlayerInput(Board board)
        {
            Input playerinput = new Input();

            Console.WriteLine($"Enter Your Input {board.CurrentTurn} : ");

            Console.WriteLine("Enter The Location Of The Pawn You Want To Move With");

            //Setting The Starting Point
            var startPoint = new Point();

            do
            {
                //Validation Loop of the Input of the Starting Point of the Player During the Game
                startPoint = GetPoint(board);
            } while (ValidUserStartingPointInput(board, startPoint) == false);


            playerinput.StartingPoint = startPoint;

            Console.WriteLine("Enter The Location You Want To Move To With Your Pawn");

            //Setting The Ending Point
            playerinput.EndPoint = GetPoint(board);

            return playerinput;
        }

        public static Point GetPoint(Board board)
        {
            while (true)
            {
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

                Console.WriteLine($"\nY Position = {height}\n");

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

                Console.WriteLine($"\nYour Position = ({height}, {width})\n");

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

        private static bool ValidUserStartingPointInput(Board board, Point point)
        {
            if (board.Tiles[point.Height, point.Width] == null)
            {
                Console.WriteLine("\nSorry, There is no Pawn on this Tile\nPlease Try Again...\n");
                return false;
            }

            else if (board.Tiles[point.Height, point.Width] != null && board.Tiles[point.Height, point.Width].Color != board.CurrentTurn)
            {
                Console.WriteLine("\nSorry,That's Not one of your Pawns\nPlease Try Again...\n");
                return false;
            }

            return true;
        }

        private static Input CreatingNextEatingInput(Point startingPoint, int moveY, int moveX)
        {
            var endPoint = new Point { Height = startingPoint.Height + moveY, Width = startingPoint.Width + moveX };

            return new Input { StartingPoint = startingPoint, EndPoint = endPoint };
        }
    }
}
