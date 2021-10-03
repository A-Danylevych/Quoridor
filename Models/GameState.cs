using System.Collections.Generic;

namespace Model
{
    class GameState
    {
        bool inPlay;
        bool TopWon;
        bool BottomWon;
        public bool CheckWinning(Cell currentCell, List<Cell> winningCells)
        {
            foreach(var cell in winningCells)
            {
                if(currentCell == cell)
                {
                    return true;
                }
            }
            return false;
        }
    }
}