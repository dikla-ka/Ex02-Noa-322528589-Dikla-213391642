using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTicTacToe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameUI gameUI = new GameUI();
            gameUI.setGameBoardSize();
            gameUI.setGameMode();
        }
    }
}
