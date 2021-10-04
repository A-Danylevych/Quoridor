using System.Collections.Generic;

namespace Model
{
    public interface IViewer
    {
        void RenderEnding();
        void RenderPlayer(int top, int left);
        void RenderRemainingWalls(int count);
        void ChangePlayer();
    }
}