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
        public void MovePlayer(Player player, CellCoords coords)
        {
            Cell cell = FindCellByCoords(coords);
            MovePlayer(player, cell);
        }
        private Cell FindCellByCoords(CellCoords coords)
        {
            foreach(Cell cell in Cells)
            {
                if(cell.Coords.Top == coords.Top && cell.Coords.Left == coords.Left)
                {
                    return cell;
                }
            }
            return null;
        }
        private void InitializeCells()
        {
            Cells = new List<Cell>();
            int leftStart = 25;
            int topStart = 25;
            int top = topStart;
            int left = leftStart;
            int offset = 75; 
            for(int i = 0; i < SideWidth; i++)
            {
                for(int j = 0; j<SideWidth; j++)
                {
                    CellCoords coords = new CellCoords(top, left);
                    Cells.Add(new Cell(coords));
                    left += offset;
                }
                top += offset;
                left = leftStart;
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
        public List<Cell> TopWinningCells()
        {
            List<Cell> topWinningCells = new List<Cell>();
            for(int i = CellsCount - 1; i > CellsCount - 1 - SideWidth; i--)
            {
                topWinningCells.Add(Cells[i]);
            }
            return topWinningCells;
        }
        public List<Cell> BottomWinningCells()
        {
            List<Cell> bottomWinningCells = new List<Cell>();
            for(int i = 0; i< SideWidth; i++)
            {
                bottomWinningCells.Add(Cells[i]);
            }
            return bottomWinningCells;
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