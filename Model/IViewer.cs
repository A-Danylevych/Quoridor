using System.Collections.Generic;

namespace Model
{
    public interface IViewer
    {
        void RenderEnding(string message);
        void RenderPlayer(int top, int left);
        void RenderWall(int top, int left);
        void RenderRemainingWalls(int TopCount, int BottomCount);
        void ChangePlayer();
    }
}