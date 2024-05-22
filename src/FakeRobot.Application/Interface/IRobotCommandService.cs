using FakeRobot.Contracts;

namespace FakeRobot.Application.Interface;

public interface IRobotCommandService
{
    Task<bool> ProcessCommand(RobotCommandSet robotCommandSet);
}