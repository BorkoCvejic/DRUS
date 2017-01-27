using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.ServiceModel;

namespace RTUClientAdice
{
    class Program
    {
        static private RTUReference.ServiceWithCBClient proxy; //ovo je klijent servera

        private static void OnTimerElapsedTemp(Object sender, ElapsedEventArgs e)
        {
            proxy.RecordMeasurement("Adice01", RandomValueTemp(), "Temp", DateTime.Now);
        }

        private static void OnTimerElapsedHum(Object sender, ElapsedEventArgs e)
        {
            proxy.RecordMeasurement("Adice01", RandomValueHum(), "Hum", DateTime.Now);
        }

        private static int RandomValueTemp()
        {
            Random r = new Random();
            return r.Next(1, 50);
        }

        private static int RandomValueHum()
        {
            Random r = new Random();
            return r.Next(1, 100);
        }

        static void Main(string[] args)
        {
            var callback = new Callback();
            var instance = new InstanceContext(callback);
            proxy = new RTUReference.ServiceWithCBClient(instance);

            proxy.Start();

            var t1 = new System.Timers.Timer(1000);
            t1.Elapsed += OnTimerElapsedTemp;
            t1.Enabled = true;

            var t2 = new System.Timers.Timer(6000);
            t2.Elapsed += OnTimerElapsedHum;
            t2.Enabled = true;

            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
        }
    }
}
