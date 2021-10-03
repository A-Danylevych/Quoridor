using System.Collections.Generic;

namespace Model
{
    public class Game
    {
        private Player TopPlayer;
        private Player BottomPlayer;
        private Player CurrentPlayer;
        private GameState gameState;
        private Game instance;
        private Board Board;
        private static object syncRoot = new Object(); 
        public Game()
        {
            isRunning = true;
            Board = Board.GetInstance();
            Cell topStartPosition = Board.TopStartPosition();
            TopPlayer = new Player(topStartPosition);
            Cell bottomStartPosition = Board.BottomStartPosition();
            BottomPlayer = new Player(bottomStartPosition);
            List<Cell> topWinningCells = Board.TopWinningCells();
            List<Cell> bottomWinningCells = Board.BottomWinningCells();
            gameState = new GameState(topWinningCells, bottomWinningCells);
        }
        public void ChangeCurrentPlayer()
        {
            if(CurrentPlayer == BottomPlayer)
            {
                CurrentPlayer = TopPlayer;
            }
            else
            {
                CurrentPlayer = BottomPlayer;
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