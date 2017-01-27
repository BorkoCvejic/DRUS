using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Timers;

namespace Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceWithCB : IServiceWithCB
    {
        private IServiceCallback callback;
        static private MeasurementDatabaseEntities1 databaseModel = new MeasurementDatabaseEntities1();               

        public void RecordMeasurement(string RTUName, int value, string type, DateTime time)
        {
            var measurement = new Measurement();
            try
            {
                measurement.Value = value;
                var rtuId = (from r in databaseModel.RTUs
                             where r.RTUId == RTUName
                             select r.Id).FirstOrDefault();
                measurement.RTUId = rtuId;
                measurement.Type = type;
                measurement.Time = time;

                databaseModel.Measurements.Add(measurement);
                databaseModel.SaveChanges();                
            }
            catch (Exception e)
            {

                Console.WriteLine("Error : {0}", e.Message);
                Console.ReadKey();
            }

            var locationId = (from r in databaseModel.RTUs
                              where r.RTUId == RTUName
                              select r.Location).FirstOrDefault();
            var location = (from l in databaseModel.Locations
                            where l.Id == locationId
                            select l.LocationName).FirstOrDefault();

            SendingMeasurement m;
            m.RTUName = RTUName;
            m.location = location;
            m.time = time;
            m.type = type;
            m.value = value;

            callback.OnMeasurementRecorded(m);
        }

        public string Start()
        {           
            callback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
            return "Service started...";
        }

        public SendingReport GetAllMeasurementsInTimeRange(string RTUName, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public SendingReport GetAllMeasurementsByType(string RTUName, string type, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Tuple<List<DateTime>, List<DateTime>> GeAlltMomentsRTU(string RTUName, int minmax, string type)
        {
            throw new NotImplementedException();
        }

        public Tuple<double, double> GetAvgValuesLoc(string location, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Tuple<List<DateTime>, List<DateTime>> GetAllMomentsLoc(string location, int minmax, string type)
        {
            throw new NotImplementedException();
        }
    }
}
