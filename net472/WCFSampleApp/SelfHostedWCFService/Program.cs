﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace SelfHostedWCFService
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/hello");

            using (ServiceHost host = new ServiceHost(typeof(HelloWorldService), baseAddress))
            {
                host.AddServiceEndpoint(typeof(IHelloWorldService), new BasicHttpBinding(BasicHttpSecurityMode.Transport), "/basicHttp");

                ServiceEndpoint se = new ServiceEndpoint(new ContractDescription("HelloWorld"), new NetHttpBinding(BasicHttpSecurityMode.Transport), new EndpointAddress( new Uri ("/netHttp")));

                host.AddServiceEndpoint(se);

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }
        }
    }
}
