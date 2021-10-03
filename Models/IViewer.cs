namespace Model
{
    public interface IViewer
    {
        void RenderBoard(Board board);
        void RenderPlayer(Player player);
        void RenderRemainingWalls(int count);
    }
}