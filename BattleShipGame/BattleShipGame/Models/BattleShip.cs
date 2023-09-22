using System.Xml.Linq;

namespace BattleShipGame.Models
{
    public class BattleShip
    {
        public string Name { get; private set; }
        public int Size { get; private set; }

        Dictionary<string, int> shipSizes = new Dictionary<string, int>
        {
            { "Carrier", 5 },
            { "Battleship", 4 },
            { "Cruiser", 3 },
            { "Submarine", 2 },
            { "Destroyer", 1 }
        };

        public int DamagedCells = 0;

        public bool IsAlive = true;

        public BattleShip (string name){

            Name = name;
            Size = shipSizes[name];

        }
    }
    
}
