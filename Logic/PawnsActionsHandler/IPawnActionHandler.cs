using Checkers.Model;
using Checkers.Model.Request;

namespace Checkers.Logic.PawnsActionsHandler
{
    public interface IPawnActionHandler
    {
        bool TryMove(Input input, Board board);

        bool TryFirstEat(Input input, Board board);

        bool TryNextEat(Input input, Board board);
    }
}
