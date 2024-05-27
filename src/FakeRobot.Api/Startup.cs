using System.Text.Json.Serialization;
using FakeRobot.Application;
using FakeRobot.Application.Interface;
using FakeRobot.Infrastructure;

namespace FakeRobot.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.RegisterApplication();
        services.RegisterInfrastructure(Configuration);
        services.AddControllers().AddJsonOptions(options =>
        {
            var converter = new JsonStringEnumConverter();
            options.JsonSerializerOptions.Converters.Add(converter);
        });
        services.AddSwaggerGen();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseForwardedHeaders();
        app.Migrate();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fake Robot");
            c.RoutePrefix = string.Empty;  
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}