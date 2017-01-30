using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.Single)]
    public class ReportService : IReport
    {
        public SendingReport GetAllMeasurementsInTimeRange(string RTUName, DateTime start, DateTime end)
        {
            SendingReport report = new SendingReport();
            report.Reports = new List<SendingMeasurement>();

            var timeRangeMeasurements = (from m in ServiceWithCB.databaseModel.Measurements
                                         where m.Time > start
                                         where m.Time < end
                                         where m.RTU.RTUId == RTUName
                                         select m);

            foreach (var item in timeRangeMeasurements)
            {
                SendingMeasurement m = new SendingMeasurement();

                m.RTUName = RTUName;
                m.value = item.Value;
                var locationId = (from r in ServiceWithCB.databaseModel.RTUs
                                  where r.RTUId == RTUName
                                  select r.Location).FirstOrDefault();
                var location = (from l in ServiceWithCB.databaseModel.Locations
                                where l.Id == locationId
                                select l.LocationName).FirstOrDefault();
                m.location = location;
                m.type = item.Type;
                m.time = item.Time;

                report.Reports.Add(m);
            }

            return report;
        }

        public SendingReport GetAllMeasurementsByType(string RTUName, string type, DateTime start, DateTime end)
        {
            SendingReport report = new SendingReport();
            report.Reports = new List<SendingMeasurement>();

            var typeMeasurements = (from m in ServiceWithCB.databaseModel.Measurements
                                    where m.Time > start
                                    where m.Time < end
                                    where m.Type == type
                                    where m.RTU.RTUId == RTUName
                                    select m);

            foreach (var item in typeMeasurements)
            {
                SendingMeasurement m = new SendingMeasurement();

                m.RTUName = RTUName;
                m.value = item.Value;
                var locationId = (from r in ServiceWithCB.databaseModel.RTUs
                                  where r.RTUId == RTUName
                                  select r.Location).FirstOrDefault();
                var location = (from l in ServiceWithCB.databaseModel.Locations
                                where l.Id == locationId
                                select l.LocationName).FirstOrDefault();
                m.location = location;
                m.type = item.Type;
                m.time = item.Time;

                report.Reports.Add(m);
            }
            return report;
        }

        public Tuple<List<DateTime>, List<DateTime>> GetAllMomentsRTU(string RTUName, int minmax, string type)
        {
            List<DateTime> maxList = new List<DateTime>();
            List<DateTime> minList = new List<DateTime>();

            var rtuId = (from r in ServiceWithCB.databaseModel.RTUs
                         where r.RTUId == RTUName
                         select r.Id).First();

            var maxMeasurement = (from m in ServiceWithCB.databaseModel.Measurements
                                  where m.RTUId == rtuId
                                  where m.Value > minmax
                                  where m.Type == type
                                  select m.Time);
            var minMeasurement = (from m in ServiceWithCB.databaseModel.Measurements
                                  where m.RTUId == rtuId
                                  where m.Value < minmax
                                  where m.Type == type
                                  select m.Time);

            foreach (var item in maxMeasurement)
            {
                maxList.Add(item);
            }
            foreach (var item in minMeasurement)
            {
                minList.Add(item);
            }

            return Tuple.Create(maxList, minList);
        }

        public Tuple<double, double> GetAvgValuesLoc(string location, DateTime start, DateTime end)
        {
            var locId = (from l in ServiceWithCB.databaseModel.Locations
                         where l.LocationName == location
                         select l.Id).FirstOrDefault();
            var RTU_id = (from r in ServiceWithCB.databaseModel.RTUs
                          where r.Location == locId
                          select r.Id).First();
            var temps = (from m in ServiceWithCB.databaseModel.Measurements
                         where m.RTUId == RTU_id
                         where m.Time > start
                         where m.Time < end
                         where m.Type == "Temp"
                         select m.Value);
            var hums = (from m in ServiceWithCB.databaseModel.Measurements
                        where m.RTUId == RTU_id
                        where m.Time > start
                        where m.Time < end
                        where m.Type == "Hum"
                        select m.Value);

            double avgTemp = (double)temps.Average();
            double avgHum = (double)hums.Average();

            Tuple<double, double> avgValues = new Tuple<double, double>(avgTemp, avgHum);

            return avgValues;
        }

        public Tuple<List<DateTime>, List<DateTime>> GetAllMomentsLoc(string location, int minmax, string type)
        {
            List<DateTime> maxMoments = new List<DateTime>();
            List<DateTime> minMoments = new List<DateTime>();

            var locId = (from l in ServiceWithCB.databaseModel.Locations
                         where l.LocationName == location
                         select l.Id).FirstOrDefault();
            var RTU_id = (from r in ServiceWithCB.databaseModel.RTUs
                          where r.Location == locId
                          select r.Id).FirstOrDefault();
            var momentsMax = (from m in ServiceWithCB.databaseModel.Measurements
                              where m.RTUId == RTU_id
                              where m.Type == type
                              where m.Value > minmax
                              select m.Time);
            var momentsMin = (from m in ServiceWithCB.databaseModel.Measurements
                              where m.RTUId == RTU_id
                              where m.Type == type
                              where m.Value < minmax
                              select m.Time);

            foreach (var item in momentsMax)
            {
                maxMoments.Add(item);
            }
            foreach (var item in momentsMin)
            {
                minMoments.Add(item);
            }

            Tuple<List<DateTime>, List<DateTime>> moments = new Tuple<List<DateTime>, List<DateTime>>(maxMoments, minMoments);
            return moments;
        }
    }
}
