using System.Collections.Generic;
using System.Linq;

namespace Model
{
    internal class Board
    {
        private List<Cell> Cells {get; set;}
        private const int CellsCount = 81;
        private const int SideWidth = 9;
        public Board()
        {
            NewBoard();
        }
        public void NewBoard()
        {
            InitializeCells();
        }
        public void MovePlayer(Player player, CellCoords coords)
        {
            var cell = FindCellByCoords(coords);
            MovePlayer(player, cell);
        }
        public Cell FindCellByCoords(CellCoords coords)
        {
            return Cells.FirstOrDefault(cell => cell.Coords.Top == coords.Top && cell.Coords.Left == coords.Left);
        }
        private void InitializeCells()
        {
            Cells = new List<Cell>();
            const int leftStart = 25;
            const int topStart = 25;
            var top = topStart;
            var left = leftStart;
            const int offset = 75; 
            for(var i = 0; i < SideWidth; i++)
            {
                for(var j = 0; j<SideWidth; j++)
                {
                    var coords = new CellCoords(top, left);
                    Cells.Add(new Cell(coords));
                    left += offset;
                }
                top += offset;
                left = leftStart;
            }

            for(var i = 0; i < SideWidth; i++)
            {
                for(var j = 0; j < SideWidth; j++)
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
            const int upperIndex = SideWidth/2;
            return Cells[upperIndex];
        }
        public Cell BottomStartPosition()
        {
            const int downIndex = CellsCount - SideWidth/2 - 2;
            return Cells[downIndex];
        }
        public List<Cell> TopWinningCells()
        {
            var topWinningCells = new List<Cell>();
            for(var i = CellsCount - 1; i > CellsCount - 1 - SideWidth; i--)
            {
                topWinningCells.Add(Cells[i]);
            }
            return topWinningCells;
        }
        public List<Cell> BottomWinningCells()
        {
            var bottomWinningCells = new List<Cell>();
            for(var i = 0; i< SideWidth; i++)
            {
                bottomWinningCells.Add(Cells[i]);
            }
            return bottomWinningCells;
        }

        internal void MovePlayer(Player player, Cell cell)
        {
            player.ChangeCell(cell);
        }

        internal void PutWall(Wall wall){

        }

        internal void DropWall(Wall wall){
            
        }
    }
}