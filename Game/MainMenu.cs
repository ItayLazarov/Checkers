using System;

namespace Checkers.Game
{
    public class MainMenu
    {
        public static ConsoleKeyInfo GetConsoleKey()
        {
            while (true)
            {
                Menu();

                ConsoleKeyInfo cki = Console.ReadKey(true);

                //Exit
                if (cki.Key == ConsoleKey.Escape)
                {
                    if (Exit.ExitGame() == true)
                        return cki;
                    continue;
                }

                //Help
                if (cki.Key == ConsoleKey.H)
                {
                    Guide();
                    continue;
                }

                //User Validation Error
                if (cki.Key != ConsoleKey.D1 && cki.Key != ConsoleKey.D2)
                {
                    Console.WriteLine("\nSorry,Thats Not One of the Choices!\n");
                    continue;
                }
                return cki;
            }
        }

        public static void Guide()
        {
            Console.WriteLine("Help Guide To New Style of Play of The Game Checkers:\n");

            Console.WriteLine("You can play either One player that plays both of the colors\nor you can play Two players\n");

            Console.WriteLine("The Winner is the player with The Pawn or Pawns left when the other player lost of his Pawns.\n");

            Console.WriteLine("There are 3 Types of Pawns in this game:\n");

            Console.WriteLine("1) Basic Pawn - Can move to the left or to the right only one tile diagonal.\n Also, the pawn can eat with only two tiles movement to the left or to the right\n");

            Console.WriteLine("2) King Pawn - Can move To on each diagonal on the board, to each side.\nAlso, the pawn can eat the same way.\n");

            Console.WriteLine("3) Last Pawn - This pawn will appear on the board if you have laft with only one pawn.\n");

            Console.WriteLine("This pawn can move to each diagonal on the board, but only one tile to each side.\nAlso, the pawn can eat in the same way");

            Console.WriteLine("Rules:\n");

            Console.WriteLine("1) Each player has one turn each time to play and move his pawns on the board.\n");

            Console.WriteLine("2) The way you move and eat in the game, is by entrering numbers that represents the location on the board/\n");

            Console.WriteLine("For example: your pawn is at tile (0,0), so its equal to (Y,X) on the board.\n");

            Console.WriteLine("So i want to move with this pawn (0,0) to the next tile.\n");

            Console.WriteLine("So first, I will enter the location of the pawn I want to move with -> enter Y Location, Enter X Location.\n");

            Console.WriteLine("if you selected an actuall pawn on the board, the computer will let you to enter the numbers of the tile you want to move to.\n");

            Console.WriteLine("Otherwise, the computer will ask you agian to enter a new location of an actuall pawn on the board.\n");

            Console.WriteLine("3) If You eat a rival pawn, and you still can eat another pawn around you(One tile near you) you can eat this pawn as well.\n");

            Console.WriteLine("The Computer Will show you where there are tiles you can go to and eat another pawn\n");

            Console.WriteLine("If you doesn't choose one of tiles the computer tells you about, the turn goes to the other player.\n");

            Console.WriteLine("Otherwise, you will keep eating ad long there are rival pawns around you that can be eaten.\n");

            Console.WriteLine("\nThank you For Playing My Game\n");
        }

        private static void Menu()
        {
            Console.WriteLine("Main Menu:");

            Console.WriteLine("1) New Game");

            Console.WriteLine("2) Load Game");

            Console.WriteLine("3) Help - Press H");

            Console.WriteLine("4) Exit - Press Esc");

            Console.WriteLine("Enter Your Selection Number");
        }
    }
}
