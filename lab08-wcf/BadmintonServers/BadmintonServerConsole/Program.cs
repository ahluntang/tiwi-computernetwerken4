using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BadmintonServiceLibrary;

using System.ServiceModel;
using System.ServiceModel.Description;

namespace BadmintonServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Badminton)))
            {
                host.AddServiceEndpoint(typeof(IBadminton), new WSHttpBinding(), "BadmintonService");
                host.Open();
                Console.WriteLine("The service is ready at {0}", host.BaseAddresses.ElementAt(0));
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
