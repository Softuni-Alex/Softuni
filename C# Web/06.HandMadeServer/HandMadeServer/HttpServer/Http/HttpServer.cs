using HttpServer.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace HttpServer.Http
{
    public class HttpServer
    {
        public HttpServer(int port, IEnumerable<Route> routes)
        {
            this.Port = port;
            this.IsActive = true;
            this.HttpProcessor = new HttpProcessor(routes);
        }

        public TcpListener Listener { get; private set; }

        public int Port { get; private set; }

        public bool IsActive { get; private set; }

        public HttpProcessor HttpProcessor { get; private set; }

        public void Listen()
        {
            this.Listener = new TcpListener(IPAddress.Any, this.Port);
            this.Listener.Start();

            while (this.IsActive)
            {
                TcpClient client = this.Listener.AcceptTcpClient();

                Thread thread = new Thread(() =>
                {
                    this.HttpProcessor.HandleClient(client);
                });
                thread.Start();
                Thread.Sleep(1);
            }
        }
    }
}