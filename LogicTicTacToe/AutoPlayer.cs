using System;
namespace NotTicTacToeLogic
{
    public class AutoPlayer : Player
    {

        public override bool HasCoordinates(out int o_Row, out int o_Col)
        {
            Random random = new Random();
            o_Row = random.Next(0, m_Board.getBoardSize());
            o_Col = random.Next(0, m_Board.getBoardSize());


            while (m_Board.CheckIfCellIsEmpty(o_Row, o_Col) == false)
            {
                o_Row = random.Next(0, m_Board.getBoardSize());
                o_Col = random.Next(0, m_Board.getBoardSize());
            }
            return true;
        }
    }
}
