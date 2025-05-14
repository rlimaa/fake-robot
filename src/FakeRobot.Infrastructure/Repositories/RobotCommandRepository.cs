using System.Text.Json;
using Azure.Messaging.ServiceBus;
using FakeRobot.Contracts;
using FakeRobot.Infrastructure.Entities;
using FakeRobot.Infrastructure.Repositories.Interface;

namespace FakeRobot.Infrastructure.Repositories;

public class RobotCommandRepository : IRobotCommandRepository
{
    private readonly FakeRobotContext _ctx;
    private readonly ServiceBusClient _serviceBus;

    public RobotCommandRepository(FakeRobotContext ctx, ServiceBusClient serviceBus)
    {
        _ctx = ctx;
        _serviceBus = serviceBus;
    }

    public async Task<CommandsSummary> SaveRobotCommandResult(int commands, int result, long duration)
    {
        try
        {
            var robotCommandRecord = new Executions
            {
                Commands = commands,
                Result = result,
                Duration = duration
            };

            _ctx.RobotCommandRecords.Add(robotCommandRecord);
            await _ctx.SaveChangesAsync();
            
            var res = new CommandsSummary(
                Id: robotCommandRecord.Id, 
                Timestamp: robotCommandRecord.Timestamp, 
                Commands: robotCommandRecord.Commands, 
                Result: robotCommandRecord.Result,
                Duration: robotCommandRecord.Duration);

            await SendToBus($"New Robot Excution: {JsonSerializer.Serialize(robotCommandRecord)}");
            
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task SendToBus(string msgBody)
    {
        var sender = _serviceBus.CreateSender("deliveries");
        
        var msg = new ServiceBusMessage(msgBody);
        await sender.SendMessageAsync(msg);
    }
}