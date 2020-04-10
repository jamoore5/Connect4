using System;
using System.Linq;
using Connect4.Extension;
using Connect4.Interfaces;

namespace Connect4.Models
{
    public class SemiRandomAgent : RandomAgent
    {
        public Player OtherPlayer { get; set; }
        
        private Board _board;
        public override int GetMove(Board board)
        {
            _board = board.Clone();

            var winningMoves = WinningMoves(board);
            if (winningMoves.Any())
                return winningMoves.Random();
     
            var losingMoves = LosingMoves(board);
            if (losingMoves.Any())
                return losingMoves.Random();

            var preferredNextMoves = PreferredNextMoves(board);
            if (preferredNextMoves.Any())
                return preferredNextMoves.Random();

            return base.GetMove(board);
        }

        private int[] WinningMoves(Board board)
        {
            return Enumerable.Range(1, 7).Where(move => !_board.IsInvalidMove(move))
                .Where(IsWiningMove).ToArray();
        }
        
        private int[] LosingMoves(Board board)
        {
            return Enumerable.Range(1, 7).Where(move => !_board.IsInvalidMove(move))
                .Where(IsLosingMove).ToArray();
        }

        private int[] PreferredNextMoves(Board board)
        {
            return Enumerable.Range(1, 7).Where(move => !_board.IsInvalidMove(move))
                .Where(move => !IsMoveTheLetTheOtherPlayerWin(move)).ToArray();
        }

        private bool IsMoveTheLetTheOtherPlayerWin(int column)
        {
            var clonedBoard = _board.Clone();
            clonedBoard.Move(Player, column);
            if (clonedBoard.IsInvalidMove(column)) return false;
            return clonedBoard.Move(OtherPlayer, column);
        }

        private bool IsLosingMove(int column)
        {
            var win = _board.Clone().Move(OtherPlayer, column);
            return win;
        }

        private bool IsWiningMove(int column)
        {
            var win = _board.Clone().Move(Player, column);
            return win;
        }
    }
}