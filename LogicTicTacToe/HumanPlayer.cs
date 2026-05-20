using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTicTacToeLogic
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(Board i_Board) : base(i_Board)
        {
        }
        public override void ChooseCoordinates(out int o_Row, out int o_Col)
        {
            o_Row = -1;
            o_Col = -1;

            Console.WriteLine("Enter row number: ");
            while(!int.TryParse(Console.ReadLine(), out o_Row)) 
            { 
                Console.WriteLine("Row must be a number");
                Console.WriteLine("Enter row number: ");
            }

            Console.WriteLine("Enter column number: ");
            while (!int.TryParse(Console.ReadLine(), out o_Col))
            {
                Console.WriteLine("Column must be a number");
                Console.WriteLine("Enter column number: ");
            }

            o_Col--;
            o_Row--;
        }
    }
}
