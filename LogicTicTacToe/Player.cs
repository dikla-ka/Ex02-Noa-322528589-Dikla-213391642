using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTicTacToeLogic
{
    public class Player
    {
        private int m_Id;
        private int m_Score = 0;
        private Symbols m_Symbol;
        private static int m_IdGenerator = 0;
        
        public enum Symbols
        {
            X = 'X',
            O = 'O'
        }

        public Player()
        {
            this.m_Id = m_IdGenerator;
            this.m_Symbol = (Symbols)(m_IdGenerator % 2 == 0 ? 'X' : 'O');
            m_IdGenerator++;
        }

        public int GetId()
        {
            return m_Id;
        }

        public Symbols GetSymbol()
        {
            return m_Symbol;
        }
    }
}
