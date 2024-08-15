using Quartz;
using quartz_jobs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz_jobs.Jobs
{
    public class TemperatureMonitoringJob : IJob
    {
        private readonly TemperatureSensorService _sensorService;
        private readonly AlertService _alertService;

        public TemperatureMonitoringJob(TemperatureSensorService sensorService, AlertService alertService)
        {
            _sensorService = sensorService;
            _alertService = alertService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"Vérification de la température à {DateTime.Now}");
            var reading = _sensorService.GetTemperature("Chambre-Froide-01");
            _alertService.CheckTemperatureAndAlert(reading);
            return Task.CompletedTask;
        }
    }
}
