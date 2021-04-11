using Checkers.Logic;
using Checkers.Model;
using Checkers.Model.Enums;
using Checkers.Model.Pawns;
using Checkers.Model.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTest
{
    [TestClass]
    public class KingActionLogicTests
    {
        private IPawnActionLogic _kingActionLogic;

        [TestInitialize]
        public void Init()
        {
            _kingActionLogic = new KingActionLogic();
        }

        [TestMethod]
        public void WhenBoardIsEmptyThenMoveIsAllowed()
        {
            // Arrange 
            var board = new Board(PawnColor.White);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 0,
                    Height = 0
                },
                EndPoint = new Point
                {
                    Width = 7,
                    Height = 7
                }
            };
            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };
            // Act
            var result = _kingActionLogic.Move(input, board);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenEndPointIsNotOnTheDiagonalThenMoveIsNotAllowed()
        {
            // Arrange 
            var board = new Board(PawnColor.White);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 0,
                    Height = 0
                },
                EndPoint = new Point
                {
                    Width = 3,
                    Height = 7
                }
            };
            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };
            // Act
            var result = _kingActionLogic.Move(input, board);
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenDiagonalIsNotEmptyThenMoveIsNotAllowed()
        {
            // Arrange 
            var board = new Board(PawnColor.White);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 0,
                    Height = 0
                },
                EndPoint = new Point
                {
                    Width = 7,
                    Height = 7
                }
            };
            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };
            board.Tiles[4, 4] = new Pawn { Color = PawnColor.White };
            // Act
            var result = _kingActionLogic.Move(input, board);
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenStartPointIsOnTheBorderThenIsMoveAllowed()
        {
            // Arrange 
            var board = new Board(PawnColor.White);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 3,
                    Height = 7
                },
                EndPoint = new Point
                {
                    Width = 0,
                    Height = 4
                }
            };
            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };
            // Act
            var result = _kingActionLogic.Move(input, board);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenStartPointIsInvalidThenMoveIsNotAllowed()
        {
            // Arrange 
            var board = new Board(PawnColor.White);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 0,
                    Height = 1
                },
                EndPoint = new Point
                {
                    Width = 2,
                    Height = 3
                }
            };
            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };
            // Act
            var result = _kingActionLogic.Move(input, board);
            // Assert
            Assert.IsFalse(result);
        }
    }
}

