using Checkers.Logic.PawnsActionsHandler;
using Checkers.Model.Request;

namespace Checkers.Game
{
    public class GamePlay
    {
        private IPawnActionHandler _pawnActionHandler;

        public GamePlay(IPawnActionHandler pawnActionHandler)
        {
            _pawnActionHandler = pawnActionHandler;
        }

        public bool ExecuteTurnMove(PlayerRequest playerRequest)
        {
            return _pawnActionHandler.TryMove(playerRequest.MovementInput, playerRequest.Board);
        }

        public bool ExecuteFirstEatMove(PlayerRequest playerRequest)
        {
            return _pawnActionHandler.TryFirstEat(playerRequest.MovementInput, playerRequest.Board);
        }

        public bool EatingLoop(PlayerRequest playerRequest)
        {
            return _pawnActionHandler.TryNextEat(playerRequest.MovementInput, playerRequest.Board);
        }
    }
}
