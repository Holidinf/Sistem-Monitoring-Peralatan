using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission3.Model
{
    public class SensorData
    {
        public DateTime LogDate { get; set; }

        public double Temperature { get; set; }

        public double Humidity { get; set; }

        public int DeviceId { get; set; }
    }
}
