using NotTicTacToeLogic;
using System;

namespace NotTicTacToe
{
    public class GameUI
    {
        private static int s_BoardHight;
        private static bool s_PlayAgainstComputer;

        public static void PrintBoard(eSymbols[,] i_Board)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            for (int i = 1; i <= s_BoardHight; i++)
            {
                Console.Write($"  {i} ");
            }

            Console.WriteLine();
            for (int i = 1; i <= s_BoardHight; i++)
            {
                printRowCelles(i, i_Board);
                printOrezontalLine();
            }
        }

        private static void printRowCelles(int i_RowNumber, eSymbols[,] i_Board)
        {
            Console.Write($"{i_RowNumber}|");
            for (int i = 0; i < s_BoardHight; i++) 
            {
                string cellValue = i_Board[i_RowNumber - 1, i] == eSymbols.Empty ? " " : i_Board[i_RowNumber - 1, i].ToString();
                Console.Write($" {cellValue} |");
            }
            
            Console.WriteLine();
        }

        private static void printOrezontalLine()
        {
            Console.Write(" =");
            for (int i = 1; i <= s_BoardHight; i++)
            {
                Console.Write($"====");
            }

            Console.WriteLine();
        }

        public static void SetGameBoardSize()
        {
            Console.WriteLine("Choose board size (Between 3 - 9):");
            while (!validateBoardSize(out s_BoardHight))
            {
                Console.WriteLine("Invalid board size. Please try again.");
                Console.WriteLine("Choose board size (Between 3 - 9):");
            }
        }

        private static bool validateBoardSize(out int o_BoardSize)
        {
            bool validInput = int.TryParse(Console.ReadLine(), out o_BoardSize);
            return (validInput && o_BoardSize >= 3 && o_BoardSize <= 9);
        }
              
        public static void SetGameMode()
        {
            Console.WriteLine("Please choose game mode:");
            Console.WriteLine("1. Single Player (vs. Computer)");
            Console.WriteLine("2. Two Players (vs. Human)");
            while (!validateGameMode(out s_PlayAgainstComputer))
            {
                Console.WriteLine("Invalid game mode. Please try again.");
                Console.WriteLine("1. Single Player (vs. Computer)");
                Console.WriteLine("2. Two Players (vs. Human)");
            }
        }
              
        private static bool validateGameMode(out bool i_PlayAgenstComputer)
        {
            bool validInput = int.TryParse(Console.ReadLine(), out int gameMode);
            i_PlayAgenstComputer = (gameMode == 1);
            return (validInput && (gameMode == 1 || gameMode == 2));
        }
              
        public static bool IsPlayAgainstComputer()
        {
            return s_PlayAgainstComputer;
        }
              
        public static void PrintCellValueError(bool i_CellIsOccupied)
        {
            if (i_CellIsOccupied)
            {
                Console.Write("Cell is occupied");
            }
            else
            {
                Console.Write("cell is not on board");
            }

            Console.WriteLine(", Choose a different cell");
        }

        public static int GetBoardHight() 
        { 
            return s_BoardHight; 
        }

        public static bool IsPlayAgenstCompyter()
        {
            return s_PlayAgainstComputer;
        }

        public static bool GetPlayerChosenCell(Player i_Player, out int o_Row, out int o_Col)
        {
            bool stopGame = false;
            if (!i_Player.HasCoordinates(out o_Row, out o_Col))
            {
                Console.WriteLine("Choose cell row: ");
                string input = Console.ReadLine();
                while (input != "Q" && !int.TryParse(input, out o_Row))
                {
                    Console.WriteLine("Invalide input, must choose a number or Q (to stop game)");
                    Console.WriteLine("Choose cell row: ");
                    input = Console.ReadLine();
                }

                stopGame = (input == "Q");
                if (!stopGame)
                {
                    Console.WriteLine("Choose cell column: ");
                    input = Console.ReadLine();
                    while (input != "Q" && !int.TryParse(input, out o_Col))
                    {
                        Console.WriteLine("Invalide input, must choose a number or Q (to stop game)");
                        Console.WriteLine("Choose cell column: ");
                        input = Console.ReadLine();
                    }
                    stopGame = input == "Q";
                }

                o_Row--;
                o_Col--;
            }

            return stopGame;
        }
        public static bool HandleGameRoundEnd(bool i_GameStopped, bool i_BoardIsFull, Player[] i_Players, int i_WinnerId)
        {
            if (i_GameStopped)
            {
                Console.WriteLine("Game stopped.");
            }
            else if (i_BoardIsFull)
            {
                Console.WriteLine("Board is full. No winner this time.");
            }
            else
            {
                Console.WriteLine("We have a Winner!!!");
                Console.WriteLine($"Player {i_Players[i_WinnerId].GetSymbol()} has won");
            }

            foreach (Player player in i_Players)
            {
                Console.WriteLine($"Player '{player.GetSymbol()}' Score {player.GetScore()}");
            }

            Console.WriteLine("To Play anther Round enter 1, to shutdown game enter any thing else");
            return Console.ReadLine() == "1";
        }
    }
}



  

