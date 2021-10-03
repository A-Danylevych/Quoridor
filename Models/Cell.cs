namespace Model
{
    class Cell : IPlaceable
    {
        IPlaceable LeftCell { get; set; }
        IPlaceable RightCell { get; set; }
        IPlaceable UpCell { get; set; }
        IPlaceable DownCell { get; set; }
        public void UpperConnect(IPlaceable placeable) => Connect(placeable, Direction.Up);
        public void BottomConnect(IPlaceable placeable) => Connect(placeable, Direction.Down);
        public void RightConnect(IPlaceable placeable) => Connect(placeable, Direction.Right);
        public void LeftConnect(IPlaceable placeable) => Connect(placeable, Direction.Left);
        private void Connect(IPlaceable placeable, Direction direction)
        {
            switch(direction){
                case Direction.Up:
                    UpCell = placeable;
                    break;
                case Direction.Down:
                    DownCell = placeable;
                    break;
                case Direction.Left:
                    LeftCell = placeable;
                    break;
                case Direction.Right:
                    RightCell = placeable;
                    break;
                default:
                    throw new System.ArgumentException("Unexpected direction");
            }
        }
        public Cell()
        {
            LeftCell = new Wall();
            RightCell = new Wall();
            UpCell = new Wall();
            DownCell = new Wall();
        }
    }
}