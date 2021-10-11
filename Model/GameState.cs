using System.Collections.Generic;
using System.Linq;

namespace Model
{
    class GameState
    {
        public bool InPlay {get; private set;}
        public List<Cell> TopWinningCells { get; private set;}
        public List<Cell> BottomWinningCells { get; private set;}

        public bool CheckTopWinning(Player player)
        {
            return CheckWinning(player.CurrentCell, TopWinningCells);
        }
        public bool CheckBottomWinning(Player player)
        {
            return CheckWinning(player.CurrentCell, BottomWinningCells);
        }

        private bool CheckWinning(Cell currentCell, List<Cell> winningCells)
        {
            if (winningCells.Any(cell => currentCell == cell))
            {
                InPlay = false;
                return true;
            }

            return false;
        }
        public GameState(List<Cell> topWinningCells, List<Cell> bottomWinningCells)
        {
            TopWinningCells = topWinningCells;
            BottomWinningCells = bottomWinningCells;
            InPlay = true;
        }
    }
}