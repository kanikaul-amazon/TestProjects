using System;
using System.ServiceModel;

namespace DotnetCoreWCFClient
{
    class Program
    {
        private readonly static string _basicHttpEndPointAddress = @"http://localhost:8000/basichttp";
        private readonly static string _netTCPEndPoint = @"net.tcp://localhost:8808/netTcp";
        static void Main(string[] args)
        {
            var factory = new ChannelFactory<IEchoService>(new BasicHttpBinding(), new EndpointAddress(_basicHttpEndPointAddress));
            factory.Open();
            var channel = factory.CreateChannel();
            ((IClientChannel)channel).Open();
            Console.WriteLine("http GetData(5) => " + channel.GetData(5));
            ((IClientChannel)channel).Close();
            factory.Close();

            factory = new ChannelFactory<IEchoService>(new NetTcpBinding(), new EndpointAddress(_netTCPEndPoint));
            factory.Open();
            channel = factory.CreateChannel();
            ((IClientChannel)channel).Open();
            Console.WriteLine("nettcp GetData(5) => " + channel.GetData(5));
            ((IClientChannel)channel).Close();
            factory.Close();

            Console.WriteLine("Hit enter to exit");
            Console.ReadLine();
        }
    }
}
