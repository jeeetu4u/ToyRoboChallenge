using ToyRoboChallenge;

internal class Program
{
    private static void Main(string[] args)
    {
        var robo = new Robo();
        var controller = new RoboController(robo);

        string[] commands;
        if (args.Length > 0)
        {
            commands = File.ReadAllLines(args[0]);
            controller.ParseAndExecuteCommand(commands);
        }
        else
        {
            //bool stop = false;
            //while (!stop)
            //{
            //    Console.WriteLine("Enter the command(PLACE, MOVE, LEFT, RIGHT, REPORT) or STOP to Exit:");
            //    var command = Console.ReadLine();
            //    if (command != null)
            //        if (command.ToLower().Equals("stop"))
            //            stop = true;
            //        else
            //            controller.ParseAndExecuteCommand(new[] { command });
            //}
            commands = new string[]
            {
                "PLACE 0,0,NORTH",
                "MOVE",
                "LEFT",
                "MOVE",
                "REPORT"
            };
            controller.ParseAndExecuteCommand(commands);
        }
    }
}