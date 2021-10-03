namespace Model
{
    class Player
    {
        private Player(Color color)
        {
            Color = color;
            WallsCount = 10;
        }
        private Cell CurrentCell{ get; private set;}
    
        private Color Color{get; private set;}
        public uint WallsCount{ get; private set;}

        public void ChooseAction()
        {

        }
        public void PlaceWall()
        {

        }
        public void MoveLeft()
        {

        }
        public void MoveRight()
        {

        }
        public void MoveRight()
        {

        }
        public void MoveRight()
        {

        }
    }
}