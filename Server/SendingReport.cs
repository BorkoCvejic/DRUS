using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public struct SendingReport
    {
        public List<SendingMeasurement> Reports;
    }
    public struct SendingMeasurement
    {
        public string RTUName;
        public int value;
        public string location;
        public string type;
        public DateTime time;
    };
}
