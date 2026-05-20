using System;


namespace NotTicTacToeLogic
{
    public class Board
    {
        private string[,] m_Board;
        private int m_BoardSize;
        private int m_CountTurns = 0;

        private void SetBoardSize()
        {
            m_BoardSize = m_Board.GetLength(0);
        }
        public int getBoardSize ()
        { 

            return m_BoardSize;
        }
        
        public bool IsBoardFull()
        {
            return m_CountTurns == (m_BoardSize * m_BoardSize);
        }
        public bool CheckIfValidCoord(int i_Row, int i_Col)
        {
            return (i_Row >= 0 && i_Row < m_BoardSize) && (i_Col >= 0 && i_Col < m_BoardSize);
        }

        public bool CheckIfCellIsEmpty(int i_Row, int i_Col)
        {
            return string.IsNullOrEmpty(m_Board[i_Row, i_Col]);
        }

        public string CheckForWinner()
        {
            string loosingPlayer = string.Empty;
            string winnerPlayer = string.Empty;
            bool winnerFound = false;

            for (int i = 0; i < m_BoardSize; i++)
            {
                if (CheckRow(i) == true)
                {
                    loosingPlayer = m_Board[i, 0];
                    winnerFound = true;
                    break;
                }
            }
            if (winnerFound == false)
            {
                for (int i = 0; i < m_BoardSize; i++)
                {
                    if (CheckCol(i) == true)
                    {
                        loosingPlayer = m_Board[0, i];
                        winnerFound = true;
                        break;
                    }
                }
            }
            if (winnerFound == false)
            {
                if (CheckMainDiagonal() == true)
                {
                    loosingPlayer = m_Board[0, 0];
                    winnerFound = true;
                }

            }
            if (winnerFound == false)
            {
                if (CheckSecondaryDiagonal() == true)
                {
                    loosingPlayer = m_Board[0, m_BoardSize - 1];
                    winnerFound = true;
                }

            }

            if (winnerFound == true)
            {

                if (loosingPlayer == "X")
                {
                    winnerPlayer = "O";

                }
                else
                {
                    winnerPlayer = "X";
                }

            }

            return winnerPlayer;
        }

        private bool CheckRow(int i_Row)
        {
            bool streak = true;
            string firstSignOfTheRow = m_Board[i_Row, 0];
            for (int i = 1; i < m_BoardSize; i++)
            {
                string currentSign = m_Board[i_Row, i];

                if (currentSign != firstSignOfTheRow)
                {
                    streak = false;
                    break;
                }
            }
            return streak; 
        }

        private bool CheckCol(int i_Col)
        {
            bool streak = true;
            string firstSignOfTheCol = m_Board[0, i_Col];
            for (int i = 1; i < m_BoardSize; i++)
            {
                string currentSign = m_Board[i, i_Col];

                if (currentSign != firstSignOfTheCol)
                {
                    streak = false;
                    break;
                }
            }
            return streak;
        }

        private bool CheckMainDiagonal()
        {
            bool streak = true;
            string firstSignMainDiagonal = m_Board[0, 0];
            for (int i = 1; i < m_BoardSize; i++)
            {
                string currentSign = m_Board[i, i];

                if (currentSign != firstSignMainDiagonal)
                {
                    streak = false;
                    break;
                }
            }
            return streak;
        }

        private bool CheckSecondaryDiagonal()
        {
            bool streak = true;
            string firstSignsecondoryDiagonal = m_Board[0, m_BoardSize - 1];
            for (int currentRow = 1; currentRow < m_BoardSize; currentRow++)
            {
                string currentSign = m_Board[currentRow, m_BoardSize - (currentRow + 1)];

                if (currentSign != firstSignsecondoryDiagonal)
                {
                    streak = false;
                    break;
                }
            }
            return streak;
        }

        public string[,] GetBoard()
        { 
            return m_Board; 
        }
        public void SetBoard (int sizeOfBoard)
        {
            m_Board = new string[sizeOfBoard, sizeOfBoard];
        }



    }
}