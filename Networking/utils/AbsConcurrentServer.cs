using System.Net.Sockets;
using System.Threading;

namespace SwimmingNetworking.utils
{
    public abstract class AbsConcurrentServer : AbstractServer
    {
        public AbsConcurrentServer(string host, int port) : base(host, port)
        {
        }

        public override void ProcessRequest(TcpClient client)
        {
            Thread t = CreateWorker(client);
            t.Start();
        }

        protected abstract Thread CreateWorker(TcpClient client);
    }
}