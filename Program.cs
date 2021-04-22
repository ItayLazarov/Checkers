using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Game;
using Checkers.Logic.PawnsActionsHandler;
using Checkers.Logic.PawnsActionsUtillities;
using Checkers.Model;
using Checkers.Model.Request;
using Repository;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setting The Game

            while (true)
            {

                //Setting The Board

                var player1color = SettingGame.ChooseColor();


                var board = SettingGame.CreateBoard(player1color);



                //Declaring Which Main Class (Action Handler Class : IPawnActionHandler(Implemetation)) I Want To Execute With Gameplay Class!!!
                GamePlay GamePlay = new GamePlay(new PawnActionHandler());


                PlayerRequest playerRequest = new PlayerRequest();


                //board.CurrentTurn = player1color;


                var GameOn = true;


                //The Game Started
                while (GameOn)
                {

                    //Printing The Board
                    SettingGame.DisplayBoard(board);

                    //The Player Enters Input
                    var playerinput = SettingGame.GetPlayerInput(board);


                    //If The Player Couldn't Play Because The Input Wasn't Good To Play a Turn (Move or Eat a Pawn)
                    bool anotherTurn = true;

                    playerRequest.MovementInput = playerinput;
                    playerRequest.Board = board;

                    if (GamePlay.ExecuteTurnMove(playerRequest))
                    {
                        //The Player Successed To Move
                        anotherTurn = false;

                        Console.WriteLine("\n***Successful Move Turn***\n");

                        board.Tiles[playerinput.EndPoint.Height, playerinput.EndPoint.Width] = board.Tiles[
                            playerinput.StartingPoint.Height, playerinput.StartingPoint.Width
                            ];

                        board.Tiles[playerinput.StartingPoint.Height, playerinput.StartingPoint.Width] = null;
                    }


                    else
                    {
                        Console.WriteLine("\nUnssucceful Move\n");

                        if (GamePlay.ExecuteFirstEatMove(playerRequest))
                        {
                            //The Player Successed To Eat
                            anotherTurn = false;

                            Console.WriteLine("\n***Successful First Eat Move***\n");


                            /*if (SettingGame.IsTherePawnsAround(playerinput.EndPoint, board))
                            {

                                do
                                {
                                    playerinput.StartingPoint = playerinput.EndPoint;

                                    //Checking if there are Pawns around

                                    Console.WriteLine("Enter The Location Of The Pawn You Want To Move To");
                                    playerinput.EndPoint = SettingGame.GetPoint(board.Tiles.GetLength(0));

                                    playerRequest.MovementInput = playerinput;
                                    playerRequest.Board = board;

                                    if (GamePlay.EatingLoop(playerRequest) == false)
                                    {
                                        Console.WriteLine("\nUnsuccessful Next Eat Move\n");
                                        break;
                                    }

                                    PawnActionUtillities.DeletePawn(playerinput, board);

                                    //Printing The Board
                                    SettingGame.DisplayBoard(board);

                                    Console.WriteLine("\n***Successful Next Eat Move***\n");
                                } while (SettingGame.IsTherePawnsAround(playerinput.EndPoint, board));
                            }*/


                            bool optionsToEat;

                            do
                            {
                                optionsToEat = false;

                                PawnActionUtillities.DeletePawn(playerinput, board);

                                //Printing The Board
                                SettingGame.DisplayBoard(board);


                                var points = SettingGame.IsTherePawnsAround(playerinput.EndPoint);

                                Console.WriteLine($"Number of Points in The List: {points.Count}\n");

                                playerinput.StartingPoint = playerinput.EndPoint;
                                
                                foreach (var point in points)
                                {
                                    var tempRequest = new PlayerRequest { Board = board, MovementInput = new Input 
                                    { StartingPoint = playerinput.EndPoint, EndPoint = point } };

                                    //Checking if the points in the list are valid to eat
                                    if (GamePlay.EatingLoop(tempRequest))
                                    {
                                        optionsToEat = true;
                                        Console.WriteLine($"You can go to The Tile : ( {point.Height} , {point.Width} )");
                                    }
                                }

                                Console.WriteLine("Enter The Location Of The Pawn You Want To Move To");
                                playerinput.EndPoint = SettingGame.GetPoint(board.Tiles.GetLength(0));


                                //If the user entered a point that doesn't in the list (It's not an eaten point)
                                if (points.Contains(playerinput.EndPoint) == false)
                                {
                                    Console.WriteLine("Sorry, That's not one of the Tiles you could move to\n");
                                    break;
                                }

                                //Clean the List Of Points
                                points.Clear();

                                playerRequest.MovementInput = playerinput;
                                playerRequest.Board = board;

                                //Did the user succeeded to eat?
                                if (GamePlay.EatingLoop(playerRequest) == false)
                                {
                                    Console.WriteLine("\nUnsuccessful Next Eat Move\n");
                                    break;
                                }

                            } while (optionsToEat);
                        }

                        else
                            Console.WriteLine("\nUnsuccessful First Eat Move\n");
                    }

                    //The Player Didn't Success To Move or to Eat
                    if (anotherTurn == true)
                        continue;


                    //Check If The Pawns Neeeds To Change (Type)
                    ChangeTypes.ChangeTheTypes(board);


                    //SettingGame.DisplayBoard(board);

                    //What If There Are no Pawns for one of the players????

                    //Exit??
                    if (SettingGame.ExitGame())
                        GameOn = false;


                    //Current Color Turn

                    board.CurrentTurn = SettingGame.ChangeTheColor(board.CurrentTurn);
                }

                break;
            }
        }
    }
}
