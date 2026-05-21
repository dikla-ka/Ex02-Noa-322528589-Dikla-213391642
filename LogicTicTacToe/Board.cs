namespace NotTicTacToeLogic
{
    public class Board
    {
        private Symbols[,] m_Board;
        private int m_BoardSize;
        //private int m_CountTurns = 0;

        public Symbols GetCellSymbol(int i_Row, int i_Col)
        {
            return m_Board[i_Row, i_Col];
        }

        public Board(int sizeOfBoard)
        {
            m_Board = new Symbols[sizeOfBoard, sizeOfBoard];
            m_BoardSize = sizeOfBoard;
        }

        public Symbols[,] GetBoard()
        {
            return m_Board;
        }

        public int getBoardSize()
        {
            return m_BoardSize;
        }

        public bool IsBoardFull(int i_CountTurnsPlayed)
        {
            return i_CountTurnsPlayed == (m_BoardSize * m_BoardSize);
        }

        public bool IsCoordValid(int i_Row, int i_Col)
        {
            return (i_Row >= 0 && i_Row < m_BoardSize) && (i_Col >= 0 && i_Col < m_BoardSize);
        }

        public bool IsCellEmpty(int i_Row, int i_Col)
        {
            return GetCellSymbol(i_Row, i_Col) == Symbols.Empty;
        }
        public bool HasWinner()
        {
            //Symbols losingPlayer = Symbols.Empty;
            //Symbols winnerPlayer = Symbols.Empty;
            bool winnerFound = false;

            for (int i = 0; i < m_BoardSize; i++)
            {
                if (IsRowFull(i) == true)
                {
                    //losingPlayer = m_Board[i, 0];
                    winnerFound = true;
                    break;
                }
            }
            if (winnerFound == false)
            {
                for (int i = 0; i < m_BoardSize; i++)
                {
                    if (IsColFull(i) == true)
                    {
                        //losingPlayer = m_Board[0, i];
                        winnerFound = true;
                        break;
                    }
                }
            }
            if (winnerFound == false)
            {
                if (IsMainDiagonalFull() == true)
                {
                    //losingPlayer = m_Board[0, 0];
                    winnerFound = true;
                }

            }
            if (winnerFound == false)
            {
                if (IsMainSecondaryFull() == true)
                {
                    //losingPlayer = m_Board[0, m_BoardSize - 1];
                    winnerFound = true;
                }

            }

            //if (winnerFound == true)
            //{

            //    if (losingPlayer == Symbols.X)
            //    {
            //        winnerPlayer = Symbols.O;

            //    }
            //    else
            //    {
            //        winnerPlayer = Symbols.X;
            //    }

            //}

            return winnerFound;
        }

        public void MakeMove (int i_Row, int i_Col, Symbols symbol)
        {
            m_Board[i_Row, i_Col] = symbol;
            //m_CountTurns++;
        }

        private bool IsRowFull(int i_Row)
        {
            bool streak = true;
            Symbols firstSignOfTheRow = m_Board[i_Row, 0];

            if (firstSignOfTheRow == Symbols.Empty)
            {
                streak = false;
            }
            else
            {

                for (int i = 1; i < m_BoardSize; i++)
                {
                    Symbols currentSign = m_Board[i_Row, i];

                    if (currentSign != firstSignOfTheRow)
                    {
                        streak = false;
                        break;
                    }
                }

            }
            return streak; 
        }
        private bool IsColFull(int i_Col)
        {
            bool streak = true;
            Symbols firstSignOfTheCol = m_Board[0, i_Col];
            if (firstSignOfTheCol == Symbols.Empty)
            {
                streak = false;
            }
            else
            {
                for (int i = 1; i < m_BoardSize; i++)
                {
                    Symbols currentSign = m_Board[i, i_Col];

                    if (currentSign != firstSignOfTheCol)
                    {
                        streak = false;
                        break;
                    }
                }
            }
            return streak;
        }
        private bool IsMainDiagonalFull()
        {
            bool streak = true;
            Symbols firstSignMainDiagonal = m_Board[0, 0];

            if (firstSignMainDiagonal == Symbols.Empty)
            {
                streak = false;
            }
            else
            {

                for (int i = 1; i < m_BoardSize; i++)
                {
                    Symbols currentSign = m_Board[i, i];

                    if (currentSign != firstSignMainDiagonal)
                    {
                        streak = false;
                        break;
                    }
                }
            }
            return streak;
        }
        private bool IsMainSecondaryFull()
        {
            bool streak = true;
            Symbols firstSignsecondoryDiagonal = m_Board[0, m_BoardSize - 1];
            if (firstSignsecondoryDiagonal == Symbols.Empty)
            {
                streak = false;
            }
            else
            {
                for (int currentRow = 1; currentRow < m_BoardSize; currentRow++)
                {
                    Symbols currentSign = m_Board[currentRow, m_BoardSize - (currentRow + 1)];

                    if (currentSign != firstSignsecondoryDiagonal)
                    {
                        streak = false;
                        break;
                    }
                }
            }
            return streak;
        }
    }
}