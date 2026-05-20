namespace NotTicTacToeLogic
{
    public abstract class Player
    {
        private int m_Id;
        private int m_Score = 0;
        protected Board m_Board = null;
        private Symbols m_Symbol;

        private static int s_IdGenerator = 0;

        public Player()
        {
            m_Id = s_IdGenerator;
            m_Symbol = (Symbols)(s_IdGenerator % 2 == 0 ? Symbols.X : Symbols.O);
            s_IdGenerator++;
        }

        public virtual void ResetScore()
        {
            m_Score = 0;
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

        public virtual void SetBoard (Board board)
        {
            m_Board = board;
        }

        public virtual bool HasCoordinates(out int o_Row, out int o_Col) 
        {
            o_Row = -1;
            o_Col = -1;
            return false;
        }
    }
}
