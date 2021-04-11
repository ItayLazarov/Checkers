using Checkers.Model.Enums;
using Checkers.Model.Pawns;

namespace Checkers.Model
{
    public class Board
    {
        public Pawn[,] Tiles { get; set; }
        public PawnColor CurrentTurn { get; set; }

        public Board(PawnColor currentTurn)
        {
            Tiles = new Pawn[8, 8];
            CurrentTurn = currentTurn;
        }
    }
}
