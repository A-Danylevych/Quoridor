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
            for(int j = 0; j < CellsCount; j++)
            {
                
            }
        }
    }
    public static Board getInstance(string name)
    {
        if (instance == null)
        {
            lock (syncRoot)
            {
                if (instance == null)
                    instance = new Board(name);
            }
        }
        return instance;
    }

    }
}