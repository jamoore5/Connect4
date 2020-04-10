using System;
using System.Linq;
using System.Text;
using Connect4.Extension;

namespace Connect4.Models
{
    public class Board
    {
        private readonly int[,] _board;
        private const int Rows = 6;
        private const int Columns = 7;

        public Board()
        {
            _board = new int[Rows,Columns];
        }
        
        public Board(int[,] initialBoard)
        {
            if (initialBoard.GetUpperBound(0) + 1 != Rows || initialBoard.GetUpperBound(1) + 1 != Columns)
                throw new ArgumentException($"Invalid Board: size must be {Rows} by {Columns}");
            _board = initialBoard;
        }

        public bool Move(Player player, int column)
        {
            var col = column - 1;
            var row = Enumerable.Range(0, Rows).Reverse().First(i => _board[i, col] == 0);

            _board[row, col] = (int) player;

            return IsWinningMove(row, col);
        }
        
        public bool IsGameOver()
        {
            for (var col = 0; col < Columns; col++)
            {
                if (_board[0, col] == 0) return false;
            }

            return true;
        }

        private bool IsWinningMove(int row, int col)
        {
            var player = (Player) _board[row, col];

            return IsHorizontalWin(player, row, col) ||
                   IsVerticalWin(player, row, col) ||
                   IsMainDiagonalWin(player, row, col) ||
                   IsLeadingDiagonalWin(player, row, col);
        }

        private bool IsHorizontalWin(Player player, int row, int col)
        {
            // move as far left as possible
            while (col > 0)
            {
                if ((Player) _board[row, col - 1] == player) col--;
                else break;
            }

            // count the number of consecutive moves for the player moving right
            var count = 0;
            while (col < Columns && (Player)_board[row, col] == player)
            {
                count++;
                col++;
            }
            
            return (count >= 4);
        }
        
        private bool IsVerticalWin(Player player, int row, int col)
        {
            // move as far up as possible
            while (row > 0)
            {
                if ((Player)_board[row - 1, col] == player) row--;
                else break;
            }

            // count the number of consecutive moves for the player moving down
            var count = 0;
            while (row < Rows && (Player)_board[row, col] == player)
            {
                count++;
                row++;
            }
            
            return (count >= 4);
        }
        
        private bool IsMainDiagonalWin(Player player, int row, int col)
        {
            // move as far up as possible
            while (row > 0 && col > 0)
            {
                if ((Player) _board[row - 1, col - 1] == player)
                {
                    row--;
                    col--;
                }
                else
                    break;
            }

            // count the number of consecutive moves for the player moving down
            var count = 0;
            while (row < Rows && col < Columns && (Player)_board[row, col] == player)
            {
                count++;
                row++;
                col++;
            }
            
            return (count >= 4);
        }
        
        private bool IsLeadingDiagonalWin(Player player, int row, int col)
        {
            // move as far up as possible
            while (row > 0  && col < Columns - 1)
            {
                if ((Player) _board[row - 1, col + 1] == player)
                {
                    row--;
                    col++;
                }
                else
                    break;
            }

            // count the number of consecutive moves for the player moving down
            var count = 0;
            while (row < Rows && col >= 0 && (Player)_board[row, col] == player)
            {
                count++;
                row++;
                col--;
            }
            
            return (count >= 4);
        }

        public override string ToString()
        {
            return string.Concat(string.Join("\n", 
                _board.GetRows().Select(row => string.Join(" ", row))), "\n");
        }

        public bool IsInvalidMove(int column)
        {
            var col = column - 1;
            var row = Enumerable.Range(0, Rows).Reverse().FirstOrDefault(i => _board[i, col] == 0);

            if (row == 0)
            {
                return _board[0, col] != 0;
            }

            return false;
        }

        public Board Clone()
        {
            return new Board((int[,])_board.Clone());
        }
    }
}