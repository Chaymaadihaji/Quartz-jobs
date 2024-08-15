using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

using quartz_jobs.Services;
using Moq;
using quartz_jobs.Models;

namespace quartz_jobs;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Démarrage du système de surveillance de la chambre froide...");

        var mockSensor = new Mock<ITemperatureSensor>();
        mockSensor.Setup(s => s.GetTemperature(It.IsAny<string>()))
            .Returns(() => new TemperatureReading
            {
                Timestamp = DateTime.Now,
                Temperature = Math.Round(new Random().NextDouble() * (5.0 - (-2.0)) + (-2.0), 1),
                FridgeId = "Chambre-Froide-01"
            });

        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<ITemperatureSensor>(mockSensor.Object);
                services.AddSingleton<TemperatureSensorService>();
                services.AddSingleton<AlertService>();
                services.AddQuartz(QuartzConfig.ConfigureQuartz);
                services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
            });

        var host = builder.Build();
        await host.RunAsync();
    }
}
