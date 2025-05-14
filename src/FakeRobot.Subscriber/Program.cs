using FakeRobot.Subscriber.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.AddAzureServiceBusClient("deliveries");

CancellationTokenSource cTokenSource = new CancellationTokenSource();
CancellationToken token = cTokenSource.Token;

builder.Services.AddKeyedSingleton("AppShutdown", cTokenSource);

builder.Services.AddHostedService<DeliveriesBusService>();

using IHost host = builder.Build();
await host.RunAsync(token).ConfigureAwait(false);