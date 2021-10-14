using System;

namespace Model
{
    class Bot : Player
    {
        List
        public void MakeAMove(IController controller, Player otherPlayer)
        {            
            var rand = new Random();
            Type type = typeof(Action);
            Array values = type.GetEnumValues();

            int index = rand.Next(values.Length);
			Action action = (Action)values.GetValue(index);
            controller.SetAction(action);
            if(action == MakeMove)
            {
                var cells = MoveValidator.PossibleToMoveCells(this, otherPlayer);
                var cell = rand.Next(cells.Count);
                controller.SetCell(cell.Coords.Top, cell.Coords.Left);
            }
            if(action == PlaceWall)
            {       
                var randomBool = random.Next(2) == 1;
                int top = rand.Next(1, 8) * 25;
                int left = rand.Next(1, 8) * 25;
                controller.SetWall(top, left, randomBool)
            }
        }

    }
}