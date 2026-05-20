using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTicTacToe
{
    public abstract class Player
    {
        private int m_Id;
        private int m_Score = 0;
        //protected Board m_Board;
        private Symbols m_Symbol;

        private static int s_IdGenerator = 0;
        
        public enum Symbols
        {
            X = 'X',
            O = 'O'
        }

        public Player()
        {
            this.m_Id = s_IdGenerator;
            this.m_Symbol = (Symbols)(s_IdGenerator % 2 == 0 ? 'X' : 'O');
            // this.m_Board = i_Board;
            s_IdGenerator++;
        }

        public virtual int GetId()
        {
            return m_Id;
        }

        public virtual Symbols GetSymbol()
        {
            return m_Symbol;
        }

        public virtual int GetScore()
        {
            return m_Score;
        }

        public virtual void IncrementScore()
        {
            m_Score++;
        }

        public virtual void ChooseCoordinates(out int o_Row, out int o_Col)
        {
            o_Row = -1;
            o_Col = -1;
        }
    }
}
