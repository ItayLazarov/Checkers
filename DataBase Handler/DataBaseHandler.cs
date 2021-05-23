using Checkers.Model;
using Repository;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace Checkers.DataBase_Handler
{
    public class DataBaseHandler
    {
        public static Board GetTheSavedGame(string nameOfTheSavedGame)
        {
            //Get the Game Id Of The Game (Guid)
            var gameId = GameManagmentData.GetData(nameOfTheSavedGame);

            if (gameId == Guid.Empty)
            {
                Console.WriteLine("Guid is Empty");
                return null;
            }

            //Get The List Of The Board Tiles Of The Game (List<BoardTile>)
            var boardList = BoardTilesData.GetData(gameId);

            if (boardList.Count == 0)
            {
                Console.WriteLine("The List is Null");
                return null;
            }

            return ConvertBoardEntitiesToBoard.ConvertFromListToBoard(boardList);
        }

        public static List<string> GetTheListOfSavedGames()
        { 
            using(CheckersDBEntities db = new CheckersDBEntities())
            {
                var names = from Names in db.GameManagments
                            select Names.Name;

                return names.ToList();
            }
        }

        public static bool InsertTheSavedGame(Board board, string nameOfTheSavedGame)
        {
            var currentTurn = Convert.ToInt32(board.CurrentTurn);

            var gameId = GameManagmentData.InsertData(nameOfTheSavedGame, currentTurn);

            var convertedListOfTheBoard = ConvertBoardEntitiesToBoard.ConvertFromBoardToList(board, gameId);

            return BoardTilesData.InsertData(convertedListOfTheBoard);

            //return BoardTilesData.InsertData(
            //    ConvertBoardEntitiesToBoard.ConvertFromBoardToList(board, GameManagmentData.InsertData(
            //    nameOfTheSavedGame, currentTurn)
            //  )
            //); 
        }
    }
}
