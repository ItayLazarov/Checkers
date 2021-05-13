using Checkers.Model.Enums;
using System;

namespace Checkers.Game
{
    public class Colors
    {
        public static PawnColor ChangeTheColor(PawnColor currentTurn)
        {
            return currentTurn == PawnColor.Black ? PawnColor.White : PawnColor.Black;
        }

        public static PawnColor ChooseColor()
        {
            var cki = new ConsoleKeyInfo();

            while (true)
            {
                Console.WriteLine("Enter the Color You Want\n1) Black\n2) White");
                cki = Console.ReadKey(true);

                if (cki.Key != ConsoleKey.D1 && cki.Key != ConsoleKey.D2)
                {
                    Console.WriteLine("Please Choose One Of The Colors By Choosing 1 or 2");
                    continue;
                }

                if (cki.Key == ConsoleKey.D1)
                    return PawnColor.Black;

                if (cki.Key == ConsoleKey.D2)
                    return PawnColor.White;
            }
        }

        public static void ColorOfTheRows()
        {
                                    //The Actual Color
            Console.ForegroundColor = ConsoleColor.Blue;

            for (int j = 0; j < 33; j++)
            {
                Console.Write("-");
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void ColorOfTheColumns()
        {
                                    //The Actual Color
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("|");
            Console.ResetColor();
        }

        public static void ColorOfTheEvenNumbersTiles()
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void ColorOfTheOddNumbersTiles()
        {
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
