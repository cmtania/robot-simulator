
using System.IO;

namespace RobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new RobotModel();
            var robotService = new RobotService(robot);

            string fileName = "commands.txt";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);


            using (var file = new StreamReader(filePath))
            {
                string command;
                while ((command = file.ReadLine()) != null)
                {
                    Console.WriteLine(command);
                    robotService.ExecuteCommand(command);
                }
            }

            //while (true)
            //{
            //    Console.Write("Enter command: ");
            //    string input = Console.ReadLine().Trim().ToUpper();


            //    if (input == "EXIT")
            //    {
            //        break;
            //    }

            //    robotService.ExecuteCommand(input);
            //}
        }

    }
}