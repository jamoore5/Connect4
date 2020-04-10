using System;
using Connect4.Models;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            var game = new Connect4Game(new SemiRandomAgent{OtherPlayer = Player.Yellow},new HumanAgent());
            game.Play();
            
            Console.WriteLine(game.Winner is null ? "Tie Game                             " : $"{game.Winner} Wins                                       ");
        }
    }
}