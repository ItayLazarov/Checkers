using Checkers.Model.Pawns;
using System.Collections.Generic;

namespace Checkers.Game
{
    public class PawnsCounter
    {
        public static List<Pawn> BlackPawnsAlive { get; set; } = new List<Pawn>();
        public static List<Pawn> WhitePawnsAlive { get; set; } = new List<Pawn>();
    }
}
