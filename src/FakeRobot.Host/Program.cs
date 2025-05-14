using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var sqlPassword = builder.AddParameter("sql-password", secret: true);

var sql = builder.AddSqlServer("sql", password: sqlPassword)
    .WithDataVolume();
var sqlDb = sql.AddDatabase("sqldb");


var serviceBus = builder.AddAzureServiceBus("sbemulator")
    .RunAsEmulator()
    .AddServiceBusQueue("deliveries");

builder.AddProject<FakeRobot_Api>("FakeRobotApi")
    .WithReference(sqlDb)
    .WaitFor(sqlDb)
    .WithReference(serviceBus)
    .WaitFor(serviceBus);

builder.AddProject<FakeRobot_Subscriber>("FakeRobotSubscriber")
    .WithReference(serviceBus)
    .WaitFor(serviceBus);



builder.Build().Run();