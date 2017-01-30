using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ObserverClientUI
{
    class Program
    {
        static private ObserverReference.ServiceWithCBClient proxy;
        
        static public string GetRTUName()
        {
            Console.WriteLine("Enter RTU name:");
            string RTUName = Console.ReadLine();
            return RTUName;
        }

        static public string GetLocName()
        {
            Console.WriteLine("Enter location name:");
            string LocName = Console.ReadLine();
            return LocName;
        }

        static public string GetMeasurementType()
        {
            Console.WriteLine("Enter measurement type (Temp/Hum):");
            string type = Console.ReadLine();
            return type;
        }
                
        static public Tuple<DateTime, DateTime> GetTimeRange()
        {
            Console.WriteLine("Enter lower limit of time range:");
            string lowValue = Console.ReadLine();
            DateTime lowLimit = Convert.ToDateTime(lowValue);

            Console.WriteLine("Enter upper limit of time range:");
            string upValue = Console.ReadLine();
            DateTime upLimit = Convert.ToDateTime(upValue);

            return Tuple.Create(lowLimit, upLimit);
        }

        static public int GetMinMaxValue()
        {
            Console.WriteLine("Enter minMax value:");
            string value = Console.ReadLine();
            int minMax = Convert.ToInt16(value);
            return minMax;
        }
        static public void PrintPackage(ObserverReference.SendingReport s)
        {
            foreach (var item in s.Reports)
            {
                Console.WriteLine(string.Format("RTU name: {0}, measured value: {1}, location: {2}, type: {3}, time: {4}.",
                    item.RTUName,item.value, item.location, item.type, item.time));
            }
        }
        static void Main(string[] args)
        {
            var callback = new Callback();
            var instance = new InstanceContext(callback);
            proxy = new ObserverReference.ServiceWithCBClient(instance);

            string input;

            do
            {
                Console.WriteLine("Select the report:");
                Console.WriteLine("\t1 - Show all measurements of RTU for a time range.");
                Console.WriteLine("\t2 - Show specific type measurement of RTU for a time range.");
                Console.WriteLine("\t3 - Show all moments for higher/lower measurements than specified value");
                Console.WriteLine("\t4 - Show average values on specified location for a time range");
                Console.WriteLine("\t5 - Show all moments for higher/lower measurements than specified value for certain location and given measurement type.");
                Console.WriteLine("\t6 - Exit");

                input = Console.ReadLine();

                if (input == "1")
                {
                    string client = GetRTUName();
                    var limits = GetTimeRange();
                    var report = proxy.GetAllMeasurementsInTimeRange(client, limits.Item1, limits.Item2);
                    PrintPackage(report);
                }
                else if (input == "2")
                {
                    string client = GetRTUName();
                    string type = GetMeasurementType();
                    var limits = GetTimeRange();
                    var report = proxy.GetAllMeasurementsByType(client, type, limits.Item1, limits.Item2);
                    PrintPackage(report);
                }
                else if (input == "3")
                {
                    string client = GetRTUName();
                    int minMax = GetMinMaxValue();
                    string type = GetMeasurementType();
                    var timeList = proxy.GetAllMomentsRTU(client, minMax, type);
                    Console.WriteLine(string.Format("Moments when {0} was more than {1}:", type, minMax));
                    foreach (var item in timeList.Item1)
                    {
                        Console.WriteLine(string.Format("\n{0}", item));
                    }
                    Console.WriteLine(string.Format("Moments when {0} was less than {1}:", type, minMax));
                    foreach (var item in timeList.Item2)
                    {
                        Console.WriteLine(string.Format("\n{0}", item));
                    }
                }
                else if (input == "4")
                {
                    string locName = GetLocName();
                    var limits = GetTimeRange();
                    Tuple<double, double> avgValues = proxy.GetAvgValuesLoc(locName, limits.Item1, limits.Item2);
                    Console.WriteLine(string.Format("Average temperature value: {0}, average humidity value: {1}.", avgValues.Item1, avgValues.Item2));
                }
                else if (input == "5")
                {
                    string locName = GetLocName();
                    int minMax = GetMinMaxValue();
                    string type = GetMeasurementType();
                    var moments = proxy.GetAllMomentsLoc(locName, minMax, type);
                    Console.WriteLine(string.Format("Moments when {0} was more than {1}:", type, minMax));
                    foreach (var item in moments.Item1)
                    {
                        Console.WriteLine(string.Format("\n{0}", item));
                    }
                    Console.WriteLine(string.Format("Moments when {0} was less than {1}:", type, minMax));
                    foreach (var item in moments.Item2)
                    {
                        Console.WriteLine(string.Format("\n{0}", item));
                    }
                }
            } while (input != "6");
        }
    }
}
