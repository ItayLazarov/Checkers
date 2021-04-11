using Checkers.Model;
using Checkers.Model.Request;

namespace Checkers.Logic.PawnsActionsUtillities
{
    public class LastPawnActionUtillities
    {
        public static bool CheckMove(Input input, Board board)
        {
            if (ValidationInput.IsValidInput(input, board) == false) return false;

            if (input.EndPoint.Width != input.StartingPoint.Width +
                PawnActionUtillities.CreateDirectionToMove(input.StartingPoint.Width, input.EndPoint.Width)) return false;

            if (input.EndPoint.Height != input.StartingPoint.Height +
                PawnActionUtillities.CreateDirectionToMove(input.StartingPoint.Height, input.EndPoint.Height)) return false;

            return true;
        }

        public static bool FirstMovementToEat(Input input, Board board)
        {
            if (ValidationInput.IsValidInput(input, board) == false) return false;

            var _moveX = PawnActionUtillities.CreateDirectionToMove(input.StartingPoint.Width, input.EndPoint.Width);
            var _moveY = PawnActionUtillities.CreateDirectionToMove(input.StartingPoint.Height, input.EndPoint.Height);

            //It Can Only Move 2 Tiles if it Wants To Eat!!!!

            //Position of the Pawn that will be Eaten
            var _width = input.StartingPoint.Width + _moveX;
            var _height = input.StartingPoint.Height + _moveY;

            //Checking If there is a Pawn in the Tile
            if (board.Tiles[_height, _width] == null) return false;

            //Checking If the Pawn's color is different
            if (board.Tiles[_height, _width].Color == board.CurrentTurn) return false;

            _width += _moveX;
            _height += _moveY;

            if (board.Tiles[_height, _width] != null) return false;

            return _width == input.EndPoint.Width && _height == input.EndPoint.Height;
        }
    }
}
