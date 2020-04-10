using System.Linq;
using Connect4.Extension;

namespace Connect4.Models.PlayAgent
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
                .Where(move => !IsMoveThatLetTheOtherPlayerWin(move)).ToArray();
        }

        private bool IsMoveThatLetTheOtherPlayerWin(int column)
        {
            var clonedBoard = _board.Clone();
            clonedBoard.Move(Player, column);
            if (clonedBoard.IsInvalidMove(column)) return false;
            return clonedBoard.Move(OtherPlayer, column);
        }

        private bool IsLosingMove(int column)
        {
            return _board.Clone().Move(OtherPlayer, column);
        }

        private bool IsWiningMove(int column)
        {
            return _board.Clone().Move(Player, column);
        }
    }
}