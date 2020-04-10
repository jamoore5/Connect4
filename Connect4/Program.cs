using System;
using Connect4.Models;
using Connect4.Models.PlayAgent;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            var game = new Connect4Game(new SemiRandomAgent{OtherPlayer = Player.Yellow},new SemiRandomAgent{OtherPlayer = Player.Red});
            game.Play();
            
            Console.WriteLine(game.Winner is null ? "Tie Game" : $"{game.Winner} Wins");
        }
    }
}