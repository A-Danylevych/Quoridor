using System;
using System.Collections.Generic;

namespace Model
{
    public class Game
    {
        private readonly Player _topPlayer;
        private IController Controller {get; set;}
        private IViewer Viewer {get; set;}
        private readonly Player _bottomPlayer;
        private Player _currentPlayer;
        private Player _otherPlayer;
        private readonly GameState _gameState;
        private static Game _instance;
        private readonly Board _board;
        private static readonly object SyncRoot = new object();
        private bool blocked;
        private Game(IController controller, IViewer viewer)
        {
            Controller = controller;
            Viewer = viewer;
            _board = new Board();
            _board.NewBoard();
            var topStartPosition = _board.TopStartPosition();
            _topPlayer = new Player(Color.Green, topStartPosition);
            var bottomStartPosition = _board.BottomStartPosition();
            _bottomPlayer = new Player(Color.Red, bottomStartPosition);
            _currentPlayer = _bottomPlayer;
            _otherPlayer = _topPlayer;
            var topWinningCells = _board.TopWinningCells();
            var bottomWinningCells = _board.BottomWinningCells();
            _gameState = new GameState(topWinningCells, bottomWinningCells);
            blocked = false;
        }
        private void ChangeCurrentPlayer()
        {
            if(_currentPlayer == _bottomPlayer)
            {
                _otherPlayer = _bottomPlayer;
                _currentPlayer = _topPlayer;
            }
            else
            {
                _otherPlayer = _topPlayer;
                _currentPlayer = _bottomPlayer;
            }
        }
        private bool CheckWinning()
        {
            return _currentPlayer == _bottomPlayer ? _gameState.CheckBottomWinning(_bottomPlayer) : 
                _gameState.CheckTopWinning(_topPlayer);
        }

        private void RenderPlayer(int top, int left)
        {
            if (_currentPlayer == _bottomPlayer)
            {
                Viewer.RenderBottomPlayer(top, left);
            }
            else
            {
                Viewer.RenderUpperPlayer(top, left);
            }
        }

        public void Update()
        {
            switch (Controller.GetAction())
                {
                    case Action.MakeMove:
                        if (blocked)
                        {
                            return;
                        }
                        var cell = Controller.GetCell();
                        if (MoveValidator.IsValidMove(cell, _currentPlayer, _otherPlayer))
                        {
                            _board.MovePlayer(_currentPlayer, cell);
                            var playerCoords = _currentPlayer.CurrentCell.Coords;
                            RenderPlayer(playerCoords.Top, playerCoords.Left);
                            CheckWinning();
                            ChangeCurrentPlayer();
                        }

                        blocked = true;
                        break;
                    case Action.PlaceWall:
                        if(blocked)
                            return;
                        var wall = Controller.GetWall();
                        if (_currentPlayer.PlaceWall())
                        {
                            var wallCoords = wall.Coords; 
                            Viewer.RenderWall(wallCoords.Top, wallCoords.Left);
                            ChangeCurrentPlayer();
                            //_board.PutWall(wall);
                            // if (!MoveValidator.IsThereAWay(_gameState, _topPlayer, _bottomPlayer))
                            // {
                            //     var wallCoords = wall.Coords;
                            //     Viewer.RenderWall(wallCoords.Top, wallCoords.Left);
                            //     ChangeCurrentPlayer();
                            // }
                            // else
                            // {
                            //     //_board.DropWall(wall);
                            //     _currentPlayer.UnPlaceWall();
                            // }
                        }

                        Viewer.RenderRemainingWalls(_topPlayer.WallsCount, _bottomPlayer.WallsCount);
                        blocked = true;
                        break;
                    case Action.NextTask:
                        blocked = false;
                        break;
                    default:
                        throw new ArgumentException();
                }

                if (!_gameState.InPlay)
                {
                    Viewer.RenderEnding("Game over!");
                }
        }

        public static Game GetInstance(IController controller, IViewer viewer)
        {
            if(_instance == null)
            {
                lock (SyncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new Game(controller, viewer);
                    }
                }   
            }
            return _instance;
        }
    }
}