using System;
using Connect4.Interfaces;

namespace Connect4.Models
{
    public class RandomAgent : IPlayerAgent
    {
        protected static readonly Random Random = new Random();
     
        public override int GetMove(Board board)
        {
            return Random.Next(1, 7);
        }

        public override void DisplayBoard(Board board, bool win=false)
        {
            if(win)
                base.DisplayBoard(board, win);
        }
    }
}