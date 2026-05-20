using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTicTacToe
{
    public class AutoPlayer : Player
    {
        public override void ChooseCoordinates(out int o_Row, out int o_Col)
        {
            o_Row = -1;
            o_Col = -1;
            Random random = new Random();
            //o_Row = random.Next(0, m_Board.GetSize());
            //o_Col = random.Next(0, m_Board.GetSize());
        }
    }
}
