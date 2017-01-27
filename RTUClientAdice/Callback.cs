using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTUClientAdice
{
    class Callback : RTUReference.IServiceWithCBCallback
    {
        public void OnMeasurementRecorded()
        {
            Console.WriteLine("Measurement sent!");
        }
    }
}
