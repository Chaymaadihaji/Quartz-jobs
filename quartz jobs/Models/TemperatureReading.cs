using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz_jobs.Models
{
    public class TemperatureReading
    {
        public DateTime Timestamp { get; set; }
        public double Temperature { get; set; }
        public string FridgeId { get; set; }
    }
}
