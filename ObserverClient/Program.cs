using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ObserverClient
{
    class Program
    {
        static private ObserverReference.ServiceWithCBClient proxy;

        static void Main(string[] args)
        {
            var callback = new Callback();
            var instance = new InstanceContext(callback);
            proxy = new ObserverReference.ServiceWithCBClient(instance);

            proxy.Start();

            Console.WriteLine("press any key to stop...");
            Console.ReadKey();
        }
    }
}
