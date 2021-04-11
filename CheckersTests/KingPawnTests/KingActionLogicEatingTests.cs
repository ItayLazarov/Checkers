using Checkers.Logic;
using Checkers.Model;
using Checkers.Model.Enums;
using Checkers.Model.Pawns;
using Checkers.Model.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTest
{
    [TestClass]
    public class KingActionLogicEatingTests
    {
        private IPawnActionLogic _kingActionLogic;

        [TestInitialize]
        public void Init()
        {
            _kingActionLogic = new KingActionLogic();
        }

        [TestMethod]

        public void WhenBoardIsEmptyKingCantEat()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyKingCantEat2()
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
                    Height = 1
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyKingCantEat3()
        {
            // Arrange 
            var board = new Board(PawnColor.White);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 7,
                    Height = 7
                },
                EndPoint = new Point
                {
                    Width = 5,
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyKingCantEat4()
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
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyKingCantEat5()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyKingCantEat6()
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
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyKingCantEat7()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyKingCantEat8()
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
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyKingCantEat9()
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
                    Width = 7,
                    Height = 1
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };

            board.Tiles[3, 7] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 5] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyKingCanEat()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };

            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyKingCanEat2()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };

            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyKingCanEat3()
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
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };

            board.Tiles[6, 2] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyKingCanEat4()
        {
            // Arrange 
            var board = new Board(PawnColor.White);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 0,
                    Height = 4
                },
                EndPoint = new Point
                {
                    Width = 4,
                    Height = 0
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };

            board.Tiles[1, 3] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyKingCanEat5()
        {
            // Arrange 
            var board = new Board(PawnColor.White);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 1,
                    Height = 1
                },
                EndPoint = new Point
                {
                    Width = 4,
                    Height = 4
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };

            board.Tiles[3, 3] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyKingCanEat6()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 1,
                    Height = 7
                },
                EndPoint = new Point
                {
                    Width = 7,
                    Height = 1
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };

            board.Tiles[2, 6] = new PawnKing { Color = PawnColor.White };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }



        //When The Board Is Full

        [TestMethod]

        public void WhenBoardIsFullBlackPawnCantEat()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };

            board.Tiles[0, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[6, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            board.Tiles[2, 2] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullBlackPawnCantEat2()
        {
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
                    Width = 2,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };

            board.Tiles[0, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[6, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            board.Tiles[2, 2] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullBlackPawnCantEat3()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };

            board.Tiles[0, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[6, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            board.Tiles[2, 2] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullBlackPawnCantEat4()
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
                    Width = 4,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };

            board.Tiles[0, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[6, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[3, 1] = new Pawn { Color = PawnColor.White };

            board.Tiles[4, 2] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullBlackPawnCantEat5()
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
                    Width = 4,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };

            board.Tiles[0, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[6, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[3, 1] = new Pawn { Color = PawnColor.White };

            board.Tiles[4, 2] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _kingActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
