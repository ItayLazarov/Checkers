using System;
using System.Linq;

namespace Repository
{
    public class GameManagmentData
    {
        public static Guid GetData(string nameOfTheSavedGame)
        {
            using (CheckersDBEntities db = new CheckersDBEntities())
            {
                try
                {
                    var gameId = db.GameManagments.Where(g => g.Name == nameOfTheSavedGame).First().GameId;

                    return gameId;
                }
                catch { }
            }
            return Guid.Empty;
        }


        public static Guid InsertData(string nameOfTheSavedGame, int CurrentTurn)
        {
            Guid gameId = new Guid();
            using (CheckersDBEntities db = new CheckersDBEntities())
            {
                try
                {
                    if (CheckIfTheNameIsInTheDataBase(nameOfTheSavedGame))
                    {
                        gameId = db.GameManagments.Where(g => g.Name == nameOfTheSavedGame).First().GameId;
                        db.GameManagments.Where(g => g.Name == nameOfTheSavedGame).First().CurrentColorTurn = CurrentTurn;
                    }

                    else
                    {
                        gameId = Guid.NewGuid();
                        GameManagment newGame = new GameManagment()
                        {
                            Name = nameOfTheSavedGame,
                            CurrentColorTurn = CurrentTurn,
                            GameId = gameId
                        };
                        db.GameManagments.Add(newGame);
                    }

                    db.SaveChanges();

                    return gameId;
                }
                catch
                {
                    return Guid.Empty;
                }
            }
        }


        private static bool CheckIfTheNameIsInTheDataBase(string nameOfTheSavedGame)
        {
            using (CheckersDBEntities db = new CheckersDBEntities())
            {
                try
                {
                    var name = db.GameManagments.Where(g => g.Name == nameOfTheSavedGame).First();
                    return true;
                }
                catch { }
            }
            return false;
        }
    }
}
