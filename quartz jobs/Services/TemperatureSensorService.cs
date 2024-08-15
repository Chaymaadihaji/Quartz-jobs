using quartz_jobs.Jobs;
using quartz_jobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz_jobs.Services
{
    public class TemperatureSensorService
    {
        private readonly ITemperatureSensor _sensor;

        public TemperatureSensorService(ITemperatureSensor sensor)
        {
            _sensor = sensor;
        }

        public TemperatureReading GetTemperature(string fridgeId)
        {
            return _sensor.GetTemperature(fridgeId);
        }
    }
}
        