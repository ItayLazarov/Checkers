using Checkers.Model;
using Checkers.Model.Enums;
using System;

namespace Checkers.Game
{
    public class DisplayBoard
    {
        public static void Display(Board board)
        {
            if (board.CurrentTurn == PawnColor.Black)
                DisplayBoardWhiteFirst(board);

            else
                DisplayBoardBlackFirst(board);
        }

        private static void DisplayBoardBlackFirst(Board board)
        {
            for (int y = 0; y < board.Tiles.GetLength(0); y++)
            {
                for (int i = 0; i < 15; Console.Write(" "), i++) ;

                Colors.ColorOfTheColumns();

                for (int x = 0; x < board.Tiles.GetLength(1); x++)
                {
                    if (board.Tiles[y, x] != null)
                    {
                        if (board.Tiles[y, x].Color == PawnColor.Black)
                        {
                            if (board.Tiles[y, x].Type == PawnType.Last)
                                Console.Write("BL ");

                            else if (board.Tiles[y, x].Type == PawnType.King)
                                Console.Write("BK ");

                            else
                                Console.Write(" B ");
                        }

                        else
                        {
                            if (board.Tiles[y, x].Type == PawnType.Last)
                                Console.Write("WL ");

                            else if (board.Tiles[y, x].Type == PawnType.King)
                                Console.Write("WK ");

                            else
                                Console.Write(" W ");
                        }
                    }

                    else
                        Console.Write("   ");

                    Colors.ColorOfTheColumns();
                }

                Console.WriteLine($" {y}");

                for (int i = 0; i < 15; Console.Write(" "), i++) ;

                Colors.ColorOfTheRows();
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

                Colors.ColorOfTheColumns();

                for (int x = board.Tiles.GetLength(1) - 1; x > -1; x--)
                {
                    if (board.Tiles[y, x] != null)
                    {
                        if (board.Tiles[y, x].Color == PawnColor.White)
                        {
                            if (board.Tiles[y, x].Type == PawnType.Last)
                                Console.Write("WL ");

                            else if (board.Tiles[y, x].Type == PawnType.King)
                                Console.Write("WK ");

                            else
                                Console.Write(" W ");
                        }

                        else
                        {
                            if (board.Tiles[y, x].Type == PawnType.Last)
                                Console.Write("BL ");

                            else if (board.Tiles[y, x].Type == PawnType.King)
                                Console.Write("BK ");

                            else
                                Console.Write(" B ");
                        }
                    }

                    else
                        Console.Write("   ");

                    Colors.ColorOfTheColumns();
                }

                Console.WriteLine($" {y}");

                for (int i = 0; i < 15; Console.Write(" "), i++) ;

                Colors.ColorOfTheRows();
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
