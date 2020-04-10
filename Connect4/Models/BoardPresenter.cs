using System;
using Connect4.Interfaces;

namespace Connect4.Models
{
    public class BoardPresenter : IPresenter
    {
        public void Show(object board)
        {
            Console.Clear();
            var originalColor = Console.ForegroundColor;
            var lines = ((Board) board).ToString().Trim().Split('\n');
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