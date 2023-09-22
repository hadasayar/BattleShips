namespace BattleShipGame.Models
{
    public class Player
    {

        public Guid Id { get; set; }
        public Board MyBoard { get; set; }
        public Board OppBoard { get; set; }


        public Player()
        {
            MyBoard = new Board(2);
            OppBoard = new Board();
            Id = Guid.NewGuid();
        }


    }
}
