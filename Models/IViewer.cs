using System.Collections.Generic;

namespace Model
{
    public interface IViewer
    {
        void RenderEnding();
        void RenderBoard(Board board);
        void RenderPlayer(Player player);
        void RenderRemainingWalls(int count);
        void RenderPossibleCellsToMove(List<Cell> Cells);
    }
}