using FakeRobot.Models;

namespace FakeRobot.Application.Interface;

public interface IRobotCommandService
{
    Task<bool> ProcessCommand(RobotCommandSet robotCommandSet);
}