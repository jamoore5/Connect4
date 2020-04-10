using System;
using Connect4.Interfaces;

namespace Connect4.Models
{
    public class HumanAgent : IPlayerAgent
    {
        public override int GetMove(Board board)
        {
            int column;
            
            Console.Write($"{Player} Player - Choose a column [1-7]: ");
            var input = Console.ReadLine();

            while (!int.TryParse(input, out column) || column < 1 || column > 7)
            {
                DisplayInvalidMove();
                Console.Write($"{Player} Player - Choose a column [1-7]: ");
                input = Console.ReadLine();
            }

            return column;
        }

        public override void DisplayInvalidMove()
        {
            Console.WriteLine("Invalid Choice!                           ");
        }
    }
}