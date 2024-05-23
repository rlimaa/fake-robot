using FakeRobot.Contracts;

namespace FakeRobot.Application.Interface;

public interface IRobotCommandService
{
    CommandsSummary ProcessCommand(RobotCommandSet robotCommandSet);
}