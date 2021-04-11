using Checkers.Model;
using Checkers.Model.Request;

namespace Checkers.Logic.PawnsActionsUtillities
{
    public class KingActionUtillities
    {
        //Move
        public static bool CheckMove(Input input, Board board)
        {
            if (ValidationInput.IsValidInput(input, board) == false) return false;

            var _move_Pawn_X = PawnActionUtillities.CreateDirectionToMove(input.StartingPoint.Width, input.EndPoint.Width);
            var _move_Pawn_Y = PawnActionUtillities.CreateDirectionToMove(input.StartingPoint.Height, input.EndPoint.Height);

            return CheckDiagonal(input, board, _move_Pawn_X, _move_Pawn_Y);
        }

        private static bool CheckDiagonal(Input input, Board board, int _move_Pawn_X, int _move_Pawn_Y)
        {
            var _width = input.StartingPoint.Width;
            var _height = input.StartingPoint.Height;

            while (_width != input.EndPoint.Width && _height != input.EndPoint.Height)
            {
                _width += _move_Pawn_X;
                _height += _move_Pawn_Y;

                if (board.Tiles[_height, _width] != null) return false;
            }
            return _width == input.EndPoint.Width && _height == input.EndPoint.Height;
        }

        private static Input CreateMovingInput(Input input, int moveX, int moveY)
        {
            //Getting The Starting Point Of The Pawn
            return new Input
            {
                StartingPoint = input.StartingPoint,
                //Getting The Last Tile !!Before!! The Pawn We Want To Eat As The End Point = (moveX / moveY) * 2 (steps)
                EndPoint = new Point { Width = input.EndPoint.Width - (moveX * 2), Height = input.EndPoint.Height - (moveY * 2) }
            };
        }

        //Eat

        public static bool FirstMovementToEat(Input input, Board board)
        {
            if (ValidationInput.IsValidInput(input, board) == false) return false;

            var move_Pawn_X = PawnActionUtillities.CreateDirectionToMove(input.StartingPoint.Width, input.EndPoint.Width);
            var move_Pawn_Y = PawnActionUtillities.CreateDirectionToMove(input.StartingPoint.Height, input.EndPoint.Height);

            //Represents The Tile Before The Pawn It Wants To Eat
            var movingInput = CreateMovingInput(input, move_Pawn_X, move_Pawn_Y);

            //Move King Until It Reaches To The Pawn It Wants To Eat
            if (CheckDiagonal(movingInput, board, move_Pawn_X, move_Pawn_Y) == false) return false;

            //Position Of The Pawn That Will be Eaten
            movingInput.EndPoint.Width += move_Pawn_X;
            movingInput.EndPoint.Height += move_Pawn_Y;

            //Is There A Pawn In This Tile?
            if (board.Tiles[movingInput.EndPoint.Height, movingInput.EndPoint.Width] == null) return false;

            //Checking If the Pawn We Want To Eat isn't the same color!!
            return board.Tiles[movingInput.EndPoint.Height, movingInput.EndPoint.Width].Color != board.CurrentTurn;
        }
    }
}
