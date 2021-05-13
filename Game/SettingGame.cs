using Checkers.DataBase_Handler;
using Checkers.Model;
using Checkers.Model.Enums;
using Checkers.Model.Pawns;
using System;
using System.Collections.Generic;

namespace Checkers.Game
{
    public class SettingGame
    {

        public static List<Pawn> BlackPawnsAlive { get; set; } = new List<Pawn>();
        public static List<Pawn> WhitePawnsAlive { get; set; } = new List<Pawn>();
        private static string SavedGameName { get; set; } = "";

        //Board
        public static Board GetBoard(int choice)
        {
            if (choice == 1)
                return CreateBoard(Colors.ChooseColor());

            return LoadGame();
        }

        private static Board CreateBoard(PawnColor player1color)
        {
            BlackPawnsAlive = new List<Pawn>();
            WhitePawnsAlive = new List<Pawn>();

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


        //Save\Load Game
        public static bool SaveGame(Board board)
        {
            while (true)
            {
                Console.WriteLine("Do You Want To Save Your Game (Y/N)?");

                var cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.Y)
                {
                    SaveTheNameOfTheGame(board);
                    return true;
                }

                if (cki.Key == ConsoleKey.N)
                    return false;

                else
                    Console.WriteLine("Please Enter Y or N");
            }
        }

        private static void SaveTheNameOfTheGame(Board board)
        {
            string nameOfSavedGame;
            do
            {
                if (string.IsNullOrEmpty(SavedGameName) == false)
                {
                    Console.WriteLine("You will Overwrite Your Save!");
                    nameOfSavedGame = SavedGameName;
                }
                else
                {
                    Console.WriteLine("Enter The Name You want to save to");
                    nameOfSavedGame = Console.ReadLine();
                }
            }
            while (DataBaseHandler.InsertTheSavedGame(board, nameOfSavedGame) == false);
        }

        private static Board LoadGame()
        {
            Console.WriteLine("\nLoading...");

            List<string> listOfSavedGamesNames = DataBaseHandler.GetTheListOfSavedGames();

            if (listOfSavedGamesNames.Count == 0)
            {
                Console.WriteLine("\nSorry, There aren't Load Games...\n");
                return CreateBoard(Colors.ChooseColor());
            }

            return ChooseTheSavedGame(listOfSavedGamesNames);
        }

        private static Board ChooseTheSavedGame(List<string> listOfSavedGamesNames)
        {
            while (true)
            {
                Console.WriteLine("\nPlease Choose One Of the Loaded Games...\n");

                int index = 1;
                foreach (var name in listOfSavedGamesNames)
                {
                    Console.WriteLine($"{index++}) {name}");
                }

                var cki = Console.ReadKey(true);

                if (int.TryParse(cki.KeyChar.ToString(), out int choice) == true)
                {
                    if (choice < 1 || choice > listOfSavedGamesNames.Count)
                    {
                        Console.Clear();
                        Console.WriteLine("\nYou didn't chose one of the loaded games\nPlease Try Again...");
                    }

                    else
                    {
                        //Saving The Name Of The Saved Game that the User Chose
                        SavedGameName = listOfSavedGamesNames[choice - 1];

                        return DataBaseHandler.GetTheSavedGame(listOfSavedGamesNames[choice - 1]);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nSorry, That's Not a Number\nPlease Try Again...");
                }
            }
        }
    }
}
