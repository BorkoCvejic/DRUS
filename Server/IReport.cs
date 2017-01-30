using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Server
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IReport
    {
        [OperationContract]
        SendingReport GetAllMeasurementsInTimeRange(string RTUName, DateTime start, DateTime end);
        [OperationContract]
        SendingReport GetAllMeasurementsByType(string RTUName, string type, DateTime start, DateTime end);
        [OperationContract]
        Tuple<List<DateTime>, List<DateTime>> GetAllMomentsRTU(string RTUName, int minmax, string type);
        [OperationContract]
        Tuple<double, double> GetAvgValuesLoc(string location, DateTime start, DateTime end);
        [OperationContract]
        Tuple<List<DateTime>, List<DateTime>> GetAllMomentsLoc(string location, int minmax, string type);
    }
}
