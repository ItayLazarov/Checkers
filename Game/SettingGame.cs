using Checkers.Logic;
using Checkers.Model;
using Checkers.Model.Enums;
using Checkers.Model.Pawns;
using Checkers.Model.Request;
using System;
using System.Collections.Generic;

namespace Checkers.Game
{
    public class SettingGame
    {

        public static List<Pawn> BlackPawnsAlive { get; set; }
        public static List<Pawn> WhitePawnsAlive { get; set; }

        //Colors
        public static PawnColor ChooseColor()
        {
            int number;

            do
            {
                Console.WriteLine("Enter the Color You Want\n1) Black\n2) White");

                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (number == 1 || number == 2)
                        break;
                    else
                        Console.WriteLine("Please Choose One Of The Colors By Choosing 1 or 2");
                }

                else
                    Console.WriteLine("Sorry, That's Not a Number\nPlease Try Again...");

            } while (number != 1 || number != 2);


            return number == 1 ? PawnColor.Black : PawnColor.White;
        }

        public static PawnColor ChangeTheColor(PawnColor currentTurn)
        {
            return currentTurn == PawnColor.Black ? PawnColor.White : PawnColor.Black;
        }


        public static Board CreateBoard(PawnColor player1color)
        {
            Console.WriteLine($"\nYou Chose {player1color}\n");

            Board board = new Board(player1color);

            for (int y = 0; y < 3; y++)
            {
                //Setting The Pawns On The Black Tiles
                // Even Rows = x % 2 == y % 2 == 0
                // Odd Rows = x % 2 == y % 2 != 0

                for (int x = y % 2; x < board.Tiles.GetLength(1); x++)
                {
                    if (y % 2 == x % 2)
                    {
                        board.Tiles[y, x] = new Pawn { Color = PawnColor.Black };
                        BlackPawnsAlive.Add(board.Tiles[y, x]);
                    }
                    else
                        board.Tiles[y, x] = null;
                }
            }

            //Setting Player2 On The Board

            for (int y = 5; y < board.Tiles.GetLength(0); y++)
            {
                //Setting The Pawns On The Black Tiles
                // Even Rows = x % 2 == y % 2 == 0
                // Odd Rows = x % 2 == y % 2 != 0

                for (int x = y % 2; x < board.Tiles.GetLength(1); x += 2)
                {
                    if (y % 2 == x % 2)
                    {
                        board.Tiles[y, x] = new Pawn { Color = PawnColor.White };
                        WhitePawnsAlive.Add(board.Tiles[y, x]);
                    }
                    else
                        board.Tiles[y, x] = null;
                }
            }

            return board;
        }

        //Player Input
        public static Input GetPlayerInput(Board board,PawnColor currentColorTurn)
        {
            Input playerinput = new Input();

            Console.WriteLine($"Enter Your Input {currentColorTurn} : ");

            Console.WriteLine("Enter The Location Of The Pawn You Want To Move With");

            //Setting The Starting Point
            playerinput.StartingPoint = GetPoint(board.Tiles.GetLength(0));

            Console.WriteLine("Enter The Location You Want To Move To With Your Pawn");

            //Setting The Ending Point
            playerinput.EndPoint = GetPoint(board.Tiles.GetLength(0));

            return playerinput;
        }


        public static Point GetPoint(int border)
        {
            //Setting The Point to -1, -1 to Keep Looping if the computer doesn't catch an Exception in int.TryParse!!!
            Point point = new Point { Width = -1, Height = 1 };

            do
            {
                Console.WriteLine("\nEnter Y Location:");

                if (int.TryParse(Console.ReadLine(), out int height) == false)
                {
                    Console.WriteLine("\nSorry,That's Not a Number...\n");
                    continue;
                }

                Console.WriteLine("\nEnter X Location:");

                if (int.TryParse(Console.ReadLine(), out int width) == false)
                {
                    Console.WriteLine("\nSorry,That's Not a Number...\n");
                    continue;
                }

                point.Width = width;
                point.Height = height;

            } while (ValidationInput.IsInTheBordersOfTheBoard(point, border) == false);


            return point;
        }



