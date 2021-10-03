namespace Model
{
    public class Game
    {
    private Player FirstPlayer;
    private Player SecondPlayer;
    private Player CurrentPlayer;
    private Game instance;
    private bool isRunning; 
    private Board Board;
    private static object syncRoot = new Object(); 
    public Game()
    {
        isRunning = true;
        Board = Board.GetInstance();
    }
    public void ChangeCurrentPlayer()
    {
        if(CurrentPlayer == FirstPlayer)
        {
            CurrentPlayer = SecondPlayer;
        }
        else
        {
            CurrentPlayer = FirstPlayer;
        }
    }
    public void Update()
    {

    }
    public static Game GetInstance()
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