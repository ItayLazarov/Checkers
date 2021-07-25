using System;
using System.Threading;

namespace Checkers.Game
{
    public class Exit
    {
        public static bool ExitCheck()
        {

            if (SettingGame.BlackPawnsAlive.Count > 0 && SettingGame.WhitePawnsAlive.Count > 0)
                return false;

            Console.Clear();

            if (SettingGame.BlackPawnsAlive.Count == 0 && SettingGame.WhitePawnsAlive.Count == 0)
                Console.WriteLine("\nThere is no Game Running at the moment...\n");

            else if (SettingGame.BlackPawnsAlive.Count == 0)
                Console.WriteLine("\n!!!**** White Won ****!!!\n");

            else if (SettingGame.WhitePawnsAlive.Count == 0)
                Console.WriteLine("\n!!!**** Black Won ****!!!\n");

            return true;
        }

        public static bool ExitGame()
        {
            while(true)
            {
                Console.WriteLine("Do You Want To Exit? (Y/N)");

                var cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.Y)
                    return true;

                if (cki.Key == ConsoleKey.N)
                    return false;

                Console.WriteLine("Please Enter Y or N");
            }
        }
    }
}
