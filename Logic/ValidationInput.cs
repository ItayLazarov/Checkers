using Checkers.Model;
using Checkers.Model.Request;

namespace Checkers.Logic
{
    public static class ValidationInput
    {
        public static bool IsValidInput(Input input, Board board)
        {
            // In This Check the Board Has to be a square board : X == Y
            // len(X) == len(Y)
            var len = board.Tiles.GetLength(0);

            if (IsValidPoint(input.StartingPoint, len) == false || IsValidPoint(input.EndPoint, len) == false)
                return false;

            //If There Is a Pawn In The Tile Where The Player Wants To Move
            return board.Tiles[input.EndPoint.Height, input.EndPoint.Width] == null;
        }

        private static bool IsValidPoint(Point point, int border)
        {
            //If The Input Is In The Borders Of The Board
            return IsInTheBordersOfTheBoard(point, border) && IsValidTile(point);
        }

        private static bool IsValidTile(Point point)
        {
            // Even Rows = x % 2 == y % 2 == 0
            // Odd Rows = x % 2 == y % 2 != 0
            // The Black Tiles Positions(X,Y) On The Board will be : X % 2 == Y % 2
            // We Check If The Starting Point and The End Point will be on the Position(X,Y) of Black Tiles
            return point.Width % 2 == point.Height % 2;
        }

        public static bool IsInTheBordersOfTheBoard(Point point, int border)
        {
            return point.Width >= 0 && point.Width < border && point.Height >= 0 && point.Height < border;
        }
    }
}
