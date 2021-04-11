using Checkers.Logic.PawnsActionsUtillities;
using Checkers.Model;
using Checkers.Model.Request;

namespace Checkers.Logic
{
    public class LastPawnActionLogic : IPawnActionLogic
    {
        public bool Move(Input input, Board board)
        {
            return LastPawnActionUtillities.CheckMove(input, board);
        }

        public bool Eat(Input input, Board board)
        {
            return PawnActionUtillities.IsValidToEat(input, board);
        }

        public bool FirstMovementToEat(Input input, Board board)
        {
            return LastPawnActionUtillities.FirstMovementToEat(input, board);
        }
    }
}
