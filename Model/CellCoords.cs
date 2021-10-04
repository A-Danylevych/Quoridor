namespace Model
{
    public class CellCoords
    {
        public int Top {get; private set;}
        public int Left {get; private set;}
        public override bool Equals(object obj)
        {
            var cell = (CellCoords)obj;
            return cell.Top == this.Top && cell.Left == this.Left;
        }
        public CellCoords(int top, int left)
        {
            Top = top;
            Left = left;
        }
    }
     
}