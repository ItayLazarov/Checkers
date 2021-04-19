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

                Board board = new Board(player1color);



                board = SettingGame.CreateBoard(player1color);


                //Printing The Board
                SettingGame.DisplayBoard(board, player1color);


                //Declaring Which Main Class (Action Handler Class : IPawnActionHandler(Implemetation)) I Want To Execute With Gameplay Class!!!
                GamePlay GamePlay = new GamePlay(new PawnActionHandler());


                PlayerRequest playerRequest = new PlayerRequest();


                board.CurrentTurn = player1color;


                var GameOn = true;


                //The Game Started
                while (GameOn)
                {

                    //The Player Enters Input
                    var playerinput = SettingGame.GetPlayerInput(board, board.CurrentTurn);


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

                            PawnActionUtillities.DeletePawn(playerinput, board);

                            //Printing The Board
                            SettingGame.DisplayBoard(board, board.CurrentTurn);

                            if (SettingGame.IsTherePawnsAround(playerinput.EndPoint, board, board.CurrentTurn))
                            {

                                do
                                {
                                    playerinput.StartingPoint = playerinput.EndPoint;

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
                                    SettingGame.DisplayBoard(board, board.CurrentTurn);

                                    Console.WriteLine("\n***Successful Next Eat Move***\n");
                                } while (SettingGame.IsTherePawnsAround(playerinput.EndPoint, board, board.CurrentTurn));
                            }
                        }

                        else
                            Console.WriteLine("\nUnsuccessful First Eat Move\n");
                    }

                    //The Player Didn't Success To Move or to Eat
                    if (anotherTurn == true)
                        continue;


                    //Check If The Pawns Neeeds To Change (Type)
                    ChangeTypes.ChangeTheTypes(board, board.CurrentTurn);


                    //Printing The Board
                    SettingGame.DisplayBoard(board, board.CurrentTurn);

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
