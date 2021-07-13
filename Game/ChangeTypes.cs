using Checkers.Model;
using Checkers.Model.Enums;
using Checkers.Model.Pawns;

namespace Checkers.Game
{
    public class ChangeTypes
    {
        public static void ChangeTheTypes(Board board)
        {
            CheckIfThereIsaKing(board);

            if(SettingGame.BlackPawnsAlive.Count == 1)
                ChangeToLastPawnType(board,PawnColor.Black);

            else if(SettingGame.WhitePawnsAlive.Count == 1)
                ChangeToLastPawnType(board, PawnColor.White);

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
                {
                    if(board.CurrentTurn == PawnColor.Black)
                    {
                        SettingGame.BlackPawnsAlive.Remove((board.Tiles[y, x]));
                        SettingGame.BlackPawnsAlive.Add(board.Tiles[y, x] = new PawnKing { Color = board.CurrentTurn });
                    }
                    else
                    {
                        SettingGame.WhitePawnsAlive.Remove((board.Tiles[y, x]));
                        SettingGame.WhitePawnsAlive.Add(board.Tiles[y, x] = new PawnKing { Color = board.CurrentTurn });
                    }
                }
            }
        }

        private static void ChangeToLastPawnType(Board board, PawnColor colorOfTheLastPawn)
        {

            //Because i Check if i need to switch after every turn, but in the end of the loop... the right color will not be the currentColor.

            for (int y = 0; y < board.Tiles.GetLength(0); y++)
            {
                for (int x = y % 2 == 0 ? 0 : 1; x < board.Tiles.GetLength(1); x += 2)
                {
                    if (board.Tiles[y, x] != null && board.Tiles[y, x].Color == colorOfTheLastPawn)
                    {
                        if (board.Tiles[y, x].Type == PawnType.Last)
                            break;

                        else
                        {
                            if(colorOfTheLastPawn == PawnColor.Black)
                            {
                                SettingGame.BlackPawnsAlive.Remove((board.Tiles[y, x]));
                                SettingGame.BlackPawnsAlive.Add(board.Tiles[y, x] = new LastPawn { Color = colorOfTheLastPawn });
                            }

                            else
                            {
                                SettingGame.WhitePawnsAlive.Remove((board.Tiles[y, x]));
                                SettingGame.WhitePawnsAlive.Add(board.Tiles[y, x] = new LastPawn { Color = colorOfTheLastPawn });
                            }
                        }
                    }
                }
            }
        }
    }
}
