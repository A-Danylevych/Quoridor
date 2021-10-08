using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Quoridor.Controller
{
    public class Controller : IController
    {
        Model.Action Action { get; set; }
        Cell Cell { get; set; }
        Wall Wall { get; set; }

        public void SetAction(Model.Action action)
        {
            Action = action;
        }
        public Model.Action GetAction()
        {
            return Action;
        }
        public void SetCell(int top, int left)
        {
            var coords = new CellCoords(top, left);
            Cell = new Cell(coords);
        }

        public Cell GetCell()
        {
            return Cell;
        }
        public void SetWall(int top, int left, bool vertical)
        {
            var coords = new CellCoords(top, left);
            Wall = new Wall(coords);
        }
        public Wall GetWall()
        {
            return Wall;
        }
        public Controller()
        {

        }
    }
}

