using Checkers.Logic.PawnsActionsHandler;
using Checkers.Model;
using Checkers.Model.Enums;
using Checkers.Model.Pawns;
using Checkers.Model.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class PawnActionHandlerTests
    {
        private IPawnActionHandler _pawnActionHandler;

        [TestInitialize]
        public void Init()
        {
            _pawnActionHandler = new PawnActionHandler();
        }


        //Try Move Function Tests

        [TestMethod]
        public void TryMoveBlackPawnTrue()
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

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryMoveBlackPawnTrue2()
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
                    Width = 1,
                    Height = 1
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryMoveBlackPawnTrue3()
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
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryMoveWhitePawnTrue()
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
                    Width = 2,
                    Height = 6
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryMoveWhitePawnTrue2()
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
                    Width = 2,
                    Height = 6
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryMoveWhitePawnTrue3()
        {
            // Arrange 
            var board = new Board(PawnColor.White);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 5,
                    Height = 7
                },
                EndPoint = new Point
                {
                    Width = 6,
                    Height = 6
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryMoveBlackPawnFalse()
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
                    Width = 2,
                    Height = 6
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryMoveBlackPawnFalse2()
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
                    Width = 2,
                    Height = 6
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryMoveBlackPawnFalse3()
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
                    Width = 3,
                    Height = 0
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryMoveWhitePawnFalse()
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
                    Width = 0,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryMoveWhitePawnFalse2()
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
                    Height = 6
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryMoveWhitePawnFalse3()
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
                    Width = 2,
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryMoveKingPawnTrue()
        {
            // Arrange 
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryMoveKingPawnTrue2()
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

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryMoveKingPawnFalse()
        {
            // Arrange 
            var board = new Board(PawnColor.White);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 0,
                    Height = 2
                },
                EndPoint = new Point
                {
                    Width = 7,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryMoveKingPawnFalse2()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 7,
                    Height = 7
                },
                EndPoint = new Point
                {
                    Width = 7,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryMoveKingPawnFalse3()
        {
            // Arrange 
            var board = new Board(PawnColor.White);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 0,
                    Height = 2
                },
                EndPoint = new Point
                {
                    Width = 7,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryMoveLastPawnTrue()
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
                    Width = 2,
                    Height = 6
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryMoveLastPawnTrue2()
        {
            // Arrange 
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
                    Width = 4,
                    Height = 6
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryMoveLastPawnTrue3()
        {
            // Arrange 
            var board = new Board(PawnColor.White);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 2,
                    Height = 2
                },
                EndPoint = new Point
                {
                    Width = 3,
                    Height = 3
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryMoveLastPawnFalse()
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
                    Width = 1,
                    Height = 6
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryMoveLastPawnFalse2()
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
                    Width = 1,
                    Height = 6
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryMoveLastPawnFalse3()
        {
            // Arrange 
            var board = new Board(PawnColor.White);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 2,
                    Height = 4
                },
                EndPoint = new Point
                {
                    Width = 1,
                    Height = 4
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryMove(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        //Try First Eat

        [TestMethod]

        public void TryFirstEatBlackPawnTrue()
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
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryFirstEatBlackPawnTrue2()
        {
            // Arrange 
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
            board.Tiles[2, 2] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryFirstEatBlackPawnTrue3()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 4,
                    Height = 4
                },
                EndPoint = new Point
                {
                    Width = 6,
                    Height = 6
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };
            board.Tiles[5, 5] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryFirstEatWhitePawnTrue()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 2] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryFirstEatWhitePawnTrue2()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 6] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryFirstEatWhitePawnTrue3()
        {
            // Arrange 
            var board = new Board(PawnColor.White);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 3,
                    Height = 3
                },
                EndPoint = new Point
                {
                    Width = 1,
                    Height = 1
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };
            board.Tiles[2, 2] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryFirstEatBlackPawnFalse()
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
            board.Tiles[0, 1] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryFirstEatBlackPawnFalse2()
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
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryFirstEatBlackPawnFalse3()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 4,
                    Height = 0
                },
                EndPoint = new Point
                {
                    Width = 2,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryFirstEatWhitePawnFalse()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };
            board.Tiles[5, 4] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }


        [TestMethod]

        public void TryFirstEatWhitePawnFalse2()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 2] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }


        [TestMethod]

        public void TryFirstEatWhitePawnFalse3()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };
            board.Tiles[6, 7] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryFirstEatKingPawnTrue()
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
                    Width = 7,
                    Height = 7
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };
            board.Tiles[6, 6] = new PawnKing { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryFirstEatKingPawnTrue2()
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
            board.Tiles[2, 6] = new PawnKing { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryFirstEatKingPawnTrue3()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 2,
                    Height = 6
                },
                EndPoint = new Point
                {
                    Width = 7,
                    Height = 1
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };
            board.Tiles[2, 6] = new PawnKing { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryFirstEatKingPawnFalse()
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
                    Width = 7,
                    Height = 7
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryFirstEatKingPawnFalse2()
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryFirstEatKingPawnFalse3()
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
            board.Tiles[2, 6] = new PawnKing { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryFirstEatLastPawnTrue()
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
                    Width = 2,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };
            board.Tiles[1, 1] = new LastPawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryFirstEatLastPawnTrue2()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);

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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };
            board.Tiles[6, 6] = new LastPawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryFirstEatLastPawnTrue3()
        {
            // Arrange 
            var board = new Board(PawnColor.White);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 2,
                    Height = 2
                },
                EndPoint = new Point
                {
                    Width = 4,
                    Height = 0
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };
            board.Tiles[1, 3] = new LastPawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryFirstEatLastPawnFalse()
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
                    Width = 2,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryFirstEatLastPawnFalse2()
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
                    Width = 2,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };
            board.Tiles[1, 1] = new LastPawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryFirstEatLastPawnFalse3()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 1,
                    Height = 5
                },
                EndPoint = new Point
                {
                    Width = 3,
                    Height = 5
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };
            board.Tiles[6, 2] = new LastPawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryFirstEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        //Try Next Eat

        [TestMethod]

        public void TryNextEatBlackPawnTrue()
        {
            //Arrange
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
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryNextEatBlackPawnTrue2()
        {
            //Arrange
            var board = new Board(PawnColor.Black);

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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };
            board.Tiles[6, 6] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryNextEatBlackPawnTrue3()
        {
            //Arrange
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };
            board.Tiles[6, 2] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryNextEatWhitePawnTrue()
        {
            //Arrange
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryNextEatWhitePawnTrue2()
        {
            //Arrange
            var board = new Board(PawnColor.White);

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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryNextEatWhitePawnTrue3()
        {
            //Arrange
            var board = new Board(PawnColor.White);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 2,
                    Height = 2
                },
                EndPoint = new Point
                {
                    Width = 4,
                    Height = 4
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };
            board.Tiles[3, 3] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryNextEatBlackPawnFalse()
        {
            //Arrange
            var board = new Board(PawnColor.Black);

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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryNextEatBlackPawnFalse2()
        {
            //Arrange
            var board = new Board(PawnColor.Black);

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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };
            board.Tiles[6, 6] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryNextEatBlackPawnFalse3()
        {
            //Arrange
            var board = new Board(PawnColor.Black);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 2,
                    Height = 6
                },
                EndPoint = new Point
                {
                    Width = 4,
                    Height = 4
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.Black };
            board.Tiles[3, 4] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryNextEatWhitePawnFalse()
        {
            //Arrange
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryNextEatWhitePawnFalse2()
        {
            //Arrange
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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };
            board.Tiles[1, 1] = new Pawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryNextEatWhitePawnFalse3()
        {
            //Arrange
            var board = new Board(PawnColor.White);

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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new Pawn { Color = PawnColor.White };
            board.Tiles[0, 1] = new Pawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryNextEatKingPawnTrue()
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
            board.Tiles[6, 2] = new PawnKing { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryNextEatKingPawnTrue2()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);

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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };
            board.Tiles[6, 6] = new PawnKing { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryNextEatKingPawnTrue3()
        {
            // Arrange 
            var board = new Board(PawnColor.White);

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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.White };
            board.Tiles[4, 2] = new PawnKing { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryNextEatKingPawnFalse()
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

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryNextEatKingPawnFalse2()
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
            board.Tiles[6, 2] = new PawnKing { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryNextEatKingPawnFalse3()
        {
            // Arrange 
            var board = new Board(PawnColor.Black);

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

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new PawnKing { Color = PawnColor.Black };
            board.Tiles[1, 3] = new PawnKing { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryNextEatLastPawnTrue()
        {
            //Arrange
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
            board.Tiles[1, 1] = new LastPawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryNextEatLastPawnTrue2()
        {
            //Arrange
            var board = new Board(PawnColor.White);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 4,
                    Height = 0
                },
                EndPoint = new Point
                {
                    Width = 2,
                    Height = 2
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.White };
            board.Tiles[1, 3] = new LastPawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryNextEatLastPawnTrue3()
        {
            //Arrange
            var board = new Board(PawnColor.Black);

            var input = new Input
            {
                StartingPoint = new Point
                {
                    Width = 4,
                    Height = 6
                },
                EndPoint = new Point
                {
                    Width = 2,
                    Height = 4
                }
            };

            board.Tiles[input.StartingPoint.Height, input.StartingPoint.Width] = new LastPawn { Color = PawnColor.Black };
            board.Tiles[5, 3] = new LastPawn { Color = PawnColor.White };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TryNextEatLastPawnFalse()
        {
            //Arrange
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

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryNextEatLastPawnFalse2()
        {
            //Arrange
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
            board.Tiles[1, 1] = new LastPawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]

        public void TryNextEatLastPawnFalse3()
        {
            //Arrange
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
            board.Tiles[5, 4] = new LastPawn { Color = PawnColor.Black };

            //Act
            var result = _pawnActionHandler.TryNextEat(input, board);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
