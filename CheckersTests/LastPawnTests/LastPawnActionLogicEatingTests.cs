using Checkers.Logic;
using Checkers.Model;
using Checkers.Model.Enums;
using Checkers.Model.Pawns;
using Checkers.Model.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTest
{
    [TestClass]
    public class LastPawnActionLogicEatingTests
    {
        private IPawnActionLogic _lastPawnActionLogic;

        [TestInitialize]
        public void Init()
        {
            _lastPawnActionLogic = new LastPawnActionLogic();
        }

        [TestMethod]

        public void WhenBoardIsEmptyLastPawnCantEat()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyLastPawnCantEat2()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 1,
                    Height = 1
                },
                EndPoint = new Point
                {
                    Width = 0,
                    Height = 0
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyLastPawnCantEat3()
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
                    Width = 1,
                    Height = 3
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyLastPawnCantEat4()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullLastPawnCanEat()
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
                    Width = 2,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };

            board.Tiles[0, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsFullLastPawnCanEat2()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 2,
                    Height = 0
                },
                EndPoint = new Point
                {
                    Width = 0,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };

            board.Tiles[0, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsFullLastPawnCanEat3()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 1,
                    Height = 3
                },
                EndPoint = new Point
                {
                    Width = 3,
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };

            board.Tiles[0, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[4, 2] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsFullLastPawnCanEat4()
        {
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
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };

            board.Tiles[7, 3] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 2] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsFullLastPawnCanEat5()
        {
            var board = new Board(PawnColor.Black);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 3,
                    Height = 7
                },
                EndPoint = new Point
                {
                    Width = 5,
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };

            board.Tiles[7, 1] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 4] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsFullLastPawnCanEat6()
        {
            var board = new Board(PawnColor.Black);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 3,
                    Height = 7
                },
                EndPoint = new Point
                {
                    Width = 1,
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };

            board.Tiles[7, 1] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 2] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsFullLastPawnCantEat()
        {
            var board = new Board(PawnColor.Black);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 2,
                    Height = 2
                },
                EndPoint = new Point
                {
                    Width = 0,
                    Height = 0
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };

            board.Tiles[0, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            board.Tiles[0, 0] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullLastPawnCantEat2()
        {
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
                    Width = 2,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };

            board.Tiles[0, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            board.Tiles[2, 2] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullLastPawnCantEat3()
        {
            var board = new Board(PawnColor.Black);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 2,
                    Height = 0
                },
                EndPoint = new Point
                {
                    Width = 2,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };

            board.Tiles[0, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            board.Tiles[2, 2] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullLastPawnCantEat4()
        {
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };

            board.Tiles[7, 3] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 0] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullLastPawnCantEat5()
        {
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
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };

            board.Tiles[7, 3] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[5, 3] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullLastPawnCantEat6()
        {
            var board = new Board(PawnColor.Black);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 3,
                    Height = 7
                },
                EndPoint = new Point
                {
                    Width = 1,
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };

            board.Tiles[7, 1] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[5, 1] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullLastPawnCantEat7()
        {
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
                    Width = 1,
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };

            board.Tiles[7, 1] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[5, 1] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullLastPawnCantEat8()
        {
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
                    Width = 5,
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };

            board.Tiles[7, 1] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[5, 5] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _lastPawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
