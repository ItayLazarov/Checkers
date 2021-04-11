using Checkers.Model;
using Repository;
using System;

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

            if (boardList == null)
            {
                Console.WriteLine("The List is Null");
                return null;
            }

            return ConvertBoardEntitiesToBoard.ConvertFromListToBoard(boardList);
        }

        public static bool InsertTheSavedGame(Board board, string nameOfTheSavedGame)
        {
            var currentTurn = Convert.ToInt32(board.CurrentTurn);

            return BoardTilesData.InsertData(
                ConvertBoardEntitiesToBoard.ConvertFromBoardToList(board, GameManagmentData.InsertData(
                nameOfTheSavedGame, currentTurn)
              )
            ); 
        }
    }
}
