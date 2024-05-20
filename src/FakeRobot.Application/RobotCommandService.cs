using System.Text.Json;
using FakeRobot.Application.Interface;
using FakeRobot.Models;

namespace FakeRobot.Application;

public class RobotCommandService : IRobotCommandService
{
    public async Task<bool> ProcessCommand(RobotCommandSet robotCommandSet)
    {
        Console.WriteLine(JsonSerializer.Serialize(robotCommandSet));
        await Task.Delay(100);
        return true;
    }
}