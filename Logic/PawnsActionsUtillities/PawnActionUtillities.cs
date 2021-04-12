using Checkers.Game;
using Checkers.Model;
using Checkers.Model.Enums;
using Checkers.Model.Request;
using System;
using System.Collections.Generic;

namespace Checkers.Logic.PawnsActionsUtillities
{
    public class PawnActionUtillities
    {
        //Moving The Pawn
        public static bool MoveOnce(Input input, Board board)
        {
            if (ValidationInput.IsValidInput(input, board) == false) return false;

            //Can The Pawn Move?

            var directions = new Dictionary<PawnColor, int> { { PawnColor.Black, 1 }, { PawnColor.White, -1 } };

            return input.EndPoint.Height == input.StartingPoint.Height + directions[board.CurrentTurn]
                && Math.Abs(input.EndPoint.Width - input.StartingPoint.Width) == 1;
        }


        //Eating with the Pawn

        public static int CreateDirectionToMove(int start, int end)
        {
            int[] movement = new int[] { 1, -1 };

            //Which Direction The Diagonal will be:
            // Top Right Diagonal = (+X , +Y) 
            // Bottom Right Diagonal = (+X , -Y)
            // Top Left Diagonal = (-X , +Y)       
            // Bottom Left Diagonal = (-X , -Y)

            return end > start ? movement[0] : movement[1];
        }

        public static bool FirstMovementToEat(Input input, Board board)
        {
            if (ValidationInput.IsValidInput(input, board) == false) return false;

            //If The Pawn is Black = Y + 1
            //If the Pawn is White = Y - 1
            var _moveY = board.CurrentTurn == PawnColor.Black ? 1 : -1;

            var _moveX = CreateDirectionToMove(input.StartingPoint.Width, input.EndPoint.Width);

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


        public static bool IsValidToEat(Input input, Board board)
        {
            return LastPawnActionUtillities.FirstMovementToEat(input, board);
        }



        public static void DeletePawn(Input input, Board board)
        {
            var move_Pawn_X = CreateDirectionToMove(input.StartingPoint.Width, input.EndPoint.Width);
            var move_Pawn_Y = CreateDirectionToMove(input.StartingPoint.Height, input.EndPoint.Height);

            var deletedPawn = board.Tiles[input.EndPoint.Height - move_Pawn_Y, input.EndPoint.Width - move_Pawn_X];

            //Delete the Eaten Pawn
            if (deletedPawn.Color == PawnColor.Black)
                PawnsCounter.BlackPawnsAlive.Remove(deletedPawn);
            else
                PawnsCounter.WhitePawnsAlive.Remove(deletedPawn);


            board.Tiles[input.EndPoint.Height - move_Pawn_Y, input.EndPoint.Width - move_Pawn_X] = null;

            //Change The Positions between the Pawns
            board.Tiles[input.EndPoint.Height, input.EndPoint.Width] = board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width];

            //Delete The Starting Position of the Pawn
            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = null;
        }
    }
}
