using FakeRobot.Contracts;
using FakeRobot.Infrastructure.Entities;
using FakeRobot.Infrastructure.Repositories.Interface;

namespace FakeRobot.Infrastructure.Repositories;

public class RobotCommandRepository : IRobotCommandRepository
{
    private FakeRobotContext _ctx;

    public RobotCommandRepository(FakeRobotContext ctx)
    {
        _ctx = ctx;
    }

    public CommandsSummary SaveRobotCommandResult(int commands, int result, double duration)
    {
        try
        {
            var robotCommandRecord = new RobotCommandRecord
            {
                Commands = commands,
                Result = result,
                Duration = duration
            };

            _ctx.RobotCommandRecords.Add(robotCommandRecord);
            _ctx.SaveChanges();
            
            return new CommandsSummary(
                Id: robotCommandRecord.Id, 
                Timestamp: robotCommandRecord.Timestamp, 
                Commands: robotCommandRecord.Commands, 
                Result: robotCommandRecord.Result,
                Duration: robotCommandRecord.Duration);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}