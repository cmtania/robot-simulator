namespace RobotSimulator
{
    public class RobotService
    {
        private readonly RobotModel _robot;
        private readonly string[] actions = new string[] { "MOVE", "RIGHT", "LEFT", "REPORT" };

        public RobotService(RobotModel robot)
        {
            _robot = robot;
        }

        public void ExecuteCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                Console.WriteLine("Command cannot be empty.");
                return;
            }

            if (command.StartsWith("PLACE"))
            {
                string[] parts = command.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 4 && int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int y))
                {
                    _robot.Place(x, y, parts[3]);
                    return;
                }

                Console.WriteLine("'PLACE' command is not valid.");
                return;
            }

            if (!actions.Contains(command))
            {
                Console.WriteLine("Command is not valid.");
                return;
            }

            if (!_robot.IsPlaced)
            {
                Console.WriteLine("Robot has not been placed.");
                return;
            }

            switch (command)
            {
                case "MOVE":
                    _robot.Move();
                    break;
                case "LEFT":
                    _robot.Left();
                    break;
                case "RIGHT":
                    _robot.Right();
                    break;
                case "REPORT":
                    Console.WriteLine(_robot.Report());
                    break;
                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }
        }
    }
}