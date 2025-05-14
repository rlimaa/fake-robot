using FakeRobot.Infrastructure.Repositories;
using FakeRobot.Infrastructure.Repositories.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace FakeRobot.Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IRobotCommandRepository, RobotCommandRepository>();
        // services.AddEntityFrameworkSqlServer()
        //     .AddDbContext<FakeRobotContext>(options => options.UseSqlServer("Server=127.0.0.1,1433;Database=PUDO;UID=sa;PWD=MyPass@word;TrustServerCertificate=true"));
        // .AddDbContext<FakeRobotContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString")));
        
        return services;
    }

    public static async Task<IApplicationBuilder> ConfigureDatabaseAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<FakeRobotContext>();

        await EnsureDatabaseAsync(db);
        // await RunMigrationsAsync(db);

        return app;
    }

    private static async Task EnsureDatabaseAsync(FakeRobotContext context)
    {
        var dbCreator = context.GetService<IRelationalDatabaseCreator>();

        var strategy = context.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await dbCreator.EnsureCreatedAsync();
        });
    }

    private static async Task RunMigrationsAsync(FakeRobotContext context)
    {
        var strategy = context.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            await context.Database.MigrateAsync();
            await transaction.CommitAsync();
        });
    }
    
}