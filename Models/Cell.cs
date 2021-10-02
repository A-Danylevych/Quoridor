namespace Model
{
    class Cell : IPlaceable
    {
        Cell LeftCell { get; set; }
        Cell RightCell { get; set; }
        Cell UpCell { get; set; }
        Cell DownCell { get; set; }
    }
}