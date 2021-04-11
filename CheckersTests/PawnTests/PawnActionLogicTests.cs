using Checkers.Logic;
using Checkers.Model;
using Checkers.Model.Enums;
using Checkers.Model.Pawns;
using Checkers.Model.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class PawnActionLogicTests
    {
        private IPawnActionLogic _pawnActionLogic;
        [TestInitialize]
        public void Init()
        {
            _pawnActionLogic = new PawnActionLogic();
        }

        [TestMethod]
        public void WhenBoardIsEmptyThenMoveIsAllowedBlackPawn()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 0,
                    Height = 0
                },
                EndPoint = new Point
                {
                    Width = 1,
                    Height = 1
                }
            };
            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };
            // Act
            var result = _pawnActionLogic.Move(input, board);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenBoardIsEmptyThenMoveIsAllowedWhitePawn()
        {
            // Arrange 
            var board = new Board(PawnColor.White);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 1,
                    Height = 7
                },
                EndPoint = new Point
                {
                    Width = 0,
                    Height = 6
                }
            };
            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };
            // Act
            var result = _pawnActionLogic.Move(input, board);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenEndPointIsNotOnTheDiagonalThenMoveIsNotAllowedBlackPawn()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);
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
            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };
            // Act
            var result = _pawnActionLogic.Move(input, board);
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenEndPointIsNotOnTheDiagonalThenMoveIsNotAllowedWhitePawn()
        {
            // Arrange 
            var board = new Board(PawnColor.White);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 1,
                    Height = 7
                },
                EndPoint = new Point
                {
                    Width = 3,
                    Height = 7
                }
            };
            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };
            // Act
            var result = _pawnActionLogic.Move(input, board);
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenDiagonalIsNotEmptyThenMoveIsNotAllowed()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 0,
                    Height = 0
                },
                EndPoint = new Point
                {
                    Width = 1,
                    Height = 1
                }
            };
            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };
            board.Tiles[input.EndPoint.Height, input.EndPoint.Width] = new Pawn { Color = PawnColor.White };
            // Act
            var result = _pawnActionLogic.Move(input, board);
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
                    Height = 1
                },
                EndPoint = new Point
                {
                    Width = 2,
                    Height = 0
                }
            };
            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };
            // Act
            var result = _pawnActionLogic.Move(input, board);
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
            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };
            // Act
            var result = _pawnActionLogic.Move(input, board);
            // Assert
            Assert.IsFalse(result);
        }
    }
}
