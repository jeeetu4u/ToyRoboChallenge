using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRoboChallenge
{
    public class RoboController
    {
        private Robo _robo;

        public RoboController(Robo robo) { _robo = robo; }

        public void ParseAndExecuteCommand(string[] commands)
        {
            foreach (var command in commands)
            {
                var parts = command.Split(' ');

                if(!ValidateCommand(parts)) continue;//Basic test done

                switch (parts[0])
                {
                    case "PLACE":
                        ICommand cmd = new PlaceCommand(
                            int.Parse(parts[1].Split(',')[0]),
                            int.Parse(parts[1].Split(',')[1]),
                            Enum.Parse<Facing>(parts[1].Split(',')[2]));
                        ExecuteCommand(cmd);
                        break;
                    case "MOVE":
                        ExecuteCommand(new MoveCommand());
                        break;
                    case "LEFT":
                        ExecuteCommand(new LeftCommand());
                        break;
                    case "RIGHT":
                        ExecuteCommand(new RightCommand());
                        break;
                    case "REPORT":
                        ExecuteCommand(new ReportCommand());
                        break;
                }
            }
        }

        private bool ValidateCommand(string[] parts)
        {
            if (parts[0] == "MOVE" || parts[0]=="LEFT" || parts[0]=="RIGHT" || parts[0]=="REPORT")
            {
                if (parts.Length == 1) return true;
            }
            
            if (parts[0]=="PLACE")
            {
                if (parts.Length == 2)
                {
                        return true;
                }
            }
            return false;
        }

        public void ParseCommand(string command)
        {

        }

        public void ExecuteCommand(ICommand cmd) 
        {
            if(cmd.CanExecute(_robo))
                cmd.Execute(_robo); 
        }
    }
}
