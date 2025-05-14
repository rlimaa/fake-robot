using FakeRobot.Contracts;

namespace FakeRobot.Application.Interface;

public interface IRobotCommandService
{
    Task<CommandsSummary> ProcessCommand(RobotCommandSet robotCommandSet);
}