namespace Model
{
    class MoveValidator
    {
        private List<Cell> RenderPossibleToMove = new List<Cell>();
        public List<Cell> MoveIsValid(Direction direction, Player player)
        {
                switch(direction)
                {
                    case Direction.Up:
                        if(!player.CurrentCell.UpCell is Wall)
                        {
                            {RenderPossibleToMove.Add(player.CurrentCell.UpCell);};
                        }

                    case Direction.Down:
                        if(!player.CurrentCell.DownCell is Wall)
                        {
                            {RenderPossibleToMove.Add(player.CurrentCell.DownCell);};
                        }

                    case Direction.Left:
                        if(!player.CurrentCell.LeftCell is Wall)
                        {
                            {RenderPossibleToMove.Add(player.CurrentCell.LeftCell);};
                        }

                    case Direction.Right:
                        if(!player.CurrentCell.RightCell is Wall)
                        {
                            {RenderPossibleToMove.Add(player.CurrentCell.RightCell);};
                        }
                }
        }
        public List<Cell> CheckForOtherPlayer(Player topPlayer, Player bottomPlayer)
        {

        }
    }
}