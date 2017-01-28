using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverClientUI.ObserverReference;

namespace ObserverClientUI
{
    class Callback : ObserverReference.IServiceWithCBCallback
    {
        public void OnMeasurementRecorded(SendingMeasurement m)
        {
            
        }
    }
}
