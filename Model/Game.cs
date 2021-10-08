using System;
using System.Collections.Generic;

namespace Model
{
    public class Game
    {
        private readonly Player TopPlayer;
        public IController Controller {get; private set;}
        public IViewer Viewer {get; private set;}
        private readonly Player BottomPlayer;
        private Player CurrentPlayer;
        private Player OtherPlayer;
        private readonly GameState gameState;
        private static Game instance;
        private readonly Board Board;
        private readonly static object syncRoot = new Object(); 
        private Game(IController controller, IViewer viewer)
        {
            Controller = controller;
            Viewer = viewer;
            Board = new Board();
            Board.NewBoard();
            Cell topStartPosition = Board.TopStartPosition();
            TopPlayer = new Player(Color.Green, topStartPosition);
            Cell bottomStartPosition = Board.BottomStartPosition();
            BottomPlayer = new Player(Color.Red, bottomStartPosition);
            CurrentPlayer = BottomPlayer;
            OtherPlayer = TopPlayer;
            List<Cell> topWinningCells = Board.TopWinningCells();
            List<Cell> bottomWinningCells = Board.BottomWinningCells();
            gameState = new GameState(topWinningCells, bottomWinningCells);
        }
        private void ChangeCurrentPlayer()
        {
            if(CurrentPlayer == BottomPlayer)
            {
                OtherPlayer = BottomPlayer;
                CurrentPlayer = TopPlayer;
            }
            else
            {
                OtherPlayer = TopPlayer;
                CurrentPlayer = BottomPlayer;
            }
        }
        private bool CheckWinning(){
            if(CurrentPlayer == BottomPlayer)
            {
                return gameState.CheckBottompWinning(BottomPlayer);

            }
            else
            {
                return gameState.CheckTopWinning(TopPlayer);
            }
        }
        public void Update()
        {
            switch(Controller.GetAction())
            {
                case Action.MakeMove:
                        Cell cell = Controller.GetCell();
                    if (!MoveValidator.IsValidMove(cell, CurrentPlayer, OtherPlayer))
                        {      
                            Board.MovePlayer(CurrentPlayer, cell);
                            var playerCoords = CurrentPlayer.CurrentCell.Coords;
                            Viewer.RenderPlayer(playerCoords.Top, playerCoords.Left);
                            CheckWinning();
                            ChangeCurrentPlayer();
                        }
                        break;
                case Action.PlaceWall:
                    Wall wall = Controller.GetWall();
                    if(CurrentPlayer.PlaceWall())
                    {
                        Board.PutWall(wall);
                        if(MoveValidator.IsThereAWay(gameState, TopPlayer, BottomPlayer))
                        {
                            var wallCoords = wall.Coords;
                            Viewer.RenderWall(wallCoords.Top, wallCoords.Left);
                        }
                        else
                        {
                            Board.DropWall(wall);
                            CurrentPlayer.UnPlaceWall();
                        }
                    }
                    Viewer.RenderRemainingWalls(TopPlayer.WallsCount, BottomPlayer.WallsCount);
                    break;
            }
            if(!gameState.InPlay)
            {
                Viewer.RenderEnding();
            }
            
        }
        public static Game GetInstance(IController controller, IViewer viewer)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Game(controller, viewer);
                    }
                }   
            }
            return instance;
        }
    }
}