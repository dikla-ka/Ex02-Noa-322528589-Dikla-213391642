using System;
namespace NotTicTacToeLogic
{
    public class AutoPlayer : Player
    {
        public AutoPlayer(Board i_Board) : base(i_Board)
        {
        }

        public void ChooseCoordinates(out int o_Row, out int o_Col)
        {
            Random random = new Random();
            o_Row = random.Next(0, m_board.getBoardSize());
            o_Col = random.Next(0, m_board.getBoardSize());

            
            while (m_board.CheckIfCellIsEmpty(o_Row, o_Col) == false)
            {
                o_Row = random.Next(0, m_board.getBoardSize());
                o_Col = random.Next(0, m_board.getBoardSize());
            }
        }
    }
}
