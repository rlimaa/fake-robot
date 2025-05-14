using System.Text.Json.Serialization;
using FakeRobot.Application;
using FakeRobot.Infrastructure;

namespace FakeRobot.Api;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.AddSqlServerDbContext<FakeRobotContext>("sqldb");
        builder.AddAzureServiceBusClient("deliveries");
        
        builder.Services.RegisterApplication();
        builder.Services.RegisterInfrastructure();
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            var converter = new JsonStringEnumConverter();
            options.JsonSerializerOptions.Converters.Add(converter);
        });
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        
        app.UseRouting();
        app.UseForwardedHeaders();
        await app.ConfigureDatabaseAsync();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fake Robot");
            c.RoutePrefix = string.Empty;  
        });

        app.MapControllers();
        await app.RunAsync();
    }
}