using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverClient
{
    class Callback : ObserverReference.IServiceWithCBCallback
    {
        public void OnMeasurementRecorded(ObserverReference.SendingMeasurement m)
        {
            Console.WriteLine("RTU: " + m.RTUName + ", value: " + m.value.ToString() + ", type: " + m.type
                              + ", location: " + m.location
                              + ", time: " + m.time.ToString());
        }
    }
}
