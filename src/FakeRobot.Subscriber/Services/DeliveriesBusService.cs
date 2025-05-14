using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FakeRobot.Subscriber.Services;

public class DeliveriesBusService : BackgroundService
{
    private readonly ServiceBusClient _client;
    private const string QueueName = "deliveries";
    private readonly ILogger<DeliveriesBusService> _logger;

    public DeliveriesBusService(ServiceBusClient client, ILogger<DeliveriesBusService> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task ReceiveMessageAsync()
    {
        var processor = _client.CreateProcessor(QueueName, new ServiceBusProcessorOptions());
        try
        {
            processor.ProcessMessageAsync += MessageHandler;
            processor.ProcessErrorAsync += ErrorHandler;
            
            await processor.StartProcessingAsync();
            
            Console.WriteLine("Receiving messages. Press any key to stop processing...");
            Console.Read();
            
            await processor.StopProcessingAsync();
        }
        finally
        {
            await processor.DisposeAsync();
        }
    }

    private Task ErrorHandler(ProcessErrorEventArgs arg)
    {
        _logger.LogError(arg.Exception, "Error");
        
        return Task.CompletedTask;
    }

    private Task MessageHandler(ProcessMessageEventArgs arg)
    {
        var body = arg.Message.Body.ToString();
        
        Console.WriteLine($"New message: {body}");
        
        return arg.CompleteMessageAsync(arg.Message);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await ReceiveMessageAsync();
    }
}