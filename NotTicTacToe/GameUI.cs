using NotTicTacToeLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTicTacToe
{
    public class GameUI
    {
        private static int m_BoardHight;
        private static bool m_PlayAgenstCompyter;

        public static void PrintBoard(Symbols[,] i_Board)
        {
            for (int i = 1; i <= m_BoardHight; i++)
            {
                Console.Write($"  {i} ");
            }

            Console.WriteLine();
            for (int i = 1; i <= m_BoardHight; i++)
            {
                printRowCelles(i, i_Board);
                printOrezontalLine();
            }

        }

        private static void printRowCelles(int i_RowNumber, Symbols[,] i_Board)
        {
            Console.Write($"{i_RowNumber}|");
            for (int i = 0; i < m_BoardHight; i++) 
            {
                string cellValue = i_Board[i_RowNumber - 1, i] == Symbols.Empty ? " " : i_Board[i_RowNumber - 1, i].ToString();
                Console.Write($" {cellValue} |");
            }
            
            Console.WriteLine();
        }

        private static void printOrezontalLine() 
        {
            Console.Write(" =");
            for (int i = 1; i <= m_BoardHight; i++)
            {
                Console.Write($"====");
            }

            Console.WriteLine();
        }

        public static void PrintCellValueError(bool i_CellIsOcellIsOccupied)
        {
            if (i_CellIsOcellIsOccupied)
            {
                Console.Write("Cell is occupied");
            }
            else
            {
                Console.Write("cell is not on board");
            }

            Console.WriteLine(", Choose a diffrent cell");
        }

        public static int GetBoardHight() 
        { 
            return m_BoardHight; 
        }

        public static bool IsPlayAgenstCompyter()
        {
            return m_PlayAgenstCompyter;
        }

        public static bool GetPlayerChosenCell(Player player, out int o_row, out int o_col)
        {
            bool stopGame = false;
            if (!player.HasCoordinates(out o_row, out o_col))
            {
                Console.WriteLine("Choose cell row: ");
                string input = Console.ReadLine();
                while (input != "Q" && !int.TryParse(input, out o_row))
                {
                    Console.WriteLine("Invalide input, must choose a number or Q (to stop game)");
                    Console.WriteLine("Choose cell row: ");
                    input = Console.ReadLine();
                }

                stopGame = input == "Q";
                if (!stopGame)
                {
                    Console.WriteLine("Choose cell column: ");
                    input = Console.ReadLine();
                    while (input != "Q" && !int.TryParse(input, out o_col))
                    {
                        Console.WriteLine("Invalide input, must choose a number or Q (to stop game)");
                        Console.WriteLine("Choose cell column: ");
                        input = Console.ReadLine();
                    }
                    stopGame = input == "Q";
                }

                o_row--;
                o_col--;
            }

            return stopGame;
        }

        public static bool HandleGameRoundEnd(bool i_GameStoped, bool i_BoardIsFull, Player[] i_Players, int i_WinnerId)
        {
            if (i_GameStoped)
            {
                Console.WriteLine("Game stoped.");
            }
            else if (i_BoardIsFull)
            {
                Console.WriteLine("Board is full. No winner this time.");
            }
            else
            {
                Console.WriteLine("We have a WInner!!!");
                Console.WriteLine($"Player {i_Players[i_WinnerId].GetSymbol()} has won");
            }

            foreach (Player player in i_Players)
            {
                Console.WriteLine($"Player '{player.GetSymbol()}' Score {player.GetScore()}");
            }

            Console.WriteLine("To Play anther Round enter 1, to shutdown game enter any thing else");
            return Console.ReadLine() == "1";
        }

        public static void SetGameBoardSize()
        {
            Console.WriteLine("Choose board size (Between 3 - 9):");
            while (!ValidateBoardSize(out m_BoardHight))
            {
                Console.WriteLine("Invalid board size. Please try again.");
                Console.WriteLine("Choose board size (Between 3 - 9):");
            }
        }

        public static void SetGameMode()
        {
            Console.WriteLine("Please choose game mode:");
            Console.WriteLine("1. Single Player (vs. Computer)");
            Console.WriteLine("2. Two Players (vs. Human)");
            while (!ValidateGameMode(out m_PlayAgenstCompyter))
            {
                Console.WriteLine("Invalid game mode. Please try again.");
                Console.WriteLine("1. Single Player (vs. Computer)");
                Console.WriteLine("2. Two Players (vs. Human)");
            }
        }

        private static bool ValidateBoardSize(out int i_BoardSize)
        {
            bool validInput = int.TryParse(Console.ReadLine(), out i_BoardSize);
            return (validInput && i_BoardSize >= 3 && i_BoardSize <= 9);
        }

        private static bool ValidateGameMode(out bool i_PlayAgenstComputer)
        {
            bool validInput = int.TryParse(Console.ReadLine(), out int gameMode);
            i_PlayAgenstComputer = (gameMode == 1);
            return (validInput && (gameMode == 1 || gameMode == 2));
        }
    }
}
