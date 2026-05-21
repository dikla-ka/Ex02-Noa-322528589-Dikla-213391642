using NotTicTacToe;
using NotTicTacToeLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTicTacToe
{
    public abstract class GameRun
    {
        public static void Run()
        {
            bool boardIsFull = false, stopGame = false, playAntherRound = true;
            int col, row, winnerId;
            GameUI.SetGameBoardSize();
            GameUI.SetGameMode();
            Game game = new Game();

            while (playAntherRound)
            {
                game.InitializeGame(GameUI.GetBoardHight(), GameUI.IsPlayAgenstCompyter());
                while (!game.IsGameOver(out boardIsFull, out winnerId))
                {
                    stopGame = GameUI.GetPlayerChosenCell(game.GetCurrentPlayer(), out row, out col);
                    if (!stopGame)
                    {
                        while (!game.TryToPlayTurn(row, col, out bool cellIsOccupied))
                        {
                            GameUI.PrintCellValueError(cellIsOccupied);
                            stopGame = GameUI.GetPlayerChosenCell(game.GetCurrentPlayer(), out row, out col);
                            if (stopGame)
                            {
                                break;
                            }
                        }
                    }
                    if (stopGame)
                    {
                        break;
                    }

                    GameUI.PrintBoard(game.GetBoard());
                }

                playAntherRound = GameUI.HandleGameRoundEnd(stopGame, boardIsFull, game.GetPlayers(), winnerId);
            }
        }
    }
}
