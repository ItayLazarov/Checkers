using Checkers.Model;
using Checkers.Model.Enums;
using Checkers.Model.Request;
using System.Collections.Generic;

namespace Checkers.Logic.PawnsActionsHandler
{
    public class PawnActionHandler : IPawnActionHandler
    {
        private Dictionary<PawnType, IPawnActionLogic> _mapper;

        public PawnActionHandler()
        {
            //Arranging All Of The Logic Functions Of The Pawns With The Pawn Type (Enum)
            //To Add New Pawns To The Game, You'll Just Add Them In The Enum (Pawn Type) , And The Logic Functions Of The Pawn

            _mapper = new Dictionary<PawnType, IPawnActionLogic>
            {
                {PawnType.Pawn , new PawnActionLogic() },
                {PawnType.King , new KingActionLogic() },
                {PawnType.Last, new LastPawnActionLogic() }
            };
        }

        // The Pawn Var Gets The Pawn Object From The Board. The Object Inherit The Pawn Type From The Base Class (Pawn) = Public Virtual PawnType type
        // The Key Is The Pawn Type (Enum) From The Pawn (Class) That As Pawn Type (Property) , And Matching it With The Value From The Dictionary

        public bool TryMove(Input input, Board board)
        {
            var pawn = board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width];
            if (pawn == null) return false;
            return _mapper[pawn.Type].Move(input, board);
        }

        public bool TryFirstEat(Input input, Board board)
        {
            var pawn = board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width];
            if (pawn == null) return false;
            return _mapper[pawn.Type].FirstMovementToEat(input, board);
        }

        public bool TryNextEat(Input input, Board board)
        {
            var pawn = board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width];
            if (pawn == null) return false;
            return _mapper[pawn.Type].Eat(input, board);
        }
    }
}
