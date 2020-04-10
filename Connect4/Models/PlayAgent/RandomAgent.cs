using System;
using Connect4.Interfaces;

namespace Connect4.Models.PlayAgent
{
    public class RandomAgent : PlayerAgent
    {
        protected static readonly Random Random = new Random();
     
        public override int GetMove(Board board)
        {
            return Random.Next(1, 7);
        }
    }
}