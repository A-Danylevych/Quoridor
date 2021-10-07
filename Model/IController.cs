namespace Model
{
    public interface IController
    {
        Action GetAction();
        Cell GetCell();
        Wall GetWall();
    }
}