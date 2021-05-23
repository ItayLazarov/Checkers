using System;
using System.Threading;
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

                var consoleKey = MainMenu.GetConsoleKey();

                if (consoleKey.Key == ConsoleKey.Escape)
                    break;

                else if (int.TryParse(consoleKey.KeyChar.ToString(), out choice) == false || consoleKey.Key == ConsoleKey.H)
                    continue;

                Console.Clear();

                //Setting the Board
                var board = SettingGame.GetBoard(choice);


                //Declaring Which Main Class (Action Handler Class : IPawnActionHandler(Implemetation)) I Want To Execute With Gameplay Class!!!
                var GamePlay = new GamePlay(new PawnActionHandler());

                var GameOn = true;

                //Plyer Request = User Input and Current Board
                var playerRequest = new PlayerRequest();

                //The Game Started
                while (GameOn)
                {

                    //Printing The Board
                    DisplayBoard.Display(board);


                    //The Player Enters Input
                    var playerinput = GameInput.GetPlayerInput(board);

                    if (playerinput.Equals(false))
                    {
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    }


                    //If The Player Couldn't Play Because The Input Wasn't Good To Play a Turn (Move or Eat a Pawn) it will equals to true
                    var anotherTurn = true;

                    playerRequest.MovementInput = (Input)playerinput;
                    playerRequest.Board = board;


                    //The player Try to Move
                    if (GameActions.Move(playerRequest, board, GamePlay) == true)
                        anotherTurn = false;


                    //The Player Try to Eat
                    else
                    {
                        Console.WriteLine("\nUnssucceful Move...\n");
                        Thread.Sleep(2000);

                        if (GameActions.Eat(playerRequest, board, GamePlay) == true)
                            anotherTurn = false;

                        else
                        {
                            Console.WriteLine("\nUnsuccessful First Eat Move...\n");
                            Thread.Sleep(2000);
                        }
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
                    //if (SettingGame.SaveGame(board) == true)
                    //    GameOn = false;

                    //Console.WriteLine($"\nBlack Pawns = {SettingGame.BlackPawnsAlive.Count}\nWhite Pawns = {SettingGame.WhitePawnsAlive.Count}\n");
                }
            }
        }
    }
}
