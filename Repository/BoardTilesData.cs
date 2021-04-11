using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class BoardTilesData
    {
        public static List<BoardTile> GetData(Guid gameId)
        {
            using (CheckersDBEntities db = new CheckersDBEntities())
            {
                try
                {
                    var boardTiles = db.BoardTiles.Where(b => b.GameId == gameId);

                    if (boardTiles.Any() == false) return null;

                    return boardTiles.ToList();
                }
                catch
                { }
            }
            return null;
        }

        public static bool InsertData(List<BoardTile> boardTiles)
        {
            if (DeleteData(boardTiles[0].GameId) == false) return false;

            using (CheckersDBEntities db = new CheckersDBEntities())
            {
                try
                {
                    foreach (var tile in boardTiles)
                    {
                        db.BoardTiles.Add(tile);
                        db.SaveChanges();
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        private static bool DeleteData(Guid gameId)
        {
            using (CheckersDBEntities db = new CheckersDBEntities())
            {
                try
                {
                    var query = from Tiles in db.BoardTiles
                                where Tiles.GameId == gameId
                                select Tiles;

                    foreach (var tile in query)
                    {
                        db.BoardTiles.Remove(tile);
                    }
                    db.SaveChanges();
                    Console.WriteLine("Deleted");
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
    }
}
