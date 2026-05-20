namespace NotTicTacToeLogic
{
    public class Game
    {
        private Board m_Board;
        private Player[] m_Players;
        private int m_CurrentTurn = 0;

        public void InitializeGame(int i_BoardSize, bool i_SecondPlayerIsComputer)
        {
            m_Board = new Board(i_BoardSize);
            m_Players = new Player[2];
            m_Players[0] = new HumanPlayer();

            if (i_SecondPlayerIsComputer == true)
            {
                m_Players[1] = new AutoPlayer();
            }
            else
            {
                m_Players[1] = new HumanPlayer();
            }

            m_Players[0].setBoard(m_Board);
            m_Players[1].setBoard(m_Board);
        }

        public void ResetGame()
        {
            m_Board = new Board(m_Board.getBoardSize());
            m_Players[0].setBoard(m_Board);
            m_Players[1].setBoard(m_Board);
            m_CurrentTurn = 0;

        }

        public bool MakeTurn(int i_Row, int i_Col, out bool o_CellIsOccupied)
        {
            bool turnIsValid = true;
            o_CellIsOccupied = false;

            if (!m_Board.CheckIfValidCoord(i_Row, i_Col))
            {
                turnIsValid = false;
            }
            else if (!m_Board.CheckIfCellIsEmpty(i_Row, i_Col))
            {
                o_CellIsOccupied = true;
                turnIsValid = false;
            }
            else
            {
                m_Board.MakeMove(i_Row, i_Col, m_Players[m_CurrentTurn].GetSymbol());
                m_CurrentTurn = (m_CurrentTurn + 1) % 2;
            }
            
            return turnIsValid;    
        }

        public bool IsGameOver(out bool o_BoardIsFull)
        {
            bool gameOver = false;
            Symbols winner = Symbols.Empty;
            o_BoardIsFull = false;

            winner = m_Board.CheckForWinner();
            if (winner == Symbols.X || winner == Symbols.O)
            {
                gameOver = true;
                if (winner == Symbols.X)
                {
                    m_Players[0].IncrementScore();
                }
                else if (winner == Symbols.O)
                {
                    m_Players[1].IncrementScore();
                }
            }

            if (m_Board.IsBoardFull())
            {
                o_BoardIsFull = true;
                gameOver = true;
            }
            return gameOver;
        }
        public Player GetCurrentPlayer()
        {
            return m_Players[m_CurrentTurn];
        }

    }
}
