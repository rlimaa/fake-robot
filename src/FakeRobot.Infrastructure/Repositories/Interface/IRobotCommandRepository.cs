using FakeRobot.Contracts;

namespace FakeRobot.Infrastructure.Repositories.Interface;

public interface IRobotCommandRepository
{
    Task<CommandsSummary> SaveRobotCommandResult(int commands, int result, long duration);
}