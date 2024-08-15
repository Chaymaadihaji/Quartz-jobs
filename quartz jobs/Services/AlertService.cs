using quartz_jobs.Jobs;
using quartz_jobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz_jobs.Services
{
    public class AlertService
    {
        public void CheckTemperatureAndAlert(TemperatureReading reading)
        {
            if (reading.Temperature > 4.0)
            {
                Console.WriteLine($"ALERTE! Température trop élevée dans la chambre froide {reading.FridgeId}");
                Console.WriteLine($"Température: {reading.Temperature}°C à {reading.Timestamp}");
                Console.WriteLine("Contacter le technicien de maintenance immédiatement!");
            }
            else
            {
                Console.WriteLine($"Température normale dans la chambre froide {reading.FridgeId}: {reading.Temperature}°C");
            }
        }
    }
}
