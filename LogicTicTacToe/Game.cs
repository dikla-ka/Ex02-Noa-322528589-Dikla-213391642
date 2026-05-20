namespace NotTicTacToeLogic
{
    public class Game
    {
        private Board m_Board;
        private Player[] m_Players = null;
        private int m_CountTurns = 0;

        public void InitializeGame(int i_BoardSize, bool i_SecondPlayerIsComputer)
        {
            m_Board = new Board(i_BoardSize);
            if (m_Players == null)
            {
                m_Players = new Player[2];
                m_Players[0] = new HumanPlayer();

                if (i_SecondPlayerIsComputer)
                {
                    m_Players[1] = new AutoPlayer();
                }
                else
                {
                    m_Players[1] = new HumanPlayer();
                }
            }

            foreach (Player player in m_Players)
            {
                player.ResetScore();
            }

            m_Players[0].SetBoard(m_Board);
            m_Players[1].SetBoard(m_Board);
        }

        public void ResetGame()
        {
            m_Board = new Board(m_Board.getBoardSize());
            m_Players[0].SetBoard(m_Board);
            m_Players[1].SetBoard(m_Board);
            m_CountTurns = 0;

        }

        public bool TryToPlayTurn(int i_Row, int i_Col, out bool o_CellIsOccupied)
        {
            bool turnIsValid = true;
            o_CellIsOccupied = false;

            //if (!m_Board.CheckIfValidCoord(i_Row, i_Col))
            //{
            //    turnIsValid = false;
            //}
            //else if (!m_Board.CheckIfCellIsEmpty(i_Row, i_Col))
            //{
            //    o_CellIsOccupied = true;
            //    //turnIsValid = false;
            //}
            //else
            //{
            //    m_Board.MakeMove(i_Row, i_Col, m_Players[m_CurrentTurn].GetSymbol());
            //    m_CurrentTurn = (m_CurrentTurn + 1) % 2;
            //}

            if (!m_Board.IsCoordValid(i_Row, i_Col))
            {
                turnIsValid = false;
            }
            else if (!m_Board.IsCellEmpty(i_Row, i_Col))
            {
                o_CellIsOccupied = true;
                turnIsValid = false;
            }
            else
            {
                m_Board.MakeMove(i_Row, i_Col, m_Players[m_CountTurns % 2].GetSymbol());
                m_CountTurns = m_CountTurns + 1;
            }

            return turnIsValid;    
        }

        public bool IsGameOver(out bool o_BoardIsFull, out int o_WinnerId)
        {
            //int currentTurnPlayerId = m_CountTurns;
            bool gameOver = false;
            o_BoardIsFull = false;
            o_WinnerId = -1;

            if (m_Board.IsBoardFull(m_CountTurns))
            {
                o_BoardIsFull = true;
                gameOver = true;
            }
            else if (m_Board.HasWinner())
            {
                gameOver = true;
                m_Players[(m_CountTurns) % 2].IncrementScore();
                o_WinnerId = m_Players[(m_CountTurns) % 2].GetId();
            }

            return gameOver;
        }

        public Player GetCurrentPlayer()
        {
            return m_Players[m_CountTurns % 2];
        }

        public Player[] GetPlayers()
        {
            return m_Players;
        }

    }
}
