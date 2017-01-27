using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTUClientLiman
{
    class Callback : RTUClientReference.IServiceWithCBCallback
    {
        public void OnMeasurementRecorded()
        {
            Console.WriteLine("Measurement sent!");
        }
    }
}
