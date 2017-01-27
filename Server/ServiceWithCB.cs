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
                callback.OnMeasurementRecorded();
            }
            catch (Exception e)
            {

                Console.WriteLine("Error : {0}", e.Message);
                Console.ReadKey();
            }
            
        }

        public string Start()
        {           
            callback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
            return "Service started...";
        }        
    }
}
