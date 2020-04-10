using System;
using System.Text;
using Connect4.Models;
using Xunit;

namespace Connect4Test
{
    public class BoardTests
    {
        [Fact]
        public void Move_FirstMove()
        {
            var board = new Board();
            var win = board.Move(Player.Red, 5);

            var expected = new StringBuilder();
            expected.AppendLine("0 0 0 0 0 0 0");
            expected.AppendLine("0 0 0 0 0 0 0");
            expected.AppendLine("0 0 0 0 0 0 0");
            expected.AppendLine("0 0 0 0 0 0 0");
            expected.AppendLine("0 0 0 0 0 0 0");
            expected.AppendLine("0 0 0 0 1 0 0");
            
            Assert.False(win);
            Assert.Equal(expected.ToString(), board.ToString());
        }
        
        [Fact]
        public void Move_SecondMove()
        {
            var board = new Board(
                new [,]
                {
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,1,0,0}
                });
            
            var win = board.Move(Player.Yellow, 5);

            var expected = new StringBuilder();
            expected.AppendLine("0 0 0 0 0 0 0");
            expected.AppendLine("0 0 0 0 0 0 0");
            expected.AppendLine("0 0 0 0 0 0 0");
            expected.AppendLine("0 0 0 0 0 0 0");
            expected.AppendLine("0 0 0 0 2 0 0");
            expected.AppendLine("0 0 0 0 1 0 0");
            
            Assert.False(win);
            Assert.Equal(expected.ToString(), board.ToString());
        }
        
        [Fact]
        public void Move_InvalidMove()
        {
            var board = new Board(
                new [,]
                {
                    {0,0,0,0,2,0,0},
                    {0,0,0,0,1,0,0},
                    {0,0,0,0,2,0,0},
                    {0,0,0,0,1,0,0},
                    {0,0,0,0,2,0,0},
                    {0,0,0,0,1,0,0}
                });

            Assert.Throws<InvalidOperationException>(() => board.Move(Player.Red, 5));
        }
        
        [Fact]
        public void Move_WinningMove_RightRow()
        {
            var board = new Board(
                new [,]
                {
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,1,1,1,0,0}
                });
            
            var win = board.Move(Player.Red, 6);

            Assert.True(win);
        }
        
        [Fact]
        public void Move_WinningMove_LeftRow()
        {
            var board = new Board(
                new [,]
                {
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,1,1,1,0,0}
                });
            
            var win = board.Move(Player.Red, 2);

            Assert.True(win);
        }
        
        [Fact]
        public void Move_WinningMove_up()
        {
            var board = new Board(
                new [,]
                {
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,1,0,0},
                    {0,0,0,0,1,0,0},
                    {0,0,0,0,1,0,0}
                });
            
            var win = board.Move(Player.Red, 5);

            Assert.True(win);
        }
        
        [Fact]
        public void Move_WinningMove_upLeftDiagonal()
        {
            var board = new Board(
                new [,]
                {
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,1,2},
                    {0,0,0,0,1,1,2},
                    {0,0,0,1,1,2,2}
                });
            
            var win = board.Move(Player.Red, 7);

            Assert.True(win);
        }
        
        [Fact]
        public void Move_WinningMove_upRightDiagonal()
        {
            var board = new Board(
                new [,]
                {
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {2,1,0,0,0,0,0},
                    {2,1,1,0,0,0,0},
                    {2,2,1,1,0,0,0}
                });
            
            var win = board.Move(Player.Red, 1);

            Assert.True(win);
        }
        
        [Fact]
        public void Move_WinningMove_downRightDiagonal()
        {
            var board = new Board(
                new [,]
                {
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {1,0,0,0,0,0,0},
                    {2,1,0,0,0,0,0},
                    {2,1,1,0,0,0,0},
                    {2,2,1,0,0,0,0}
                });
            
            var win = board.Move(Player.Red, 4);

            Assert.True(win);
        }
        
        [Fact]
        public void Move_WinningMove_downLeftDiagonal()
        {
            var board = new Board(
                new [,]
                {
                    {2,0,0,2,0,0,0},
                    {1,0,0,1,0,1,1},
                    {1,2,1,2,0,2,1},
                    {2,1,2,1,2,2,2},
                    {2,2,2,1,2,1,2},
                    {1,1,1,2,1,1,1}
                });
            
            var win = board.Move(Player.Yellow, 3);

            Assert.True(win);
        }
        
        [Fact]
        public void Move_WinningMove_lastMoveInMiddle()
        {
            var board = new Board(
                new [,]
                {
                    {1,0,2,2,0,0,2},
                    {2,0,1,1,2,1,1},
                    {2,0,1,2,1,1,1},
                    {1,0,1,1,2,2,2},
                    {2,0,2,2,1,2,1},
                    {2,1,1,2,1,2,1}
                });
            
            var win = board.Move(Player.Yellow, 2);

            Assert.True(win);
        }


    }
}