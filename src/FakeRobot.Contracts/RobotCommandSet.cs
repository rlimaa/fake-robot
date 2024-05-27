using FakeRobot.Models;

namespace FakeRobot.Contracts;

public class RobotCommandSet(Coordinate start, IEnumerable<RobotCommand> commands)
{
    public Coordinate Start { get; set; } = start;
    public IEnumerable<RobotCommand> Commands { get; set; } = commands;
}