using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTicTacToeLogic
{
    public class Game
    {
        private Board m_board;
        private Player[] m_players;
        int currentTurn = 0;

        public void InitializeGame(int i_BoardSize, bool i_SecondPlayerIsComputer)
        {
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
        public bool MakeTurn()
        {
            //כדאי שבמחלקת UI יהיו 2 משתני OUTPUT ואז נדליק את מי שגרם לשגיאה ולפיו תוכלי להדפיס שגיאה
            int rowCoordiante;
            int colCoordiante;
            bool turnIsValid = false;

            m_players[currentTurn].ChooseCoordinates(out rowCoordiante, out colCoordiante);

            if (m_board.CheckIfCellIsEmpty(rowCoordiante, colCoordiante) && m_board.CheckIfValidCoord(rowCoordiante, colCoordiante))
            {
                turnIsValid = true;
                m_board.MakeMove(rowCoordiante, colCoordiante, m_players[currentTurn].GetSymbol());
            }
            return turnIsValid;    
        }
    }
}
