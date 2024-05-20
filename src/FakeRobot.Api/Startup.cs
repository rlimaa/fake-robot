using System.Text.Json.Serialization;
using FakeRobot.Application;
using FakeRobot.Application.Interface;

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
        services.AddTransient<IRobotCommandService, RobotCommandService>();
        
        services.AddControllers().AddJsonOptions(options =>
        {
            var converter = new JsonStringEnumConverter();
            options.JsonSerializerOptions.Converters.Add(converter);
        });
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        app.UseRouting();
        app.UseForwardedHeaders();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}