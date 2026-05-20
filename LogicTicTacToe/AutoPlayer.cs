using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTicTacToeLogic
{
    public class AutoPlayer : Player
    {
        public AutoPlayer(Board i_Board) : base(i_Board)
        {
        }

        public override void ChooseCoordinates(out int o_Row, out int o_Col)
        {
            o_Row = -1;
            o_Col = -1;
            Random random = new Random();
            while (m_board.CheckIfCellIsEmpty(o_Row, o_Col) == false)
            {
                o_Row = random.Next(0, m_board.getBoardSize());
                o_Col = random.Next(0, m_board.getBoardSize());
            }
        }
    }
}
