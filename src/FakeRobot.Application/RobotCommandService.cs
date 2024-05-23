using FakeRobot.Application.Interface;
using FakeRobot.Contracts;
using FakeRobot.Infrastructure.Repositories.Interface;

namespace FakeRobot.Application;

public class RobotCommandService : IRobotCommandService
{
    private IRobotCommandRepository _robotCommandRepository;

    public RobotCommandService(IRobotCommandRepository robotCommandRepository)
    {
        _robotCommandRepository = robotCommandRepository;
    }

    public CommandsSummary ProcessCommand(RobotCommandSet robotCommandSet)
    {
        var robot = new CleaningRobot(robotCommandSet.Start);
        var res = robot.ProcessCommands(robotCommandSet.Commands);
        return _robotCommandRepository.SaveRobotCommandResult(robotCommandSet.Commands.Count(), res.NumberCleanedPlaces, res.ElapsedMilliSeconds);
    }
}