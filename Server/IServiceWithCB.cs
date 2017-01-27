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
        [OperationContract]
        SendingReport GetAllMeasurementsInTimeRange(string RTUName, DateTime start, DateTime end);
        [OperationContract]
        SendingReport GetAllMeasurementsByType(string RTUName, string type, DateTime start, DateTime end);
        [OperationContract]
        Tuple<List<DateTime>, List<DateTime>> GeAlltMomentsRTU(string RTUName, int minmax, string type);
        [OperationContract]
        Tuple<double, double> GetAvgValuesLoc(string location, DateTime start, DateTime end);
        [OperationContract]
        Tuple<List<DateTime>, List<DateTime>> GetAllMomentsLoc(string location, int minmax, string type);
    }    
}
