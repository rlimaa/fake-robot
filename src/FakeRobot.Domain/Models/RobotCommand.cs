using FakeRobot.Enums;

namespace FakeRobot.Models;

public class RobotCommand(Direction direction, int steps)
{
    public Direction Direction { get; internal set; } = direction;
    public int Steps { get; internal set; } = steps;
}