using System;
using System.Net.Sockets;
using System.Threading;
using SwimmingNetworking.objectprotocol;
using SwimmingServices;

namespace SwimmingNetworking.utils
{
    public class SerialServer : AbsConcurrentServer
    {

        private IService Service;
        private ClientObjectWorker worker;
        
        public SerialServer(string host, int port, IService service) : base(host, port)
        {
            this.Service = service;
            Console.WriteLine("Serial server...");
        }

        protected override Thread CreateWorker(TcpClient client)
        {
            worker = new ClientObjectWorker(Service, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
}