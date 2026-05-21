using System;
namespace NotTicTacToeLogic
{
    public class AutoPlayer : Player
    {
        public override bool HasCoordinates(out int o_Row, out int o_Col)
        {
            Random random = new Random();
            o_Row = random.Next(0, m_Board.GetBoardSize());
            o_Col = random.Next(0, m_Board.GetBoardSize());

            while (m_Board.IsCellEmpty(o_Row, o_Col) == false)
            {
                o_Row = random.Next(0, m_Board.GetBoardSize());
                o_Col = random.Next(0, m_Board.GetBoardSize());
            }
            return true;
        }
      
    }
}
