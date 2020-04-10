using System;
using Connect4.Models;

namespace Connect4.Interfaces
{
    public abstract class IPlayerAgent
    {
        public Player Player { get; set; }
        public abstract int GetMove(Board board);
        public virtual void DisplayInvalidMove() {}

        public virtual void DisplayBoard(Board board, bool win=false)
        {
//            Console.SetCursorPosition(0, 0);
            Console.Clear();
            var originalColor = Console.ForegroundColor;
            var lines = board.ToString().Trim().Split('\n');
            foreach(var line in lines)
            {
                Console.ForegroundColor = originalColor;
                Console.Write("| ");
                foreach (var slot in line.Split(' '))
                {
                    if (slot == "0") Console.Write("  ");
                    if (slot == "1")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("* ");
                    }
                    if (slot == "2")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("* ");
                    }
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = originalColor;
            Console.WriteLine("  - - - - - - -");
            Console.WriteLine("  1 2 3 4 5 6 7");
        }
    }
    
    
}