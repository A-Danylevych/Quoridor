namespace Model
{
    public class Cell : IPlaceable
    {
        public CellCoords Coords { get; private set;}
        public IPlaceable LeftCell { get; private set; }
        public IPlaceable RightCell { get; private set; }
        public IPlaceable UpCell { get; private set; }
        public IPlaceable DownCell { get; private set; }
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
        public Cell(CellCoords coords)
        {
            Coords = coords;
            LeftCell = new Wall(coords);
            RightCell = new Wall(coords);
            UpCell = new Wall(coords);
            DownCell = new Wall(coords);
        }
    }
}