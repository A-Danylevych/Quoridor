namespace Model
{
    static class MoveValidator
    {
        static public List<Cell> PossibleToMoveCells(Player currentPlayer, Player otherPlayer)
        {
            List<Cell> PossibleToMove = new List<Cell>();
            PossibleToMove = MoveIsValid(currentPlayer, PossibleToMove);       
            PossibleToMove = CheckForOtherPlayer(currentPlayer, otherPlayer, PossibleToMove);
            return PossibleToMove;
        }
        static public bool IsThereAWay(GameState gameState, Player topPlayer, Player bottomPlayer)
        {
            if(FindAWay(gameState.BottomWinningCells, bottomPlayer.CurrentCell) && FindAWay(gameState.TopWinningCells, topPlayer)){
                return true;
            }
            return false;
        }

        static private bool FindAWay(List<Cell> cells, Cell cell){

        }
        static private List<Cell> MoveIsValid(Player player, List<Cell> PossibleToMove)
        {
            if(!player.CurrentCell.UpCell is Wall)
            {
                PossibleToMove.Add(player.CurrentCell.UpCell);
            }
            if(!player.CurrentCell.DownCell is Wall)
            {
                PossibleToMove.Add(player.CurrentCell.DownCell);
            }
            if(!player.CurrentCell.LeftCell is Wall)
            {
                PossibleToMove.Add(player.CurrentCell.LeftCell);
            }
            if(!player.CurrentCell.RightCell is Wall)
            {
                PossibleToMove.Add(player.CurrentCell.RightCell);
            }
            return PossibleToMove;
        }

        static private List<Cell> CheckForOtherPlayer(Player currentPlayer, Player otherPlayer, List<Cell> PossibleToMove)
        {   
            if(currentPlayer.CurrentCell.DownCell == otherPlayer.CurrentCell)
            {   
                PossibleToMove.Remove(otherPlayer.CurrentCell);
                PossibleToMove.Add(otherPlayer.CurrentCell.DownCell);
            }
            else if(currentPlayer.CurrentCell.UpCell == otherPlayer.CurrentCell)
            {
                PossibleToMove.Remove(otherPlayer.CurrentCell);
                PossibleToMove.Add(otherPlayer.CurrentCell.UpCell);
            }
            return PossibleToMove;
        }
    }
}