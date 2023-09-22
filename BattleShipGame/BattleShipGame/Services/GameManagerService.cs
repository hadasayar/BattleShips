using BattleShipGame.Models;

namespace BattleShipGame.Services
{
    public class GameManagerService
    {
        public List<Player> Players = new();
        public Game game;
        

        public GameManagerService() 
        {
        
        }

        public Guid NewPlayer()
        {
            Player player;
            if (Players.Count >= 2)
            {
                return Guid.Empty;
            }
            else
            {
                player = new Player();
                Players.Add(player);
                if (Players.Count == 2)
                {
                    game = new Game(Players);
                }

                return player.Id;    
            }

        }

        public Board GetMyBoard(Guid playerId)
        {
            return (GetPlayerById(playerId).MyBoard);
        }

        public Board GetOppBoard(Guid playerId)
        {
            return (GetPlayerById(playerId).OppBoard);
        }

        private Player GetPlayerById(Guid playerId)
        {
            return Players.FirstOrDefault(p => p.Id.Equals(playerId));
        }

        public bool IsGameOver()
        {
            return game.IsGameOver();
        }

        public bool AmIWinner(Guid playerId)
        {
            return (game.GetWinner().Id == playerId);
        }
        
        public string MakeMove((int, int) Cell, Guid playerId)

        {

                return game.MakeMove(Cell, playerId);

            
        }

        public Boolean IsPlayersReady()
        {
            return Players.Count() == 2; 
        }
        public Guid WhosTurn()
        {
            return game.WhosTurn();
        }

        
    }
}
