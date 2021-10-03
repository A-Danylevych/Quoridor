namespace Model
{
    class Player
    {
        private Player(Color color, Cell cell)
        {
            CurrentCell = cell; 
            Color = color;
            WallsCount = 10;
        }
        public Cell CurrentCell{ get; private set;}
    
        private Color Color{get; private set;}
        public uint WallsCount{ get; private set;}

        private void ChangeCell(Cell cell)
        {
            CurrentCell = cell;
        }
    }
}