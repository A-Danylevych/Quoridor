using System.Collections.Generic;

namespace Model
{
    class Board
    {
        private List<Cell> Cells {get; set;}
        private const int CellsCount = 81;
        private const int SideWidth = 9;

        private static object syncRoot = new Object();

        protected Board()
        {
            NewBoard();
        }
        public void NewBoard()
        {
            InitializeCells();
        }
        private void InitializeCells()
        {
            Cells = new List<Cell>();
            for(int i = 0; i < CellsCount; i++)
            {
                Cells.Add(new Cell());
            }

            for(int i = 0; i < SideWidth; i++)
            {
                for(int j = 0; j < SideWidth; j++)
                {
                    if(i != SideWidth-1)
                    {
                       Cells[i*SideWidth + j].BottomConnect(Cells[(i+1)*SideWidth + j]);
                    }
                    if(j != SideWidth-1)
                    {
                        Cells[i*SideWidth + j].RightConnect(Cells[i*SideWidth + j+1]);
                    }
                    if(j != 0)
                    {
                        Cells[i*SideWidth + j].LeftConnect(Cells[i*SideWidth + j-1]);
                    }
                    if(i != 0)
                    {
                        Cells[i*SideWidth + j].UpperConnect(Cells[(i-1)*SideWidth + j]);
                    }
                }
            }
        }
        public Cell TopStartPosition()
        {
            int upperIndex = SideWidth/2;
            return Cells[upperIndex];
        }
        public Cell BottomStartPosition()
        {
            int downIndex = CellsCount - SideWidth/2 - 2;
            return Cells[downIndex];
        }
        private void PlacePlayer(Player player, Cell cell)
        {
            player.ChangeCell(cell);
        }
        public void MovePlayer(Player player, Cell cell)
        {
            player.ChangeCell(cell);
        }
        public static Board GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Board(name);
                    }
                }
            }
        return instance;
        }

    }
}