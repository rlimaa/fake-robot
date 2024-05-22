using FakeRobot.Infrastructure.Entities;

namespace FakeRobot.Infrastructure.Repositories.Interface;

public interface IRobotCommandRepository
{
    RobotCommandRecord SaveRobotCommandResult(int commands, int result, double duration);
}