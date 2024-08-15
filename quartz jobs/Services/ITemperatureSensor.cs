using quartz_jobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz_jobs.Services
{
    public interface ITemperatureSensor
    {
        TemperatureReading GetTemperature(string fridgeId);
    }
}
