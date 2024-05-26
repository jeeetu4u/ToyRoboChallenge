using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRoboChallenge
{
    public enum Facing
    {
        NORTH,
        EAST, 
        SOUTH,
        WEST
    }
    public class Robo
    {
        private TableTop _tableTop;
        
        public bool IsPlaced;
        public int X {  get; set; }
        public int Y { get; set; }
        public Facing F {  get; set; }

        public Robo()
        {
            X = -1;
            Y = -1;
            IsPlaced = false;
            _tableTop = new TableTop();
        }

        public void Place(int x, int y, Facing f)
        {
            if(_tableTop.IsPointOnTableTop(x,y))
            {
                X = x;
                Y = y;
                F = f;
                IsPlaced = true;
            }
        }

        public void Move()
        {
            switch (F)
            {
                case Facing.NORTH:
                    if (_tableTop.IsPointOnTableTop(X, Y + 1))
                        Y++;
                    break;
                case Facing.EAST:
                    if (_tableTop.IsPointOnTableTop(X + 1, Y))
                        X++;
                    break;
                case Facing.SOUTH:
                    if (_tableTop.IsPointOnTableTop(X, Y - 1))
                        Y--;
                    break;
                case Facing.WEST:
                    if (_tableTop.IsPointOnTableTop(X - 1, Y))
                        X--;
                    break;
                default:
                    break;
            }
        }

        public void Left()
        {
            F = (Facing)(((int)F + 3) % 4);
            
        }

        public void Right()
        {
            F = (Facing)(((int)F + 1) % 4);

        }

        public string Report()
        {
            return $"{X},{Y},{F}";
        }
    }
}
