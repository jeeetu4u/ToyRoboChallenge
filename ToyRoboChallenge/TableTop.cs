using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRoboChallenge
{
    internal class TableTop
    {
        public int X {  get; set; }
        public int Y { get; set; }

        public TableTop()
        {
            X = 5;
            Y = 5;
        }

        public bool IsPointOnTableTop(int x, int y)
        {
            return x>=0 && y>=0 && x<=X && y<=Y;
        }
    }
}
