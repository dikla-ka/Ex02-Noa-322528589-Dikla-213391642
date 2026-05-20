namespace NotTicTacToeLogic
{
    public class Game
    {
        private Board m_board;
        private Player[] m_players;
        int currentTurn = 0;

        public void InitializeGame(int i_BoardSize, bool i_SecondPlayerIsComputer)
        {
            m_players = new Player[2];
            m_board = new Board(i_BoardSize);
            m_players[0] = new HumanPlayer(m_board);
            if (i_SecondPlayerIsComputer == true)
            {
                m_players[1] = new AutoPlayer(m_board);
            }
            else
            {
                m_players[1] = new HumanPlayer(m_board);
            }
        }
        public void ResetGame()
        {
            m_board = new Board(m_board.getBoardSize());
            m_players[0].setBoard(m_board);
            m_players[1].setBoard(m_board);
            currentTurn = 0;

        }

        public bool MakeTurn(int i_Row, int i_Col, out bool o_cellIsOccupied)
        {
            bool turnIsValid = true;
            o_cellIsOccupied = false;

            if (!m_board.CheckIfValidCoord(i_Row, i_Col))
            {
                turnIsValid = false;
            }
            else if (!m_board.CheckIfCellIsEmpty(i_Row, i_Col))
            {
                o_cellIsOccupied = true;
                turnIsValid = false;
            }
            else
            {
                m_board.MakeMove(i_Row, i_Col, m_players[currentTurn].GetSymbol());
                currentTurn = (currentTurn + 1) % 2;
            }
            
            return turnIsValid;    
        }

        public bool IsGameOver(out bool o_BoardIsFull)
        {
            bool gameOver = false;
            Symbols winner = Symbols.Empty;
            o_BoardIsFull = false;

            winner = m_board.CheckForWinner();
            if (winner == Symbols.X || winner == Symbols.O)
            {
                gameOver = true;
                if (winner == Symbols.X)
                {
                    m_players[0].IncrementScore();
                }
                else if (winner == Symbols.O)
                {
                    m_players[1].IncrementScore();
                }
            }

            if (m_board.IsBoardFull())
            {
                o_BoardIsFull = true;
                gameOver = true;
            }
            return gameOver;
        }
        public Player GetCurrentPlayer()
        {
            return m_players[currentTurn];
        }

    }
}
