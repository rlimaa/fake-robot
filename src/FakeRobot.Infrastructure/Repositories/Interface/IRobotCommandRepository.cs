using FakeRobot.Contracts;

namespace FakeRobot.Infrastructure.Repositories.Interface;

public interface IRobotCommandRepository
{
    CommandsSummary SaveRobotCommandResult(int commands, int result, long duration);
}