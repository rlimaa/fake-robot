using FakeRobot.Application.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace FakeRobot.Application;

public static class ApplicationRegistration
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.AddTransient<IRobotCommandService, RobotCommandService>();
    
        return services;
    }

}