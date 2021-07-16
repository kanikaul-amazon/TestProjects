using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostedWCFService
{
    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string SayHello(string name);
    }
    public class HelloWorldService : IHelloWorldService
    {
        public string SayHello(string name)
        {
            return String.Format("Hello, {0}", name);
        }
    }
}
