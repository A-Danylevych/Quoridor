namespace Model
{
    class Cell : IPlaceable
    {
        IPlaceable LeftCell { get; set; }
        IPlaceable RightCell { get; set; }
        IPlaceable UpCell { get; set; }
        IPlaceable DownCell { get; set; }
        public void UpConnect(IPlaceable placeable)
        {

        }
        public void Connect(IPlaceable placeable, )
        {
            DownCell = placeable;
        }
    }
}