using NotTicTacToeLogic;

namespace NotTicTacToe
{
    public class GameRun
    {
        public void Run() 
        {
            bool boardIsFull = false;
            bool stopGame = false;
            bool playAnotherRound = true;
            int col;
            int row;
            int winnerId;

            GameUI.SetGameBoardSize();
            GameUI.SetGameMode();
            Game game = new Game();

            while (playAnotherRound)
            {
                game.InitializeGame(GameUI.GetBoardHeight(), GameUI.IsPlayAgainstComputer());
                while (!game.IsGameOver(out boardIsFull, out winnerId))
                {
                    GameUI.PrintBoard(game.GetBoard());
                    stopGame = GameUI.GetPlayerChosenCell(game.GetCurrentPlayer(), out row, out col);
                    if (stopGame)
                    {
                        break;
                    }

                    while (!game.TryToPlayTurn(row, col, out bool cellIsOccupied))
                    {
                        GameUI.PrintCellValueError(cellIsOccupied);
                        stopGame = GameUI.GetPlayerChosenCell(game.GetCurrentPlayer(), out row, out col);
                        if (stopGame)
                        {
                            break;
                        }
                    }
                    if (stopGame)
                    {
                        break;
                    }
                }
                if (!stopGame)
                {
                    GameUI.PrintBoard(game.GetBoard());
                }

                playAnotherRound = GameUI.HandleGameRoundEnd(stopGame, boardIsFull, game.GetPlayers(), winnerId);
            }
        }
    }
}
