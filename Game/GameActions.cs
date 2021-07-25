using Checkers.Logic.PawnsActionsUtillities;
using Checkers.Model;
using Checkers.Model.Request;
using System;
using System.Threading;

namespace Checkers.Game
{
    public class GameActions
    {
        public static bool Move(PlayerRequest playerRequest, Board board, GamePlay gamePlay)
        {
            if (gamePlay.ExecuteTurnMove(playerRequest) == true)
            {
                Console.WriteLine("\n***Successful Move Turn***\n");

                var playerinput = playerRequest.MovementInput;

                board.Tiles[playerinput.EndPoint.Height, playerinput.EndPoint.Width] = board.Tiles[
                    playerinput.StartingPoint.Height, playerinput.StartingPoint.Width
                    ];

                board.Tiles[playerinput.StartingPoint.Height, playerinput.StartingPoint.Width] = null;

                return true;
            }
            return false;
        }

        public static bool Eat(PlayerRequest playerRequest,Board board,GamePlay gamePlay)
        {
            if (gamePlay.ExecuteFirstEatMove(playerRequest) == true)
            {

                Console.WriteLine("\n***Successful First Eat Move***\n");

                bool optionsToEat;

                var playerinput = playerRequest.MovementInput;

                do
                {
                    optionsToEat = false;

                    PawnActionUtillities.DeletePawn(playerinput, board);

                    playerinput.StartingPoint = playerinput.EndPoint;

                    //Printing the points list, using another DiplayBoard function

                    var points = GameInput.IsTherePawnsAround(playerinput.StartingPoint);

                    foreach (var point in points)
                    {
                        var tempRequest = new PlayerRequest
                        {
                            Board = board,
                            MovementInput = new Input
                            { StartingPoint = playerinput.EndPoint, EndPoint = point }
                        };

                        //Checking if the points in the list are valid to eat
                        if (gamePlay.EatingLoop(tempRequest) == true)
                        {
                            optionsToEat = true;
                            Console.WriteLine($"You can go to The Tile : ( {point.Height} , {point.Width} )\n");
                            Thread.Sleep(1000);
                        }
                    }

                    //Clean the List Of Points
                    points.Clear();

                    //If There's no more pawns you can eat this turn
                    if (optionsToEat == false) 
                        return true;

                    //Printing The Board
                    DisplayBoard.Display(board);

                    Console.WriteLine("Enter The Location You Want To Move To With Your Pawn...\nIf You Wont eat another pawn, your turn will end!\n");

                    //Input Of The Next Eating Position
                    var input = GameInput.GetNextEatPoint(board,playerinput);

                    if (input.Equals(false))
                        return false;

                    //playerinput.EndPoint = GameInput.GetNextEatPoint(board);

                    playerinput.EndPoint = (Point)input;


                    playerRequest.MovementInput = playerinput;
                    playerRequest.Board = board;

                    //Did the user succeeded to eat?
                    if (gamePlay.EatingLoop(playerRequest) == false)
                    {
                        Console.WriteLine("\nYou didn't choose one of the tiles...\nUnsuccessful Next Eat Move\n");
                        //This Ends the Player's Turn
                        break;
                    }
                    Console.WriteLine("\n***successful Next Eat Move***\n");

                } while (optionsToEat == true);
            }

            return false;
        }
    }
}
