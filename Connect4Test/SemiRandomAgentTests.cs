using Connect4.Models;
using Connect4.Models.PlayAgent;
using Xunit;

namespace Connect4Test
{
    public class SemiRandomAgentTests
    {
        [Fact]
        public void Move_DoNotPlay6()
        {
            var board = new Board(
                new [,]
                {
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0},
                    {0,0,0,0,2,0,0},
                    {1,0,0,2,1,1,0},
                    {2,2,2,1,1,2,1}
                });
            
            var agent = new SemiRandomAgent{Player = Player.Red, OtherPlayer = Player.Yellow};

            for (var i = 0; i < 10_000; i++)
            {
                Assert.NotEqual(6, agent.GetMove(board.Clone()));
            }
        }
        
        [Fact]
        public void Move_DoNotPlay2()
        {
            var board = new Board(
                new [,]
                {
                    {0,0,1,0,0,0,1},
                    {0,0,1,0,0,0,1},
                    {0,0,1,0,0,0,2},
                    {0,0,2,0,0,0,1},
                    {2,2,1,2,2,0,2},
                    {2,1,1,2,2,0,1}
                });
            
            var agent = new SemiRandomAgent{Player = Player.Red, OtherPlayer = Player.Yellow};

            for (var i = 0; i < 10_000; i++)
            {
                Assert.NotEqual(2, agent.GetMove(board.Clone()));
            }
        }
    }
}