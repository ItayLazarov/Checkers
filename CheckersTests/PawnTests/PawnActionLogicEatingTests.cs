using Checkers.Logic;
using Checkers.Model;
using Checkers.Model.Enums;
using Checkers.Model.Pawns;
using Checkers.Model.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class PawnActionLogicEatingTests
    {
        private IPawnActionLogic _pawnActionLogic;

        [TestInitialize]
        public void Init()
        {
            _pawnActionLogic = new PawnActionLogic();
        }

        [TestMethod]

        public void WhenBoardIsEmptyBlackPawnCantEat()
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
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyBlackPawnCantEat2()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);
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
                    Height = 1
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyWhitePawnCantEat()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsEmptyWhitePawnCantEat2()
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
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullBlackPawnCanEat()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            board.Tiles[0, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsFullBlackPawnCanEat2()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            board.Tiles[0, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsFullBlackPawnCanEat3()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            board.Tiles[0, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[4, 2] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsFullWhitePawnCanEat()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            board.Tiles[7, 3] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 2] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsFullWhitePawnCanEat2()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            board.Tiles[7, 1] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 4] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void WhenBoardIsFullWhitePawnCanEat3()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            board.Tiles[7, 1] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 2] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsTrue(result);
        }



        // Black Pawns

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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            board.Tiles[0, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            board.Tiles[2, 2] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullBlackPawnCantEat2()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            board.Tiles[0, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            board.Tiles[2, 2] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            board.Tiles[0, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            board.Tiles[2, 2] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            board.Tiles[0, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[3, 1] = new Pawn { Color = PawnColor.White };

            board.Tiles[2, 4] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            board.Tiles[0, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[3, 1] = new Pawn { Color = PawnColor.White };

            board.Tiles[2, 4] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        //White Pawns


        [TestMethod]

        public void WhenBoardIsFullWhitePawnCantEat()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            board.Tiles[7, 3] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 0] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullWhitePawnCantEat2()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            board.Tiles[7, 3] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[5, 3] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullWhitePawnCantEat3()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            board.Tiles[7, 1] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[5, 1] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullWhitePawnCantEat4()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            board.Tiles[7, 1] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[5, 1] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullWhitePawnCantEat5()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            board.Tiles[7, 1] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[5, 5] = new Pawn { Color = PawnColor.Black };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        //Black Pawns Don't Eat Black Pawns

        [TestMethod]

        public void WhenBoardIsFullBlackPawnCantEatBlackPawn()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            board.Tiles[0, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 3] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullBlackPawnCantEatBlackPawn2()
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
                    Width = 0,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            board.Tiles[0, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullBlackPawnCantEatBlackPawn3()
        {
            var board = new Board(PawnColor.Black);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 3,
                    Height = 1
                },
                EndPoint = new Point
                {
                    Width = 1,
                    Height = 3
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            board.Tiles[0, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[2, 2] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullBlackPawnCantEatBlackPawn4()
        {
            var board = new Board(PawnColor.Black);
            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 3,
                    Height = 1
                },
                EndPoint = new Point
                {
                    Width = 5,
                    Height = 3
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            board.Tiles[0, 0] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 2] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 4] = new Pawn { Color = PawnColor.Black };
            board.Tiles[0, 6] = new Pawn { Color = PawnColor.Black };
            board.Tiles[2, 4] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        //White Pawns Don't Eat White Pawns

        [TestMethod]

        public void WhenBoardIsFullWhitePawnCantEatWhitePawn()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            board.Tiles[7, 1] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 4] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullWhitePawnCantEatWhitePawn2()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            board.Tiles[7, 1] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 2] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void WhenBoardIsFullWhitePawnCantEatWhitePawn3()
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
                    Width = 5,
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            board.Tiles[7, 3] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 5] = new Pawn { Color = PawnColor.White };
            board.Tiles[7, 7] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 4] = new Pawn { Color = PawnColor.White };
            board.Tiles[5, 5] = new Pawn { Color = PawnColor.White };

            // Act
            var result = _pawnActionLogic.FirstMovementToEat(input, board);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
