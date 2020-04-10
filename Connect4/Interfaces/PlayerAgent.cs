using System;
using Connect4.Models;

namespace Connect4.Interfaces
{
    public abstract class PlayerAgent
    {
        public Player Player { get; set; }
        public abstract int GetMove(Board board);
        public virtual void DisplayInvalidMove() {}
    }
}