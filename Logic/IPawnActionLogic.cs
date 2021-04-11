using Checkers.Model;
using Checkers.Model.Request;

namespace Checkers.Logic
{
    public interface IPawnActionLogic
    {
        bool Move(Input input, Board board);

        bool FirstMovementToEat(Input input, Board board);

        bool Eat(Input input, Board board);
    }
}