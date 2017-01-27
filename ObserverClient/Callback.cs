using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverClient
{
    class Callback : ObserverReference.IServiceWithCBCallback
    {
        public void OnMeasurementRecorded(Dictionary<string, int> measurements)
        {
            foreach (var item in measurements)
            {
                Console.WriteLine(string.Format("ID: {0}, {1}", item.Key, item.Value));
            }
        }
    }
}
