using System.Collections.Generic;

namespace Model
{
    class GameState
    {
        public bool inPlay {get; private set;}
        public List<Cell> TopWinningCells { get; private set;}
        public List<Cell> BottomWinningCells { get; private set;}
        public Player Winner {get; private set;}
        public bool CheckTopWinning(Player player) 
        {
            if(CheckWinning(player.CurrentCell, TopWinningCells))
            {
                Winner = player;
                return true;
            }
            return false;
        }
        public bool CheckBottompWinning(Player player) 
        {
            if(CheckWinning(player.CurrentCell, BottomWinningCells))
            {
                Winner = player;
                return true;
            }
            return false;
        }

        private bool CheckWinning(Cell currentCell, List<Cell> winningCells)
        {
            foreach(var cell in winningCells)
            {
                if(currentCell == cell)
                {
                    inPlay = false;
                    return true;
                }
            }
            return false;
        }
        public GameState(List<Cell> topWinningCells, List<Cell> bottomWinningCells)
        {
            TopWinningCells = topWinningCells;
            BottomWinningCells = bottomWinningCells;
            inPlay = true;
        }
    }
}