using Checkers.Model;
using Checkers.Model.Pawns;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using PawnColor = Checkers.Model.Enums.PawnColor;
using PawnType = Checkers.Model.Enums.PawnType;

namespace Checkers.DataBase_Handler
{
    public class ConvertBoardEntitiesToBoard
    {
        public static Board ConvertFromListToBoard(List<BoardTile> boardTiles)
        {
            var currentTurn = GetCurrentTurn(boardTiles[0].GameId);

            if (currentTurn == 0) return null;

            Board board = new Board((PawnColor)currentTurn);

            foreach (var tile in boardTiles)
            {

                if(board.Tiles[tile.Height,tile.Width].Type == PawnType.King)
                    board.Tiles[tile.Height, tile.Width] = new PawnKing { Color = (PawnColor)tile.ColorId };


                else if(board.Tiles[tile.Height, tile.Width].Type == PawnType.Last)
                    board.Tiles[tile.Height, tile.Width] = new LastPawn { Color = (PawnColor)tile.ColorId };


                else
                    board.Tiles[tile.Height, tile.Width] = new Pawn { Color = (PawnColor)tile.ColorId };

            }

            return board;
        }


        public static List<BoardTile> ConvertFromBoardToList(Board board, Guid gameId)
        {
            if (board == null || gameId == Guid.Empty) return null;

            List<BoardTile> boardList = new List<BoardTile>();

            for (int y = 0; y < board.Tiles.GetLength(0); y++)
            {
                for (int x = 0; x < board.Tiles.GetLength(1); x++)
                {
                    boardList.Add(new BoardTile
                    {
                        Width = x,
                        Height = y,
                        ColorId = (int)board.Tiles[y, x].Color,
                        TypeId = (int)board.Tiles[y, x].Type,
                        GameId = gameId
                    }
                  );
                }
            }
            return boardList;
        }


        private static int GetCurrentTurn(Guid gameId)
        {
            using (CheckersDBEntities db = new CheckersDBEntities())
            {
                try
                {
                    var currentTurn = db.GameManagments.Where(c => c.GameId == gameId).First().CurrentColorTurn;
                    return currentTurn;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}
