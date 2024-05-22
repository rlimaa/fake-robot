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

    public RobotCommandRecord SaveRobotCommandResult(int commands, int result, double duration)
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
            return robotCommandRecord;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}