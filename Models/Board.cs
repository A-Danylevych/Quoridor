using System.Collections.Generic;

namespace Model
{
    class Board
    {
    List<Cell> Cells {get; set;}
    private static object syncRoot = new Object();

    protected Board()
    {
        
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