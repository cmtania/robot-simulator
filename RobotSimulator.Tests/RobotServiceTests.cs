using RobotSimulator;
using static RobotSimulator.Constants;

namespace RobotSimulator.Tests
{
    public class RobotServiceTest
    {
        [Theory]
        [InlineData("LEFT", Direction.North, Direction.West)]
        [InlineData("LEFT", Direction.West, Direction.South)]
        [InlineData("LEFT", Direction.South, Direction.East)]
        [InlineData("LEFT", Direction.East, Direction.North)]
        public void LeftCommand_Should(string command, string facing, string expected)
        {
            // Arrange
            var robotObj = new RobotModel();
            var robotService = new RobotService(robotObj);
            robotService.ExecuteCommand($"PLACE 0,0,{facing}");

            // Act
            robotService.ExecuteCommand(command);

            // Assert
            Assert.Equal(robotObj.Facing, expected);

            robotService.ExecuteCommand("EXIT");
        }

        [Theory]
        [InlineData("RIGHT", Direction.North, Direction.East)]
        [InlineData("RIGHT", Direction.East, Direction.South)]
        [InlineData("RIGHT", Direction.South, Direction.West)]
        [InlineData("RIGHT", Direction.West, Direction.North)]
        public void RightCommand_Should(string command, string facing, string expected)
        {
            // Arrange
            var robotObj = new RobotModel();
            var robotService = new RobotService(robotObj);
            robotService.ExecuteCommand($"PLACE 0,0,{facing}");

            // Act
            robotService.ExecuteCommand(command);

            // Assert
            Assert.Equal(robotObj.Facing, expected);

            robotService.ExecuteCommand("EXIT");
        }

        [Theory]
        [InlineData("MOVE", "PLACE 0,0,NORTH", 0, 1)]
        [InlineData("MOVE", "PLACE 0,1,NORTH", 0, 2)]
        [InlineData("MOVE", "PLACE 0,2,NORTH", 0, 3)]
        [InlineData("MOVE", "PLACE 0,3,NORTH", 0, 4)]
        [InlineData("MOVE", "PLACE 0,4,NORTH", 0, 4)]
        public void MoveNorthCommand_Should(string command, string placing, int xAxis, int yAxis)
        {
            // Arrange
            var robotObj = new RobotModel();
            var robotService = new RobotService(robotObj);
            robotService.ExecuteCommand(placing);

            // Act
            robotService.ExecuteCommand(command);

            // Assert
            Assert.Equal(robotObj.PositionX, xAxis);
            Assert.Equal(robotObj.PositionY, yAxis);

            robotService.ExecuteCommand("EXIT");
        }

        [Theory]
        [InlineData("MOVE", "PLACE 0,0,EAST", 1, 0)]
        [InlineData("MOVE", "PLACE 1,0,EAST", 2, 0)]
        [InlineData("MOVE", "PLACE 2,0,EAST", 3, 0)]
        [InlineData("MOVE", "PLACE 3,0,EAST", 4, 0)]
        [InlineData("MOVE", "PLACE 4,0,EAST", 4, 0)]
        public void MoveEastCommand_Should(string command, string placing, int xAxis, int yAxis)
        {
            // Arrange
            var robotObj = new RobotModel();
            var robotService = new RobotService(robotObj);
            robotService.ExecuteCommand(placing);

            // Act
            robotService.ExecuteCommand(command);

            // Assert
            Assert.Equal(robotObj.PositionX, xAxis);
            Assert.Equal(robotObj.PositionY, yAxis);

            robotService.ExecuteCommand("EXIT");
        }

        [Theory]
        [InlineData("MOVE", "PLACE 0,4,SOUTH", 0, 3)]
        [InlineData("MOVE", "PLACE 0,3,SOUTH", 0, 2)]
        [InlineData("MOVE", "PLACE 0,2,SOUTH", 0, 1)]
        [InlineData("MOVE", "PLACE 0,1,SOUTH", 0, 0)]
        [InlineData("MOVE", "PLACE 0,0,SOUTH", 0, 0)]
        public void MoveSouthCommand_Should(string command, string placing, int xAxis, int yAxis)
        {
            // Arrange
            var robotObj = new RobotModel();
            var robotService = new RobotService(robotObj);
            robotService.ExecuteCommand(placing);

            // Act
            robotService.ExecuteCommand(command);

            // Assert
            Assert.Equal(robotObj.PositionX, xAxis);
            Assert.Equal(robotObj.PositionY, yAxis);

            robotService.ExecuteCommand("EXIT");
        }

        [Theory]
        [InlineData("MOVE", "PLACE 4,4,WEST", 3, 4)]
        [InlineData("MOVE", "PLACE 3,4,WEST", 2, 4)]
        [InlineData("MOVE", "PLACE 2,4,WEST", 1, 4)]
        [InlineData("MOVE", "PLACE 1,4,WEST", 0, 4)]
        [InlineData("MOVE", "PLACE 0,4,WEST", 0, 4)]
        public void MoveWestCommand_Should(string command, string placing, int xAxis, int yAxis)
        {
            // Arrange
            var robotObj = new RobotModel();
            var robotService = new RobotService(robotObj);
            robotService.ExecuteCommand(placing);

            // Act
            robotService.ExecuteCommand(command);

            // Assert
            Assert.Equal(robotObj.PositionX, xAxis);
            Assert.Equal(robotObj.PositionY, yAxis);

            robotService.ExecuteCommand("EXIT");
        }
    }
}