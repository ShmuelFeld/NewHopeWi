using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace NewHope
{
    /// <summary>
    /// the server flow.
    /// </summary>
    class Server
    {
        /// <summary>
        /// The controller
        /// </summary>
        private IController controller;
        /// <summary>
        /// The listener
        /// </summary>
        private TcpListener listener;
        /// <summary>
        /// The client pool
        /// </summary>
        private ClientPool clientPool;
        /// <summary>
        /// The end of communication
        /// </summary>
        private bool endOfCommunication;
        /// <summary>
        /// Initializes a new instance of the <see cref="Server"/> class.
        /// </summary>
        public Server()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ConfigurationSettings.AppSettings["ip"]), Convert.ToInt32(ConfigurationSettings.AppSettings["port"]));
            listener = new TcpListener(ep);
            this.clientPool = new ClientPool(this);
            this.endOfCommunication = false;
            listener.Start();
        }
        /// <summary>
        /// Sets the controller.
        /// </summary>
        /// <param name="cntrl">The CNTRL.</param>
        public void SetController(IController cntrl)
        {
            controller = cntrl;
        }
        /// <summary>
        /// Starts to listen.
        /// </summary>
        public void StartToListen()
        {
            Task listen = new Task(() =>
            {
                while (true)
                {
                    TcpClient cli = listener.AcceptTcpClient();
                    if (cli != null)
                    {
                       // Console.WriteLine("Waiting for client connections...");
                        this.clientPool.AddClient(cli, this);
                       // Console.WriteLine("new client handler added");
                        cli = null;
                    }
                }
                //this.clientPool.closeCommunication();
            });
            listen.Start();
            while (true) { }
        }
    }
}
