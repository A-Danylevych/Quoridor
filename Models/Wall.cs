namespace Model
{
    class Wall : IPlaceable
    {
        IPlaceable LeftCell { get; set; }
        IPlaceable RightCell { get; set; }
        IPlaceable UpCell { get; set; }
        IPlaceable DownCell { get; set; }
    }
}