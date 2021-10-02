namespace Model
{
    class Game
    {
    private Game instance;
    private bool isRunning; 
    private Board Board;
    private static object syncRoot = new Object(); 
    protected Game()
    {
        isRunning = true;
        Board = Board.getInstance();
    }
    public static Game getInstance()
    {
        if (instance == null)
        {
            lock (syncRoot)
            {
                if (instance == null)
                    instance = new Game();
            }
        }
        return instance;
    }
    }
}