using System.Collections.Generic;

namespace Model
{
    public class Game
    {
        private Player TopPlayer;
        public IController Controller {get; private set;}
        public IViewer Viewer {get; private set;}
        private Player BottomPlayer;
        private Player CurrentPlayer;
        private GameState gameState;
        private Game instance;
        private Board Board;
        private static object syncRoot = new Object(); 
        public Game(IController controller, IViewer viewer)
        {
            Controller = controller;
            viewer = viewer;
            isRunning = true;
            Board = Board.GetInstance();
            Board.NewBoard();
            Cell topStartPosition = Board.TopStartPosition();
            TopPlayer = new Player(topStartPosition);
            Cell bottomStartPosition = Board.BottomStartPosition();
            BottomPlayer = new Player(bottomStartPosition);
            CurrentPlayer = BottomPlayer;
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
            switch(Controller.WaitForAction)
            {
                case Action.MakeMove:

                        Viewer.RenderPossibleCellsToMove();             
                        break;
                case Action.PlaceWall:
                    break;
            }
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