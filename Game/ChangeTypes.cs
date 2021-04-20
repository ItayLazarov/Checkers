using Checkers.Model;
using Checkers.Model.Enums;
using Checkers.Model.Pawns;
using System.Collections.Generic;

namespace Checkers.Game
{
    public class ChangeTypes
    {
        public static void ChangeTheTypes(Board board)
        {
            CheckIfThereIsaKing(board);

            /*if(currentColor == PawnColor.Black)
                if(SettingGame.BlackPawnsAlive.Count == 1)
                    ChangeToLastPawnType(board, currentColor);

            else
                if(SettingGame.WhitePawnsAlive.Count == 1)
                    ChangeToLastPawnType(board, currentColor);*/

            if(SettingGame.BlackPawnsAlive.Count == 1 || SettingGame.WhitePawnsAlive.Count == 1)
                ChangeToLastPawnType(board);

        }


        private static void CheckIfThereIsaKing(Board board)
        {
            //Change To King Type

            //If The Current Color Is Black - The Pawn Who Can Become a King Must have To be In The Last Row Of The Board

            //If The Current Color Is White - The Pawn Who Can Become a King Must have To be In The First Row Of The Board

            var y = board.CurrentTurn == PawnColor.Black ? 7 : 0;


            for (int x = y % 2 == 0 ? 0 : 1; x < board.Tiles.GetLength(1); x += 2)
            {
                //Check if There is a King In The First/Last Row of The Board
                if (board.Tiles[y, x] != null && board.Tiles[y, x].Color == board.CurrentTurn)
                    board.Tiles[y, x] = new PawnKing { Color = board.CurrentTurn };

            }
        }

        private static void ChangeToLastPawnType(Board board)
        {
            for (int y = 0; y < board.Tiles.GetLength(0); y++)
            {
                for (int x = y % 2 == 0 ? 0 : 1; x < board.Tiles.GetLength(1); x += 2)
                {
                    if (board.Tiles[y, x].Color == board.CurrentTurn)
                        board.Tiles[y, x] = new LastPawn { Color = board.CurrentTurn };
                }
            }
        }
    }
}
