using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{

    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IServiceWithCB
    {
        [OperationContract]
        string Start();
        [OperationContract]
        void RecordMeasurement(string RTUName, int value, string type, DateTime time);        
    }    
}
