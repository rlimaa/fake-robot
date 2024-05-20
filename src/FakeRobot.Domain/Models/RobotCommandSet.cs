namespace FakeRobot.Models;

public class RobotCommandSet
{
    public Coordinate Start { get; set; }
    public IEnumerable<RobotCommand> Commands { get; set; }
}