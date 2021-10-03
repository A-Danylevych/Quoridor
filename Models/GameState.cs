using System.Collections.Generic;

namespace Model
{
    class GameState
    {
        public bool inPlay {get; private set;}
        List<Cell> TopWinningCells;
        List<Cell> BottomWinningCells;
        public bool CheckTopWinning(Player player) => CheckWinning(player.CurrentCell, TopWinningCells);
        public bool CheckBottompWinning(Player player) => CheckWinning(player.CurrentCell, BottomWinningCells);

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