using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FakeRobot.Infrastructure;

public class FakeRobotContextFactory : IDesignTimeDbContextFactory<FakeRobotContext>
{
    public FakeRobotContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FakeRobotContext>();
        
        optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=PUDO;UID=sa;PWD=MyPass@word;TrustServerCertificate=true");

        return new FakeRobotContext(optionsBuilder.Options);
    }
}