using Connect4.Interfaces;

namespace Connect4.Models
{
    public class Connect4Game
    {
        private readonly IPlayerAgent[] _players = new IPlayerAgent[2];
        public Player? Winner { get; private set; }
        
        public Connect4Game(IPlayerAgent redAgent, IPlayerAgent yellowAgent)
        {
            redAgent.Player = Player.Red;
            yellowAgent.Player = Player.Yellow;
            
            _players[0] = redAgent;
            _players[1] = yellowAgent;
        }

        public void Play()
        {
            var board = new Board();
            var moveNumber = 0;

            while (!board.IsGameOver())
            {
                var player = _players[moveNumber++ % 2];
                int move;

                player.DisplayBoard(board);

                do
                {
                    move = player.GetMove(board);
                    
                    if (!board.IsInvalidMove(move)) continue;
                    
                    player.DisplayInvalidMove();
                    move = 0;
                } while (move == 0);
                
                var win = board.Move(player.Player, move);

                if (!win) continue;
                
                player.DisplayBoard(board, win: true);
                Winner = player.Player;
                break;
            }
        }
    }
}