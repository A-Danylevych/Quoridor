using System.Collections.Generic;
using System.Linq;

namespace Model
{
    internal static class MoveValidator
    {
        public static bool IsValidMove(Cell cell, Player currentPlayer, Player otherPlayer)
        {
            var possibleMoves = PossibleToMoveCells(currentPlayer, otherPlayer);
            return possibleMoves.Any(possibleCell => possibleCell.Coords.Equals(cell.Coords));
        }
        private static IEnumerable<Cell> PossibleToMoveCells(Player currentPlayer, Player otherPlayer)
        {
            var possibleToMove = new List<Cell>();
            possibleToMove = MoveIsValid(currentPlayer, possibleToMove);       
            possibleToMove = CheckForOtherPlayer(currentPlayer, otherPlayer, possibleToMove);
            return possibleToMove;
        }
        public static bool IsThereAWay(GameState gameState, Player topPlayer, Player bottomPlayer)
        {
            return FindAWay(gameState.BottomWinningCells, bottomPlayer.CurrentCell) && 
                   FindAWay(gameState.TopWinningCells, topPlayer.CurrentCell);
        }
        private static bool FindAWay(ICollection<Cell> cells, Cell cell)
        {
            var stackCells = new Stack<Cell>();
            var visited = new List<Cell>();
            
            stackCells.Push(cell);
            visited.Add(cell);

            while (stackCells.Count != 0)
            {
                var currentCell = stackCells.Pop();
                foreach (var next in currentCell.GetNeighbors().Where(next => !visited.Contains(next)))
                {
                    if(cells.Contains(next))
                    {
                        return true;
                    }
                    stackCells.Push(next);
                    visited.Add(next);
                }
            }
            return false;
        }
        private static List<Cell> MoveIsValid(Player player, List<Cell> possibleToMove)
        {
            if(!(player.CurrentCell.UpCell is Wall))
            {
                possibleToMove.Add((Cell)player.CurrentCell.UpCell);
            }
            if(!(player.CurrentCell.DownCell is Wall))
            {
                possibleToMove.Add((Cell)player.CurrentCell.DownCell);
            }
            if(!(player.CurrentCell.LeftCell is Wall))
            {
                possibleToMove.Add((Cell)player.CurrentCell.LeftCell);
            }
            if(!(player.CurrentCell.RightCell is Wall))
            {
                possibleToMove.Add((Cell)player.CurrentCell.RightCell);
            }
            return possibleToMove;
        }

        private static List<Cell> CheckForOtherPlayer(Player currentPlayer, Player otherPlayer, 
            List<Cell> possibleToMove)
        {   
            if(currentPlayer.CurrentCell.DownCell == otherPlayer.CurrentCell)
            {   
                possibleToMove.Remove(otherPlayer.CurrentCell);
                possibleToMove.Add((Cell)otherPlayer.CurrentCell.DownCell);
            }
            else if(currentPlayer.CurrentCell.UpCell == otherPlayer.CurrentCell)
            {
                possibleToMove.Remove(otherPlayer.CurrentCell);
                possibleToMove.Add((Cell)otherPlayer.CurrentCell.UpCell);
            }
            return possibleToMove;
        }
    }
}