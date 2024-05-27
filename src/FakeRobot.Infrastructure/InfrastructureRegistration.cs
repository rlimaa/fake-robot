using FakeRobot.Infrastructure.Repositories;
using FakeRobot.Infrastructure.Repositories.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FakeRobot.Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IRobotCommandRepository, RobotCommandRepository>();
        services.AddEntityFrameworkNpgsql()
            .AddDbContext<FakeRobotContext>(options => options.UseNpgsql(configuration.GetConnectionString("Db")));
            // .AddDbContext<FakeRobotContext>(options => options.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING")));
        
        return services;
    }

    public static IApplicationBuilder Migrate(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<FakeRobotContext>();
        db.Database.Migrate();

        return app;
    }
    
}