        //Exit???
        public static bool ExitGame()
        {
            char exit;

            do
            {
                Console.WriteLine("Do You Want To Exit? (Y/N)");

                if (char.TryParse(Console.ReadLine(), out exit))
                {
                    if (exit == 'Y' || exit == 'y' || exit == 'N' || exit == 'n')
                        break;
                    else
                        Console.WriteLine("Please Enter Y or N");
                }
                else
                    Console.WriteLine("Sorry,That's Not a Letter\nPlease Try Again...");

            } while (exit != 'Y' || exit != 'y' || exit != 'N' || exit != 'n');


            if (exit == 'Y' | exit == 'y')
                return true;

            return false;
        }




        /*public static bool IsTherePawnAround(Board board,Point start, PawnColor currentTurn, int direction)
        {
            //Checking If There Is a Pawn that can be eaten around the pawn who already ate one pawn
 
            var tempPoint = new Point { Width = start.Width + direction, Height = start.Height + direction };

            if (ValidationInput.IsInTheBordersOfTheBoard(tempPoint, board.Tiles.GetLength(0)) == false) return false;


        }*/

        //Display The Board
        public static void DisplayBoard(Board board, PawnColor currentTurn)
        {
            if (currentTurn == PawnColor.Black)
                DisplayBoardWhiteFirst(board);

            else
                DisplayBoardBlackFirst(board);
        }

        private static void DisplayBoardBlackFirst(Board board)
        {
            for (int y = 0; y < board.Tiles.GetLength(0); y++)
            {
                for (int i = 0; i < 15; Console.Write(" "), i++) ;
                Console.Write("|");

                for (int x = 0; x < board.Tiles.GetLength(1); x++)
                {
                    if (board.Tiles[y, x] != null)
                    {
                        if (board.Tiles[y, x].Color == PawnColor.Black)
                        {
                            if (board.Tiles[y, x].Type == PawnType.Last)
                                Console.Write(" BL |");

                            else if (board.Tiles[y, x].Type == PawnType.King)
                                Console.Write(" BK |");

                            else
                                Console.Write(" B |");
                        }

                        else
                        {
                            if (board.Tiles[y, x].Type == PawnType.Last)
                                Console.Write(" WL |");

                            else if (board.Tiles[y, x].Type == PawnType.King)
                                Console.Write(" WK |");

                            else
                                Console.Write(" W |");
                        }
                    }

                    else
                        Console.Write("   |");
                }

                Console.WriteLine($" {y}");

                for (int i = 0; i < 15; Console.Write(" "), i++) ;

                for (int j = 0; j < 33; j++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 15; Console.Write(" "), i++) ;

            for (int i = 0; i < board.Tiles.GetLength(1); i++)
            {
                Console.Write($"  {i} ");
            }
            Console.Write(" <- X");
            Console.WriteLine("\n");
        }

        private static void DisplayBoardWhiteFirst(Board board)
        {
            for (int y = board.Tiles.GetLength(0) - 1; y > -1; y--)
            {
                for (int i = 0; i < 15; Console.Write(" "), i++) ;
                Console.Write("|");

                for (int x = board.Tiles.GetLength(1) - 1; x > -1; x--)
                {
                    if (board.Tiles[y, x] != null)
                    {
                        if (board.Tiles[y, x].Color == PawnColor.White)
                        {
                            if (board.Tiles[y, x].Type == PawnType.Last)
                                Console.Write(" WL |");

                            else if (board.Tiles[y, x].Type == PawnType.King)
                                Console.Write(" WK |");

                            else
                                Console.Write(" W |");
                        }

                        else
                        {
                            if (board.Tiles[y, x].Type == PawnType.Last)
                                Console.Write(" BL |");

                            else if (board.Tiles[y, x].Type == PawnType.King)
                                Console.Write(" BK |");

                            else
                                Console.Write(" B |");
                        }
                    }

                    else
                        Console.Write("   |");
                }

                Console.WriteLine($" {y}");

                for (int i = 0; i < 15; Console.Write(" "), i++) ;

                for (int j = 0; j < 33; j++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 15; Console.Write(" "), i++) ;

            for (int i = board.Tiles.GetLength(0) - 1; i > -1; i--)
            {
                Console.Write($"  {i} ");
            }
            Console.Write(" <- X");
            Console.WriteLine("\n");
        }

    }
}
