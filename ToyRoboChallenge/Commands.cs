using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRoboChallenge
{
    public interface ICommand
    {
        bool CanExecute(Robo robo);
        void Execute(Robo robo);
    }

    public class PlaceCommand : ICommand
    {
        private int _x;
        private int _y;
        private Facing _f;

        public PlaceCommand(int x, int y, Facing f)
        {
            _x = x;
            _y = y;
            _f = f;
        }

        public bool CanExecute(Robo robo)
        {
            return true;
        }

        public void Execute(Robo robo)
        {
            robo.Place(_x, _y, _f);
        }
    }

    public class MoveCommand : ICommand
    {
        public bool CanExecute(Robo robo)
        {
            return robo.IsPlaced;
        }

        public void Execute(Robo robo)
        {
            robo.Move();
        }
    }

    public class LeftCommand : ICommand
    {
        public bool CanExecute(Robo robo)
        {
            return robo.IsPlaced;
        }

        public void Execute(Robo robo)
        {
            if (robo.IsPlaced)
            {
                robo.Left();
            }
        }
    }

    public class RightCommand : ICommand
    {
        public bool CanExecute(Robo robo)
        {
            return robo.IsPlaced;
        }
        public void Execute(Robo robo)
        {
            if (robo.IsPlaced)
            {
                robo.Right();
            }
        }
    }

    public class ReportCommand : ICommand
    {
        public bool CanExecute(Robo robo)
        {
            return robo.IsPlaced;
        }
        public void Execute(Robo robo)
        {
            if (robo.IsPlaced)
            {
                string report = robo.Report();
                Console.WriteLine(report);
            }
        }
    }
}
