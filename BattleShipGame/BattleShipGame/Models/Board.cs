using System.Runtime.InteropServices;
using System.Text;

namespace BattleShipGame.Models
{
    public class Board
    {
        public int NumOfShips { get; set; }

        public CellState[,] BattleField { get; set; }

        public Dictionary<(int, int), BattleShip> CellToBattleShip;

        public Board() 
        {
            this.BattleField = new CellState[10,10];
            this.CellToBattleShip = new Dictionary<(int, int), BattleShip>();

            CreateNewBoard();
        }

        public Board(int num)
        {
            this.BattleField = new CellState[10, 10];
            this.CellToBattleShip = new Dictionary<(int, int), BattleShip>();
            this.NumOfShips = num;

            CreateNewBoard();
            CreateRandomBoard(NumOfShips);
        }


        public void CreateNewBoard()
        {
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                    BattleField[i, j] = CellState.Empty;
            }
        }

        public bool IsOccupied((int,int) Cordinate)
        {

            return this.CellToBattleShip.ContainsKey(Cordinate);
        }

        public void CreateRandomBoard(int numOfShips)
        {
            CreateRandomDict(NumOfShips);
            foreach (var item in CellToBattleShip)
            {
                
                BattleField[item.Key.Item1, item.Key.Item2] = CellState.Ship;
            }
        }

        private void CreateRandomDict(int numOfShips)
        {
            int cnt = 0;
            

            // Create instances of Battleship for each ship type
            BattleShip carrier = new BattleShip("Carrier");
            BattleShip battleship = new BattleShip("Battleship");
            BattleShip cruiser = new BattleShip("Cruiser");
            BattleShip submarine = new BattleShip("Submarine");
            BattleShip destroyer = new BattleShip("Destroyer");

            List<BattleShip> list = new List<BattleShip>()
            {
                carrier, battleship, cruiser, submarine, destroyer
            };
             foreach(BattleShip ship in list)
            {
                (int, int)[] Cordinates = FindRandomCordinates(ship.Size);
                foreach((int,int) cell in Cordinates)
                {
                    if (!IsOccupied(cell))
                    {
                        cnt++;
                        CellToBattleShip.Add(cell, ship);
                    }
                    else
                    {
                        //how to handle new codinates ask adir
                    }
                }
                if (cnt == NumOfShips)
                {
                break;
                }
            }
        }

        private (int, int)[] FindRandomCordinates(int size)
        {
            Random random = new Random();
            (int, int)[] Cordinates = new (int, int)[size]; 
            bool vertical = random.Next(2) == 0; // 0 for vertical 1 for horizontal
            int row = 0;
            int col = random.Next(10);

            if (vertical)
            {
                while (col + size > 9)
                {
                    col = random.Next(10);
                }

                row = random.Next(10);

                for (int i = 0; i < size; i++)
                {
                    Cordinates[i] = (row , col + i);
                }
            }
            else
            {
                while (row + size > 9)
                {
                    row = random.Next(10);
                }

                col = random.Next(10);

                for (int i = 0; i < size; i++)
                {
                    Cordinates[i] = (row + i, col);
                }
            }
            return Cordinates;

        }

        public string GetBoardAsString()
        {
            StringBuilder boardString = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    
                    switch (BattleField[i, j])
                    {
                        case CellState.Empty:
                            boardString.Append('~'); 
                            break;
                        case CellState.Carrier:
                            boardString.Append('S'); 
                            break;
                        case CellState.Battleship:
                            boardString.Append('S'); 
                            break;
                        case CellState.Cruiser:
                            boardString.Append('S'); 
                            break;
                        case CellState.Submarine:
                            boardString.Append('S'); 
                            break;
                        case CellState.Destroyer:
                            boardString.Append('S'); 
                            break;
                        case CellState.Ship:
                            boardString.Append('S');
                            break;
                        case CellState.Hit:
                            boardString.Append('*');
                            break;
                        case CellState.Miss:
                            boardString.Append('X');
                            break;
                          
                    }

                    boardString.Append(' '); 
                }
                boardString.AppendLine(); 
                boardString.AppendLine(); 
            }

            return boardString.ToString();
        }
    }
}
