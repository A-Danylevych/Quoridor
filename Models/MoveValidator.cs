namespace Model
{
    class MoveValidator
    {
        private bool IsValid{get; private set;}

        public bool MoveIsValid(Action action, Direction direction, Player player)
        {
            if(action == 1)
            {
                switch(direction)
                {
                    case Direction.Up:
                        if(player.CurrentCell.UpCell is Wall)
                        {
                            IsValid = false;
                            return false;
                        }
                        else{}

                    case Direction.Down:
                        if(player.CurrentCell.DownCell is Wall)
                        {
                            IsValid = false;
                            return false;
                        }

                    case Direction.Left:
                        if(player.CurrentCell.LeftCell is Wall)
                        {
                            IsValid = false;
                            return false;
                        }

                    case Direction.Right:
                        if(player.CurrentCell.RightCell is Wall)
                        {
                            IsValid = false;
                            return false;
                        }
                }
            }
        }
    }
}