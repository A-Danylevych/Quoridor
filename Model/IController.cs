namespace Model
{
    public interface IController
    {
        Action WaitForAction();
        Cell WaitForCell();
        Wall WaitForWall();
    }
}