using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTicTacToe
{
    public class GameUI
    {


        public void setGameBoardSize()
        {
            Console.WriteLine("Choose board size (Between 3 - 9):");
            while (!ValidateBoardSize())
            {
                Console.WriteLine("Invalid board size. Please try again.");
                Console.WriteLine("Choose board size (Between 3 - 9):");
            }
        }

        public void setGameMode()
        {
            Console.WriteLine("Please choose game mode:");
            Console.WriteLine("1. Single Player (vs. Computer)");
            Console.WriteLine("2. Two Players (vs. Human)");
            while (!ValidateGameMode())
            {
                Console.WriteLine("Invalid game mode. Please try again.");
                Console.WriteLine("1. Single Player (vs. Computer)");
                Console.WriteLine("2. Two Players (vs. Human)");
            }
        }

        private static bool ValidateBoardSize()
        {
            bool validInput = int.TryParse(Console.ReadLine(), out int boardSize);
            return (validInput && boardSize >= 3 && boardSize <= 9);
        }

        private static bool ValidateGameMode()
        {
            bool validInput = int.TryParse(Console.ReadLine(), out int gameMode);
            return (validInput && (gameMode == 1 || gameMode == 2));
        }
    }
}
