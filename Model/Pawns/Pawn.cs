using Checkers.Model.Enums;

namespace Checkers.Model.Pawns
{
    public class Pawn
    {
        public PawnColor Color { get; set; }
        public virtual PawnType Type => PawnType.Pawn;
    }
}
