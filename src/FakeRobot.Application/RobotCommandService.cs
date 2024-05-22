using System.Text.Json;
using FakeRobot.Application.Interface;
using FakeRobot.Contracts;
using FakeRobot.Infrastructure.Repositories;
using FakeRobot.Infrastructure.Repositories.Interface;

namespace FakeRobot.Application;

public class RobotCommandService : IRobotCommandService
{
    private IRobotCommandRepository _robotCommandRepository;

    public RobotCommandService(IRobotCommandRepository robotCommandRepository)
    {
        _robotCommandRepository = robotCommandRepository;
    }

    public async Task<bool> ProcessCommand(RobotCommandSet robotCommandSet)
    {
        Console.WriteLine(JsonSerializer.Serialize(robotCommandSet));
        await Task.Delay(100);
        _robotCommandRepository.SaveRobotCommandResult(1, 1, 1);
        return true;
    }
}