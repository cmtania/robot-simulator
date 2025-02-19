using static RobotSimulator.Constants;

namespace RobotSimulator
{
    public class RobotModel
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public string Facing { get; set; }
        public bool IsPlaced { get; set; }

        public RobotModel()
        {
            IsPlaced = false;
        }

        public void Place(int x, int y, string facing)
        {
            if (IsValidPosition(x, y) && IsValidDirection(facing))
            {
                PositionX = x;
                PositionY = y;
                Facing = facing;
                IsPlaced = true;
            }
        }

        public void Move()
        {
            int newX = PositionX;
            int newY = PositionY;

            switch (Facing)
            {
                case Direction.North:
                    newY++;
                    break;
                case Direction.South:
                    newY--;
                    break;
                case Direction.East:
                    newX++;
                    break;
                case Direction.West:
                    newX--;
                    break;
            }

            if (IsValidPosition(newX, newY))
            {
                PositionX = newX;
                PositionY = newY;
            }
        }

        public void Left()
        {
            switch (Facing)
            {
                case Direction.North:
                    Facing = Direction.West;
                    break;
                case Direction.West:
                    Facing = Direction.South;
                    break;
                case Direction.South:
                    Facing = Direction.East;
                    break;
                case Direction.East:
                    Facing = Direction.North;
                    break;
            }
        }

        public void Right()
        {
            switch (Facing)
            {
                case Direction.North:
                    Facing = Direction.East;
                    break;
                case Direction.East:
                    Facing = Direction.South;
                    break;
                case Direction.South:
                    Facing = Direction.West;
                    break;
                case Direction.West:
                    Facing = Direction.North;
                    break;
            }
        }

        public string Report()
        {
            return $"{PositionX},{PositionY},{Facing}";
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < 5 && y >= 0 && y < 5;
        }

        private bool IsValidDirection(string direction)
        {
            return direction == Direction.North || direction == Direction.South || direction == Direction.East || direction == Direction.West;
        }
    }
}