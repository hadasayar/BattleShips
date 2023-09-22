namespace BattleShipGame.Models
{
    public class Game
    {

        public List<Player> Players { get; set; }
        public Player Player0 { get; set; }

        public Player Player1 { get; set; }

        int Turn;
        public Game()
        {

        }

        public Game(List<Player> players)
        {
            Players = players;
            Player0 = players[0];
            Player1 = players[1];
            RandTurn();
        }

        public void RandTurn()
        {
            Random random = new Random();
            Turn = random.Next(2);
        }

        public bool Shotted((int, int) cell, Player currPlayer)
        {
            Player player;
            if (currPlayer.Equals(Player0))
            {
                player = Player0;
            }
            else
            {
                player = Player1;
            }
            if (player.OppBoard.BattleField[cell.Item1,cell.Item2] == CellState.Miss ||
                            Player0.OppBoard.BattleField[cell.Item1, cell.Item2] == CellState.Hit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Hit ((int, int) cell, Player currPlayer)
        {
            Player Opponent;
            if(currPlayer.Equals(Player0))
            {
                Opponent = Player1;
            }
            else
            {
                Opponent = Player0;
            }
            bool res = (Opponent.MyBoard.CellToBattleShip.ContainsKey((cell.Item1, cell.Item2)));
            return res; 

        }

        public bool Miss((int, int) cell, Player currPlayer)
        {
            Player Opponent;
            if (currPlayer.Equals(Player0))
            {
                Opponent = Player1;
            }
            else
            {
                Opponent = Player0;
            }
            bool res = (Opponent.MyBoard.CellToBattleShip.ContainsKey((cell.Item1, cell.Item2)));
            return !res;

        }

        private Player WhoIsPlaying(Guid PlayerId)
        {
            if (Player0.Id.Equals(PlayerId))
            {
                return Player0;
            }
            else if (Player1.Id.Equals(PlayerId))
                {
                return Player1;
                }
            else
            {
               return null;
            }
        }

        public string MakeMove((int, int) cell, Guid playerId)
        {
            Player currentPlayer = WhoIsPlaying(playerId);

            if (currentPlayer == null)
            {
                return "Invalid Player";
            }
            else if ((Turn == 0 && currentPlayer == Player0) || (Turn == 1 && currentPlayer == Player1))
            {
                if (Shotted(cell, currentPlayer))
                {
                    return "You already tried this cell, please try again";
                }

                if (Hit(cell, currentPlayer))
                {
                    Player opponent = (currentPlayer == Player0) ? Player1 : Player0;

                    currentPlayer.OppBoard.BattleField[cell.Item1, cell.Item2] = CellState.Hit;
                    opponent.MyBoard.BattleField[cell.Item1, cell.Item2] = CellState.Hit;

                    if (opponent.MyBoard.CellToBattleShip.TryGetValue(cell, out BattleShip damagedShip))
                    {
                        damagedShip.DamagedCells++;
                        opponent.MyBoard.CellToBattleShip.Remove(cell);

                        if (damagedShip.DamagedCells == damagedShip.Size)
                        {
                            damagedShip.IsAlive = false;
                        }
                    }

                    return "Hit";
                }
                else if (Miss(cell, currentPlayer))
                {
                    currentPlayer.OppBoard.BattleField[cell.Item1, cell.Item2] = CellState.Miss;
                    Turn = (Turn + 1) % 2;
                    return "Miss";
                }
                else
                {
                    return "There was a problem with your shooting, please try again";
                }
            }
            else
            {
                return "Ops! not your turn! please wait for your opponent's move";
            }
        }

        public bool IsGameOver()
        {

            if(Player1.MyBoard.CellToBattleShip.Count() == 0 || Player0.MyBoard.CellToBattleShip.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Player GetWinner()
        {
            if (Player1.MyBoard.CellToBattleShip.Count() == 0)
            {
                return Player0;
            }
            else if (Player0.MyBoard.CellToBattleShip.Count() == 0)
            {
                return Player1;
            }
            else
            {
                return null;
            }
        }

        public Guid WhosTurn()
        {
            if(Turn == 0)
            {
                return Player0.Id;
            }
            else
            {
                return Player1.Id;
            }
        }

    }
}
