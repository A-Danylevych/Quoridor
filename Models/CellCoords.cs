namespace Model
{
    class CellCoords
    {
        public int Top {get; private set;}
        public int Left {get; private set;}
        public CellCoords(int top, int left)
        {
            Top = top;
            Left = left;
        }
    }
     
}