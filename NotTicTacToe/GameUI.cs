using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotTicTacToe
{
    internal class GameUI
    {
        public static void getCoordianesFromUser(int i_BoardSize, out int o_Row, out int o_Col)
        {
            Console.WriteLine("Enter row number: ");
            while (!int.TryParse(Console.ReadLine(), out o_Row))
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
        }
    }
}
