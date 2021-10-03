namespace Model
{
    public class Game
    {
        private Player UpperPlayer;
        private Player DownPlayer;
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
        if(CurrentPlayer == DownPlayer)
        {
            CurrentPlayer = UpperPlayer;
        }
        else
        {
            CurrentPlayer = DownPlayer;
        }
    }
        public void Update()
        {
            ChangeCurrentPlayer();
        }
        public static Game GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Game();
                    }
                }   
            }
            return instance;
        }
    }
}