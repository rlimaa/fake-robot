using FakeRobot.Models;

namespace FakeRobot.Contracts;

public class RobotCommandSet
{
    public Coordinate Start { get; set; }
    public IEnumerable<RobotCommand> Commands { get; set; }
}