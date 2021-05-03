using System;
using Checkers.Game;
using Checkers.Logic.PawnsActionsHandler;
using Checkers.Model.Request;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            var Menu = true;

            //Setting The Game

            //Main Menu
            while (Menu)
            {
                int choice;

                //Main Menu Loop
                while (int.TryParse(MainMenu.GetConsoleKey().KeyChar.ToString(), out choice) == false) ;

                var board = SettingGame.GetBoard(choice);


                //Declaring Which Main Class (Action Handler Class : IPawnActionHandler(Implemetation)) I Want To Execute With Gameplay Class!!!
                var GamePlay = new GamePlay(new PawnActionHandler());

                var GameOn = true;

                var playerRequest = new PlayerRequest();

                //The Game Started
                while (GameOn)
                {

                    //Printing The Board
                    DisplayBoard.Display(board);


                    //The Player Enters Input
                    var playerinput = GameInput.GetPlayerInput(board);


                    //If The Player Couldn't Play Because The Input Wasn't Good To Play a Turn (Move or Eat a Pawn)
                    var anotherTurn = true;

                    playerRequest.MovementInput = playerinput;
                    playerRequest.Board = board;


                    //The player Try to Move
                    if (GameActions.Move(playerRequest, board, GamePlay) == true)
                        anotherTurn = false;


                    //The Player Try to Eat
                    else
                    {
                        Console.WriteLine("\nUnssucceful Move\n");

                        if (GameActions.Eat(playerRequest, board, GamePlay) == true)
                            anotherTurn = false;

                        else
                            Console.WriteLine("\nUnsuccessful First Eat Move\n");
                    }


                    //The Player Didn't Success To Move or to Eat
                    if (anotherTurn == true)
                        continue;


                    //Check If The Pawns Neeeds To Change (Type)
                    ChangeTypes.ChangeTheTypes(board);


                    //Exit?? If Someone lost all of his pawns
                    if(Exit.ExitCheck() == true)
                    {
                        GameOn = false;
                        continue;
                    }

                    //Current Color Turn

                    board.CurrentTurn = Colors.ChangeTheColor(board.CurrentTurn);

                    //Save Game???
                    if (SettingGame.SaveGame(board) == true)
                        GameOn = false;

                    Console.WriteLine($"\nBlack Pawns = {SettingGame.BlackPawnsAlive.Count}\nWhite Pawns = {SettingGame.WhitePawnsAlive.Count}\n");
                }
            }
        }
    }
}
